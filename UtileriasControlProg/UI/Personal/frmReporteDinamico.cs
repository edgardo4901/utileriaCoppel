using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtileriasControlProg.DAL;
using UtileriasControlProg.Entity;

namespace UtileriasControlProg.UI.Personal
{
    public partial class frmReporteDinamico : Form
    {
        List<ParametrosConsultar> listaBloque1;
        List<ParametrosConsultar> listaBloque2;
        List<ParametrosConsultar> listaBloque3;
        string conexion_principal;
        string conexion_hojavida;
        ConexionPG ConexionPostgres = new ConexionPG();
        ConexionSql oConexion;
        List<ValoresComboBox> listaEmpresas;
        List<ValoresComboBox> listaRegiones;
        List<ValoresComboCiudad> listaCiudades;
        List<ValoresComboBox> listaSecciones;
        List<ValoresComboBox> listaZonas;
        DataTable dtCombos;
        DataTable dtConsulta;
        DataTable dtConsultaHojaVida;
        DataTable dtConsultaPostgres;
        DataTable dtConsultaIncentivo;
        int pagina = 0;
        int totalpaginas = 0;
        int totalregistros = 0;
        int registrosoagina = 100;
        bool precionoEnter = false;
        bool seleccionoAfiliado = false;
        bool seleccionoNss = false;
        bool seleccionoCurp = false;
        bool seleccionoRfc = false;
        bool seleccionoIncentivo = false;
        bool botonPaginador1 = false;
        bool botonPaginador2 = false;
        public frmReporteDinamico()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = "Reporte Dinamico";
            oConexion = new ConexionSql();
            try
            {
                conexion_principal = oConexion.CreaCadenaConexion();
                conexion_hojavida = oConexion.CreaCadenaConexionHojaVida();
                btnMas.Enabled = false;
                btnMenos.Enabled = false;
                lblPagina.Text = "";
                cargarConfiguraciones();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), nombreSolucion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            switch (keyData)
            {
                case Keys.F5:
                    bHandled = true;
                    consultarInformacion(false, true);
                    break;
                case Keys.F9:
                    bHandled = true;
                    registrosoagina = 100;
                    pagina = 1;
                    consultarInformacion(true, false);
                    break;
            }
            return bHandled;
        }

        public void cargarConfiguraciones()
        {
            listaBloque1 = new List<ParametrosConsultar>();
            listaBloque2 = new List<ParametrosConsultar>();
            listaBloque3 = new List<ParametrosConsultar>();

            string jsonstr = "";
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(Entity.Configuracion.parametros);
            while ((line = file.ReadLine()) != null)
            {
                jsonstr += line;
            }
            file.Close();

            List<ParametrosConsultar> lstparametros = JsonConvert.DeserializeObject<List<ParametrosConsultar>>(jsonstr);

            foreach (ParametrosConsultar element in lstparametros)
            {
                if (element.Bloque == 1)
                {
                    listaBloque1.Add(element);
                }
                else if (element.Bloque == 2)
                {
                    listaBloque2.Add(element);
                }
                else if (element.Bloque == 3)
                {
                    listaBloque3.Add(element);
                }
            }

            //string[] myFruit = { "Apples", "Oranges", "Tomato" };
            //chklstboxBloque1.Items.AddRange(myFruit);

            chklstboxBloque1.DataSource = listaBloque1;
            chklstboxBloque1.DisplayMember = "NombreMostrar";

            chklstboxBloque2.DataSource = listaBloque2;
            chklstboxBloque2.DisplayMember = "NombreMostrar";

            chklstboxBloque3.DataSource = listaBloque3;
            chklstboxBloque3.DisplayMember = "NombreMostrar";

            ConsultarFiltros();

            // Changes the selection mode from double-click to single click.
            chklstboxBloque1.CheckOnClick = true;
            chklstboxBloque2.CheckOnClick = true;
            chklstboxBloque3.CheckOnClick = true;

            if (!Configuracion.MostrarBloque1)
            {
                chklstboxBloque1.Visible = false;
            }
            if (!Configuracion.MostrarBloque2)
            {
                chklstboxBloque2.Visible = false;
                lblCamposbloque2.Visible = false;
            }
            if (!Configuracion.MostrarBloque3)
            {
                chklstboxBloque3.Visible = false;
                lblCampoIncentivo.Visible = false;
            }
        }

        private void ConsultarFiltros()
        {
            dtCombos = new DataTable();
            listaEmpresas = new List<ValoresComboBox>();
            listaRegiones = new List<ValoresComboBox>();
            listaSecciones = new List<ValoresComboBox>();
            listaCiudades = new List<ValoresComboCiudad>();
            listaZonas = new List<ValoresComboBox>();

            ValoresComboBox valorInicialEmpresa = new ValoresComboBox();
            ValoresComboBox valorInicialRegion = new ValoresComboBox();
            ValoresComboBox valorInicialSeccion = new ValoresComboBox();
            ValoresComboCiudad valorInicialCiudad = new ValoresComboCiudad();
            ValoresComboBox valorInicialZona = new ValoresComboBox();

            //llena combo empresas
            string query = "exec procLlenaCombosFiltros 1,0,0";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaEmpresas = Utilerias.ConvertDataTable<ValoresComboBox>(dtCombos);

            valorInicialEmpresa.clave = 0;
            valorInicialEmpresa.nombre = "000 TODAS LAS EMPRESAS";

            listaEmpresas.Insert(0, valorInicialEmpresa);

            //llena combo regiones
            dtCombos = new DataTable();
            query = "exec procLlenaCombosFiltros 2,0,0";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaRegiones = Utilerias.ConvertDataTable<ValoresComboBox>(dtCombos);

            valorInicialRegion.numero = 0;
            valorInicialRegion.nombre = "000 TODAS LAS REGIONES";

            listaRegiones.Insert(0, valorInicialRegion);

            //llena combo ciudades este se recarga al seleccionar una region
            /*dtCombos = new DataTable();
            query = "exec procLlenaCombosFiltros 3,0,0";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaCiudades = Utilerias.ConvertDataTable<ValoresComboBox>(dtCombos);

            valorInicialCiudad.numero = 0;
            valorInicialCiudad.NombreCiudad = "000 TODAS LAS CIUDADES";

            listaCiudades.Insert(0, valorInicialCiudad);*/

            //llena combo secciones
            dtCombos = new DataTable();
            query = "exec procLlenaCombosFiltros 4,0,0";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaSecciones = Utilerias.ConvertDataTable<ValoresComboBox>(dtCombos);

            valorInicialSeccion.numero = 0;
            valorInicialSeccion.nombre = "000 TODAS LAS SECCIONES";

            listaSecciones.Insert(0, valorInicialSeccion);

            //llena combo zona
            dtCombos = new DataTable();
            query = "SELECT RIGHT( '00' + RTRIM( CONVERT( CHAR( 2 ), Zona ) ), 2) + ' ' + Descripcion   as nombre,zona as numero FROM sapZonasCiudades(nolock) ORDER BY RIGHT('00' + RTRIM(CONVERT(CHAR(2), Zona)), 2) ";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaZonas = Utilerias.ConvertDataTable<ValoresComboBox>(dtCombos);

            valorInicialZona.numero = 0;
            valorInicialZona.nombre = "000 TODAS LAS Zonas";

            listaZonas.Insert(0, valorInicialZona);

            //asigna datos a combos
            cbEmpresa.DataSource = listaEmpresas;
            cbEmpresa.DisplayMember = "nombre";

            cbRegion.DataSource = listaRegiones;
            cbRegion.DisplayMember = "nombre";

            cbSeccion.DataSource = listaSecciones;
            cbSeccion.DisplayMember = "nombre";

            cbZona.DataSource = listaZonas;
            cbZona.DisplayMember = "nombre";
        }

        private void chklstboxBloque1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValoresComboCiudad valorInicialCiudad = new ValoresComboCiudad();

            ValoresComboBox itemSeleccionado = (ValoresComboBox)cbRegion.SelectedItem;

            dtCombos = new DataTable();
            string query = "exec procLlenaCombosFiltros 3," + itemSeleccionado.numero.ToString() + ",0";
            dtCombos = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            listaCiudades = Utilerias.ConvertDataTable<ValoresComboCiudad>(dtCombos);

            valorInicialCiudad.numero = "0";
            valorInicialCiudad.NombreCiudad = "000 TODAS LAS CIUDADES";

            listaCiudades.Insert(0, valorInicialCiudad);

            cbCiudad.DataSource = listaCiudades;
            cbCiudad.DisplayMember = "NombreCiudad";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            registrosoagina = 100;
            pagina = 1;
            consultarInformacion(true,false);
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            if(pagina < totalpaginas)
            {
                pagina++;
                consultarInformacion(false,false);
            }
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (pagina > 1)
            {
                pagina--;
                consultarInformacion(false,false);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            consultarInformacion(false, true);
        }

        private string consultarCentro(string numcentro)
        {
            dtConsulta = new DataTable();
            string centro = "";
            string query = " select NombreCentro from sapCatalogoCentros where NumeroCentro = " + numcentro;
            dtConsulta = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            if (dtConsulta.Rows.Count > 0)
            {
                centro = dtConsulta.Rows[0]["NombreCentro"].ToString();
            }
            return centro;
        }

        private void consultarInformacion(bool consultarTotal,bool esExcel)
        {
            string centroInicial = "0";
            string centrofinal = "0";
            seleccionoAfiliado = false;
            seleccionoCurp = false;
            seleccionoNss = false;
            seleccionoRfc = false;
            seleccionoIncentivo = false;

            if (txtDescripcionDel.Text.ToString().Trim() != "")
            {
                centroInicial = txtDelCentro.Text.ToString().Trim();
            }
            if (txtDescripcionAl.Text.ToString().Trim() != "")
            {
                centrofinal = txtAlCentro.Text.ToString().Trim();
            }

            if((centroInicial != "0" && centrofinal == "0") || (centroInicial == "0" && centrofinal != "0"))
            {
                MessageBox.Show("Debe ingresar ambos campos del centro al centro o ninguno");
                return;
            }

            if (int.Parse(centroInicial) > int.Parse(centrofinal))
            {
                MessageBox.Show("El centro incial no puede ser menor al centro final");
                return;
            }

            List<ParametrosConsultar> seleccionadosBloque1 = chklstboxBloque1.CheckedItems.OfType<ParametrosConsultar>().ToList();
            List<ParametrosConsultar> seleccionadosBloque2 = chklstboxBloque2.CheckedItems.OfType<ParametrosConsultar>().ToList();
            List<ParametrosConsultar> seleccionadosBloque3 = chklstboxBloque3.CheckedItems.OfType<ParametrosConsultar>().ToList();

            /*if ((seleccionadosBloque1.Count + seleccionadosBloque2.Count + seleccionadosBloque3.Count) <= 0)
            {
                MessageBox.Show("No se selecciono ningun valor para la consulta");
                return;
            }*/

            //string consultaValores = "SELECT DISTINCT 1 AS Renglon,";
            /*string consultaValores = "SELECT DISTINCT TOP 2000 ";
            if (esExcel)
            {
                consultaValores = "SELECT DISTINCT ";
            }*/
            string consultaValores = "SELECT DISTINCT ";
            //valores iniciales
            consultaValores += "sce.NumeroPuesto AS [# PUESTO],";
            consultaValores += "scp.nombre AS [NOMBRE PUESTO],";
            consultaValores += "scciu.InicialNueva AS [CIUDAD],";
            consultaValores += "sce.numemp as [NUMEMP],";
            consultaValores += "RTRIM( sce.ApellidoPaterno ) + ' ' + RTRIM( sce.ApellidoMaterno ) + ' ' + RTRIM( sce.Nombre ) AS [NOMBRE],";
            consultaValores += "scc.centron AS [CENTRO],";
            consultaValores += "scc.NombreCentro AS [NOMBRE CENTRO],";
            consultaValores += "DATEDIFF( MONTH, sce.FechaAlta, GETDATE() ) AS [ANTIG.],";
            consultaValores += "CAST((sce.Sueldo/CAST(100 AS decimal(18,2))) AS decimal(18,2)) [SUELDO],";
            consultaValores += "CAST( (COALESCE(sec.Despensa,0)/CAST(100 AS decimal(18,2))) as decimal(18,2)) [DINERO ELEC.],";
            consultaValores += "CAST((sce.Sueldo/CAST(100 AS decimal(18,2))) AS decimal(18,2)) + CAST( (COALESCE(sec.Despensa,0)/CAST(100 AS decimal(18,2))) as decimal(18,2)) AS [TOTAL],";
            consultaValores += "CAST(DATEDIFF( MONTH, sce.FechaNacimiento, GETDATE() ) / CAST(12 AS decimal) AS decimal(8,2)) AS [EDAD],";
            consultaValores += "UPPER(CAST(FORMAT (sce.FechaNacimiento, 'dd/MMM/yyyy') AS VARCHAR(20))) AS [FECHA DE NACIMIENTO],";
            consultaValores += "CASE sce.Sexo WHEN 2 THEN 'M' ELSE 'F' END [SEXO],";
            consultaValores += "UPPER(CAST(FORMAT (sce.FechaAlta, 'dd/MMM/yyyy') AS VARCHAR(20))) AS [FECHA DE ALTA],";
            consultaValores += "CAST(DATEDIFF( MONTH, sce.FechaAlta, GETDATE() ) / CAST(12 AS decimal) AS decimal(8,2)) AS [FECHA DE ANTIGÜEDAD],";
            consultaValores += "sce.TipoNomina as [TIPO DE NOMINA],";
            consultaValores += "CAST(coalesce(cs.numeroseccion,scc.Seccion) AS VARCHAR(20))+' - ' + coalesce(cs.nombre,'') as [SECCION],";
            consultaValores += "CAST(scciu.ciudadn AS VARCHAR(20)) + ' - ' + scciu.NombreCiudad AS [NÚMERO Y NOMBRE DE CIUDAD],";
            consultaValores += "CAST(coalesce(cr.numeroregion,0) AS VARCHAR(20)) + ' - ' + coalesce(cr.nombre,'') AS [REGIÓN],";
            consultaValores += "CAST(coalesce(se.clave,0) AS VARCHAR(20)) + ' - ' + coalesce(se.nombre,'') AS [NÚMERO Y NOMBRE DE EMPRESA],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 1],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 2],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 3],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO FONDO TRABAJADOR],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO FONDO EMPRESA],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO CUENTA CORRIENTE],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO AUTOCOP],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO AHORRO ADICIONAL I],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO AHORRO ADICIONAL II],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO FAER TRABAJADOR],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- SALDO FAER EMPRESA],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- DESCUENTO CUENTA CORRIENTE],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN FONDO AHORRO EMPRESA],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN FONDO AHORRO EMPLEADO],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN ADICIONAL  FONDO AHORRO EMPLEADO],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN AHORRO ESPECIAL],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN AHORRO EXTRAORDINARIO TRABAJADOR],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- APORTACIÓN AHORRO EXTRAORDINARIO EMPRESA],";
            consultaValores += "CAST(0 AS decimal(18,2)) AS [- INCENTIVO FONDO EXTRAORDINARIO EMPRESA],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [RFC],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [NSS],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [CURP],";
            consultaValores += "CAST('' AS VARCHAR(250)) AS [- Afiliado a AforeCoppel (SI/NO)]";

            /*foreach (ParametrosConsultar element in seleccionadosBloque1)
            {
                if (consultaValores == "SELECT ")
                {
                    consultaValores += element.NombreParametro;
                }
                else
                {
                    consultaValores += "," + element.NombreParametro;
                }
                contrador++;
            }

            foreach (ParametrosConsultar element in seleccionadosBloque2)
            {
                if (consultaValores == "SELECT ")
                {
                    consultaValores += element.NombreParametro;
                }
                else
                {
                    consultaValores += "," + element.NombreParametro;
                }
                contrador++;
            }

            foreach (ParametrosConsultar element in seleccionadosBloque3)
            {
                if (consultaValores == "SELECT ")
                {
                    consultaValores += element.NombreParametro;
                }
                else
                {
                    consultaValores += "," + element.NombreParametro;
                }
                contrador++;
            }*/

            //se armarn las tablas de la seleccion y las validaciones 

            string TablasConsultaTotal = " SELECT COUNT(*) as Total FROM SapCatalogoEmpleados sce(NOLOCK)" +
                                    " LEFT JOIN sapempresas se(NOLOCK) ON se.clave =  sce.Empresa" +
                                    " LEFT JOIN sapempleadoscatalogo sec(NOLOCK) ON sce.numempn = sec.numemp" +
                                    " INNER JOIN sapCatalogoPuestos scp(nolock) ON sce.numeropuesto = scp.numero" +
                                    " INNER JOIN sapCatalogoCentros scc(NOLOCK) ON scc.centron = sce.centron" +
                                    " LEFT JOIN cat_secciones cs(NOLOCK) ON cs.numeroseccion = scc.Seccion" +
                                    " INNER JOIN sapCatalogoCiudades scciu(NOLOCK) ON scc.ciudadn = scciu.ciudadn" +
                                    " LEFT JOIN cat_regiones cr (NOLOCK) ON cr.numeroregion = scciu.RegionZona" +
                                    " WHERE sce.Cancelado = '' AND sce.Empresa = CASE @Empresa WHEN 0 THEN sce.Empresa ELSE @Empresa END" +
                                    " AND sce.centron between CASE @CentroInicial WHEN 0 THEN -1 ELSE @CentroInicial END AND CASE @CentroFinal WHEN 0 THEN 999999999 ELSE @CentroFinal END" +
                                    " AND scciu.zonaciudad = CASE @Zona WHEN 0 THEN scciu.zonaciudad ELSE @Zona END" +
                                    " AND scciu.regionzona =  CASE @Region WHEN 0 THEN scciu.regionzona ELSE @Region END" +
                                    " AND scc.ciudadn = CASE @Ciudad WHEN 0 THEN scc.ciudadn ELSE @Ciudad END" +
                                    " AND scc.seccion = CASE @Seccion WHEN 0 THEN  scc.seccion ELSE @Seccion END";

            string TablasConsulta = " INTO #tmpConcentradoEmpleados FROM SapCatalogoEmpleados sce(NOLOCK)" +
                                    " LEFT JOIN sapempresas se(NOLOCK) ON se.clave =  sce.Empresa" +
                                    " LEFT JOIN sapempleadoscatalogo sec(NOLOCK) ON sce.numempn = sec.numemp" +
                                    " INNER JOIN sapCatalogoPuestos scp(nolock) ON sce.numeropuesto = scp.numero" +
                                    " INNER JOIN sapCatalogoCentros scc(NOLOCK) ON scc.centron = sce.centron" +
                                    " LEFT JOIN cat_secciones cs(NOLOCK) ON cs.numeroseccion = scc.Seccion" +
                                    " INNER JOIN sapCatalogoCiudades scciu(NOLOCK) ON scc.ciudadn = scciu.ciudadn" +
                                    " LEFT JOIN cat_regiones cr (NOLOCK) ON cr.numeroregion = scciu.RegionZona";

            string validacionesConsulta = "  WHERE sce.Cancelado = '' AND sce.Empresa = CASE @Empresa WHEN 0 THEN sce.Empresa ELSE @Empresa END" +
                                        " AND sce.centron between CASE @CentroInicial WHEN 0 THEN -1 ELSE @CentroInicial END AND CASE @CentroFinal WHEN 0 THEN 999999999 ELSE @CentroFinal END" +
                                        " AND scciu.zonaciudad = CASE @Zona WHEN 0 THEN scciu.zonaciudad ELSE @Zona END" +
                                        " AND scciu.regionzona =  CASE @Region WHEN 0 THEN scciu.regionzona ELSE @Region END" +
                                        " AND scc.ciudadn = CASE @Ciudad WHEN 0 THEN scc.ciudadn ELSE @Ciudad END" +
                                        " AND scc.seccion = CASE @Seccion WHEN 0 THEN  scc.seccion ELSE @Seccion END";
            if (!esExcel)
            {
                //validacionesConsulta += " UPDATE #tmpConcentradoEmpleados SET Renglon = temp.reng FROM ( SELECT NUMEMP, ROW_NUMBER() OVER(ORDER BY NUMEMP DESC) as reng FROM #tmpConcentradoEmpleados)temp where #tmpConcentradoEmpleados.NUMEMP = temp.NUMEMP ";
                //validacionesConsulta += " DELETE from #tmpConcentradoEmpleados where Renglon not between @RenglonInicial and @RenglonFinal ";
            }

            validacionesConsulta = validacionesConsulta + " DECLARE @FechaMovimientos DATE = (SELECT MAX(fecha) FROM fondo.dbo.fa_movs_histo_edoctas)" +
                                   " select a.NUMEMP,fdo.clavemovimiento,fdo.importe" +
                                   " into #tmpConcentradoMovimientosFondo" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " INNER JOIN fondo.dbo.fa_movs_histo_edoctas fdo (nolock) ON fdo.noempleado = a.NUMEMP" +
                                   " AND  fdo.clavemovimiento in (309,138,128,304,109,170,148,198,190,180,105,301,306,141,186,176)" +
                                   " and fdo.fecha = @FechaMovimientos" +
                                   " INSERT INTO #tmpConcentradoMovimientosFondo" +
                                   " select a.NUMEMP,fdo.clavemovimiento,fdo.importe" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " INNER JOIN fondo.dbo.fa_movimientoshistodelfondo fdo (nolock) ON fdo.noempleado = a.NUMEMP" +
                                   " AND  fdo.clavemovimiento in (047)" +
                                   " and fdo.fechacorte = @FechaMovimientos" +
                                   " update a set " +
                                   " [- SALDO FONDO TRABAJADOR] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (309,138)),0)," +
                                   " [- SALDO FONDO EMPRESA] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (128,304) ),0)," +
                                   " [- SALDO CUENTA CORRIENTE] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (109) ),0)," +
                                   " [- SALDO AUTOCOP] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (170) ),0)," +
                                   " [- SALDO AHORRO ADICIONAL I] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (148) ),0)," +
                                   " [- SALDO AHORRO ADICIONAL II] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (198) ),0)," +
                                   " [- SALDO FAER TRABAJADOR] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (190) ),0)," +
                                   " [- SALDO FAER EMPRESA] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (180) ),0)," +
                                   " [- DESCUENTO CUENTA CORRIENTE] = COALESCE(( SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (105) ),0)," +
                                   " [- APORTACIÓN FONDO AHORRO EMPRESA] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (301) ),0)," +
                                   " [- APORTACIÓN FONDO AHORRO EMPLEADO] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (306) ),0)," +
                                   " [- APORTACIÓN ADICIONAL  FONDO AHORRO EMPLEADO] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (141) ),0)," +
                                   " [- APORTACIÓN AHORRO ESPECIAL] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (047) ),0)," +
                                   " [- APORTACIÓN AHORRO EXTRAORDINARIO TRABAJADOR] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (186) ),0)," +
                                   " [- APORTACIÓN AHORRO EXTRAORDINARIO EMPRESA] = COALESCE((SELECT SUM(CAST(fdo.importe / CAST(100 AS decimal(18,2)) AS decimal(18,2))) FROM #tmpConcentradoMovimientosFondo fdo (nolock) WHERE fdo.numemp = a.numemp AND  fdo.clavemovimiento in (176) ),0)" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " update a set [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 1] = COALESCE(CAST(he.numemp AS varchar(20)),'') + ' - ' +" +
                                   " RTRIM( COALESCE(he.Nombre,'') ) +' '+ RTRIM( COALESCE(he.ApellidoPaterno,'') ) + ' ' + RTRIM( COALESCE(he.ApellidoMaterno,'') ) + ' - ' +" +
                                   " COALESCE(CAST(hcp.numero AS varchar(20)),'') + ' ' + RTRIM(hcp.nombre)" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " LEFT JOIN sapempleadospropuestas sep (NOLOCK) on sep.NumEmp = a.numemp" +
                                   " LEFT JOIN hecatalogoempleados he(NOLOCK) ON he.numemp = sep.num_jefe1" +
                                   " LEFT JOIN hecatalogopuestos hcp (NOLOCK) ON hcp.numero = he.numeropuesto" +
                                   " where a.[TIPO DE NOMINA] = 1" +
                                   " UPDATE a SET" +
                                   " [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 2] =" +
                                   " COALESCE(CAST(he.numemp AS varchar(20)),'') + ' - ' +" +
                                   " RTRIM( COALESCE(he.Nombre,'') ) +' '+ RTRIM( COALESCE(he.ApellidoPaterno,'') ) + ' ' + RTRIM( COALESCE(he.ApellidoMaterno,'') ) + ' - ' +" +
                                   " COALESCE(CAST(hcp.numero AS varchar(20)),'') + ' ' + RTRIM(hcp.nombre)" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " LEFT JOIN sapempleadospropuestas sep (NOLOCK) on sep.NumEmp = a.numemp" +
                                   " LEFT JOIN hecatalogoempleados he(NOLOCK) ON he.numemp = sep.num_jefe2" +
                                   " LEFT JOIN hecatalogopuestos hcp (NOLOCK) ON hcp.numero = he.numeropuesto" +
                                   " where a.[TIPO DE NOMINA] = 1" +
                                   " UPDATE a SET" +
                                   " [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 2] =" +
                                   " COALESCE(CAST(he.numemp AS varchar(20)),'') + ' - ' +" +
                                   " RTRIM( COALESCE(he.Nombre,'') ) +' '+ RTRIM( COALESCE(he.ApellidoPaterno,'') ) + ' ' + RTRIM( COALESCE(he.ApellidoMaterno,'') ) + ' - ' +" +
                                   " COALESCE(CAST(hcp.numero AS varchar(20)),'') + ' ' + RTRIM(hcp.nombre)" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " LEFT JOIN perpropuestadirectivos sep (NOLOCK) on sep.NumEmp = a.numemp" +
                                   " LEFT JOIN hecatalogoempleados he(NOLOCK) ON he.numemp = sep.num_jefe2" +
                                   " LEFT JOIN hecatalogopuestos hcp (NOLOCK) ON hcp.numero = he.numeropuesto" +
                                   " where a.[TIPO DE NOMINA] = 3" +
                                   " UPDATE a SET" +
                                   " [NOMBRE, NUM DE EMPLEADO Y PUESTO DE JEFE 3] =" +
                                   " COALESCE(CAST(he.numemp AS varchar(20)),'') + ' - ' +" +
                                   " RTRIM( COALESCE(he.Nombre,'') ) +' '+ RTRIM( COALESCE(he.ApellidoPaterno,'') ) + ' ' + RTRIM( COALESCE(he.ApellidoMaterno,'') ) + ' - ' +" +
                                   " COALESCE(CAST(hcp.numero AS varchar(20)),'') + ' ' + RTRIM(hcp.nombre)" +
                                   " from #tmpConcentradoEmpleados a" +
                                   " LEFT JOIN perpropuestadirectivos sep (NOLOCK) on sep.NumEmp = a.numemp" +
                                   " LEFT JOIN hecatalogoempleados he(NOLOCK) ON he.numemp = sep.num_jefe3" +
                                   " LEFT JOIN hecatalogopuestos hcp (NOLOCK) ON hcp.numero = he.numeropuesto" +
                                   " where a.[TIPO DE NOMINA] = 3";

            //se recorren los campos seleccionados
            /*string camposSeleccionar = " SELECT Renglon,";
            if (esExcel)
            {
                camposSeleccionar = " SELECT ";
            }*/
            string camposSeleccionar = " SELECT ";
            camposSeleccionar += "[# PUESTO],";
            camposSeleccionar += "[NOMBRE PUESTO],";
            camposSeleccionar += "[CIUDAD],";
            camposSeleccionar += "[NUMEMP],";
            camposSeleccionar += "[NOMBRE],";
            camposSeleccionar += "[CENTRO],";
            camposSeleccionar += "[NOMBRE CENTRO],";
            camposSeleccionar += "[ANTIG.],";
            camposSeleccionar += "[SUELDO],";
            camposSeleccionar += "[DINERO ELEC.],";
            camposSeleccionar += "[TOTAL]";

            int contrador = 0;
            foreach (ParametrosConsultar element in seleccionadosBloque1)
            {
                camposSeleccionar += "," + element.NombreParametro;
                contrador++;
            }

            foreach (ParametrosConsultar element in seleccionadosBloque2)
            {
                if(element.NombreMostrar == "Afiliado a AforeCoppel")
                {
                    seleccionoAfiliado = true;
                    dtConsultaHojaVida = new DataTable();
                }
                else if (element.NombreMostrar == "RFC")
                {
                    seleccionoRfc = true;
                }
                else if (element.NombreMostrar == "NSS")
                {
                    seleccionoNss = true;
                }
                else if (element.NombreMostrar == "CURP")
                {
                    seleccionoCurp = true;
                }
                camposSeleccionar += "," + element.NombreParametro;
                contrador++;
            }

            foreach (ParametrosConsultar element in seleccionadosBloque3)
            {
                if (element.NombreMostrar == "Incentivo Fondo extraordinario empresa")
                {
                    seleccionoIncentivo = true;
                }
                camposSeleccionar += "," + element.NombreParametro;
                contrador++;
            }

            camposSeleccionar += " FROM #tmpConcentradoEmpleados";
            //si es distinto de excel se ordena por el renglon insertado
            if (!esExcel)
            {
                //camposSeleccionar += " Order by Renglon asc";
            }
            camposSeleccionar += " drop table #tmpConcentradoMovimientosFondo";
            camposSeleccionar += " drop table #tmpConcentradoEmpleados";

            //se concatenan los campos seleccionados
            validacionesConsulta += camposSeleccionar;

            ValoresComboBox itemSeleccionadoEmpresa = (ValoresComboBox)cbEmpresa.SelectedItem;
            ValoresComboBox itemSeleccionadoRegion = (ValoresComboBox)cbRegion.SelectedItem;
            ValoresComboCiudad itemSeleccionadoCiudad = (ValoresComboCiudad)cbCiudad.SelectedItem;
            ValoresComboBox itemSeleccionadoSeccion = (ValoresComboBox)cbSeccion.SelectedItem;
            ValoresComboBox itemSeleccionadoZona = (ValoresComboBox)cbZona.SelectedItem;

            int renglonInicial = (pagina * registrosoagina) - registrosoagina;
            int renglonFinal = pagina * registrosoagina;

            if (consultarTotal)
            {
                TablasConsultaTotal = TablasConsultaTotal.Replace("@CentroInicial", centroInicial);
                TablasConsultaTotal = TablasConsultaTotal.Replace("@CentroFinal", centrofinal);
                TablasConsultaTotal = TablasConsultaTotal.Replace("@Empresa", itemSeleccionadoEmpresa.clave.ToString());
                TablasConsultaTotal = TablasConsultaTotal.Replace("@Zona", itemSeleccionadoZona.numero.ToString());
                TablasConsultaTotal = TablasConsultaTotal.Replace("@Region", itemSeleccionadoRegion.numero.ToString());
                TablasConsultaTotal = TablasConsultaTotal.Replace("@Ciudad", itemSeleccionadoCiudad.numero.ToString());
                TablasConsultaTotal = TablasConsultaTotal.Replace("@Seccion", itemSeleccionadoSeccion.numero.ToString());

                dtConsulta = oConexion.ConsultaSqlDataTable(conexion_principal, TablasConsultaTotal, CommandType.Text);
                totalregistros = int.Parse(dtConsulta.Rows[0]["Total"].ToString());
                totalpaginas = totalregistros / registrosoagina;
            }

            if (pagina >= totalpaginas)
            {
                renglonFinal = totalregistros;
            }


            validacionesConsulta = validacionesConsulta.Replace("@CentroInicial", centroInicial);
            validacionesConsulta = validacionesConsulta.Replace("@CentroFinal", centrofinal);
            validacionesConsulta = validacionesConsulta.Replace("@Empresa", itemSeleccionadoEmpresa.clave.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@Zona", itemSeleccionadoZona.numero.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@Region", itemSeleccionadoRegion.numero.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@Ciudad", itemSeleccionadoCiudad.numero.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@Seccion", itemSeleccionadoSeccion.numero.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@RenglonInicial", renglonInicial.ToString());
            validacionesConsulta = validacionesConsulta.Replace("@RenglonFinal", renglonFinal.ToString());
            dtConsulta = new DataTable();
            string query = consultaValores + TablasConsulta + validacionesConsulta;


            iniciarEjecucion(esExcel);

            new Thread(() =>
            {
                string respuesta = "";
                try
                {
                    dtConsulta = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
                    if (seleccionoAfiliado)
                    {
                        consultarAfiliadoHojaVida();
                    }
                    if (seleccionoIncentivo)
                    {
                        consultarDatosIncentivo();
                    }
                    if (seleccionoCurp || seleccionoNss || seleccionoRfc)
                    {
                        consultarDatosPostres();
                    }
                    if (dtConsulta.Rows.Count <= 0)
                    {
                        respuesta = "No hay información con los filtros seleccionado";
                    }
                    else if (esExcel)
                    {
                        string fechaactual = DateTime.Now.ToString("MMddyyyyHHmm", CultureInfo.InvariantCulture);
                        string nombrereporte = "ReporteDinamico" + fechaactual + ".xlsx";
                        respuesta = Utilerias.GenerarReporteExcel(nombrereporte, "Reporte Dinamico", "", dtConsulta);
                    }
                }
                catch (Exception ex)
                {
                    respuesta = ex.ToString();
                }

                Task.Factory.StartNew(() =>
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (!esExcel)
                        {
                            BindingSource source = new BindingSource();
                            source.DataSource = dtConsulta;
                            dgvConsulta.DataSource = source;
                            source.ResetBindings(true);
                        }

                        terminoEjecucion(respuesta, esExcel);
                    }));
                });

            }
            ).Start();
        }
        private void consultarAfiliadoHojaVida()
        {
            string query = "select idu_colaborador AS [NumEmp],CASE idu_afore WHEN 568 THEN 'SI' ELSE 'NO' END [-Afiliado a AforeCoppel(SI / NO)] from[dbo].[ctl_colaboradores] where idu_colaborador in (" + numeroEmpleados() + ")";
            dtConsultaHojaVida = oConexion.ConsultaSqlDataTable(conexion_hojavida, query, CommandType.Text);
            foreach (DataRow row in dtConsultaHojaVida.Rows)
            {
                DataRow dr = dtConsulta.Select("NUMEMP=" + row["NumEmp"].ToString()).FirstOrDefault();
                if (dr != null)
                {
                    dr["- Afiliado a AforeCoppel (SI/NO)"] = row["-Afiliado a AforeCoppel(SI / NO)"].ToString();
                }
            }
        }
        private void consultarDatosIncentivo()
        {
            dtConsultaIncentivo = new DataTable();
            string query = "Select convert(varchar(8),cast(MAX(fecha) as date),112) as fecha FROM fondo.dbo.fa_movs_histo_edoctas";
            dtConsultaIncentivo = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
            string fecha = dtConsultaIncentivo.Rows[0]["fecha"].ToString();

            dtConsultaIncentivo = new DataTable();
            NpgsqlConnection odbc = new NpgsqlConnection();
            if (ConexionPG.abreconexionPG(ref odbc, 1))
            {
                string querypos = "select numemp,tipomovimiento,importe from nommovimientoshistorico where tipomovimiento = 635 AND fecha = '" + fecha + "'" + " AND NUMEMP in (" + numeroEmpleados() + ")";
                dtConsultaIncentivo = ConexionPG.fEjecutarConsulta(querypos, odbc);
                foreach (DataRow row in dtConsultaIncentivo.Rows)
                {
                    DataRow dr = dtConsulta.Select("NUMEMP=" + row["numemp"].ToString()).FirstOrDefault();
                    if (dr != null)
                    {
                        dr["- INCENTIVO FONDO EXTRAORDINARIO EMPRESA"] = double.Parse(row["importe"].ToString());
                    }
                }
            }
            ConexionPG.cierraconexionPG(odbc);
        }
        private void consultarDatosPostres()
        {
            dtConsultaPostgres = new DataTable();
            NpgsqlConnection odbc = new NpgsqlConnection();
            if (ConexionPG.abreconexionPG(ref odbc,1))
            {
                string querypos = "SELECT DISTINCT numemp,curp,rfc,numeroafiliacion FROM NomHistoricoEmpleados WHERE NUMEMP in (" + numeroEmpleados() + ")";
                dtConsultaPostgres = ConexionPG.fEjecutarConsulta(querypos, odbc);

                foreach (DataRow row in dtConsultaPostgres.Rows)
                {
                    DataRow dr = dtConsulta.Select("NUMEMP=" + row["NumEmp"].ToString()).FirstOrDefault();
                    if (dr != null)
                    {
                        if (seleccionoRfc)
                        {
                            dr["RFC"] = row["rfc"].ToString();
                        }
                        if (seleccionoCurp)
                        {
                            dr["CURP"] = row["curp"].ToString();
                        }
                        if (seleccionoNss)
                        {
                            dr["NSS"] = row["numeroafiliacion"].ToString();
                        }
                    }
                }
            }
            ConexionPG.cierraconexionPG(odbc);
        }
        private string numeroEmpleados()
        {
            string numeros = "";
            foreach (DataRow row in dtConsulta.Rows)
            {
                if(numeros != "")
                {
                    numeros += ",";
                }
                numeros += row["NUMEMP"].ToString();
            }
            return numeros;
        }
        private void txtDelCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAlCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDelCentro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                consultarDelCentro();
                precionoEnter = true;
            } 
        }

        private void txtAlCentro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                consultarAlCentro();
                precionoEnter = true;
            }
        }

        private void txtDelCentro_Leave(object sender, EventArgs e)
        {
            if (!precionoEnter)
            {
                consultarDelCentro();
            }
            precionoEnter = false;
        }

        private void txtAlCentro_Leave(object sender, EventArgs e)
        {
            if (!precionoEnter)
            {
                consultarAlCentro();
            }
            precionoEnter = false;
        }
        private void consultarDelCentro()
        {
            if (txtDelCentro.Text.ToString().Trim() != "")
            {
                string nombreCentro = consultarCentro(txtDelCentro.Text.ToString().Trim());
                if (nombreCentro != "")
                {
                    txtDescripcionDel.Text = nombreCentro;
                }
                else
                {
                    //txtDelCentro.Text = "";
                    txtDescripcionDel.Text = "";
                    MessageBox.Show("No se encontro el centro ingresado");
                }
            }
            else
            {
                txtDescripcionDel.Text = "";
            }
        }

        private void consultarAlCentro()
        {
            if (txtAlCentro.Text.ToString().Trim() != "")
            {
                string nombreCentro = consultarCentro(txtAlCentro.Text.ToString().Trim());
                if (nombreCentro != "")
                {
                    txtDescripcionAl.Text = nombreCentro;
                }
                else
                {
                    //txtAlCentro.Text = "";
                    txtDescripcionAl.Text = "";
                    MessageBox.Show("No se encontro el centro ingresado");
                }
            }
            else
            {
                txtDescripcionAl.Text = "";
            }
        }
        private void iniciarEjecucion(bool esExcel)
        {
            if (!esExcel)
            {
                lblPagina.Text = pagina.ToString() + "/" + totalpaginas.ToString();
                btnMas.Enabled = false;
                btnMenos.Enabled = false;
                btnConsultar.Text = "Consultando...";
            }
            else
            {
                botonPaginador1 = btnMas.Enabled;
                botonPaginador2 = btnMenos.Enabled;
                btnMas.Enabled = false;
                btnMenos.Enabled = false;
                btnExcel.Text = "Exportando...";
            }
            btnConsultar.Enabled = false;
            btnExcel.Enabled = false;
        }
        private void terminoEjecucion(string mensaje, bool esExcel)
        {
            btnConsultar.Enabled = true;
            btnExcel.Enabled = true;
            if (!esExcel)
            {
                if (pagina < totalpaginas)
                {
                    btnMas.Enabled = true;
                }
                if (pagina > 1)
                {
                    btnMenos.Enabled = true;
                }
                btnConsultar.Text = "F9 Consultar";
            }
            else
            {
                btnExcel.Text = "F5 Exportar";
                btnMas.Enabled = botonPaginador1;
                btnMenos.Enabled = botonPaginador2;
            }
            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
            }
        }
    }
}
