using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        ConexionSql oConexion;
        List<ValoresComboBox> listaEmpresas;
        List<ValoresComboBox> listaRegiones;
        List<ValoresComboCiudad> listaCiudades;
        List<ValoresComboBox> listaSecciones;
        List<ValoresComboBox> listaZonas;
        DataTable dtCombos;
        DataTable dtConsulta;
        int pagina = 0;
        int totalpaginas = 0;
        int totalregistros = 0;
        int registrosoagina = 100;
        bool precionoEnter = false;
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
            }
            if (!Configuracion.MostrarBloque3)
            {
                chklstboxBloque3.Visible = false;
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

            if ((seleccionadosBloque1.Count + seleccionadosBloque2.Count + seleccionadosBloque3.Count) <= 0)
            {
                MessageBox.Show("No se selecciono ningun valor para la consulta");
                return;
            }

            string consultaValores = "Select * from (SELECT ROW_NUMBER() OVER(ORDER BY sce.Numemp DESC) AS Renglon";
            if (esExcel)
            {
                consultaValores = "SELECT ";
            }
            int contrador = 0;

            foreach (ParametrosConsultar element in seleccionadosBloque1)
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
            }

            string TablasConsultaTotal = " SELECT COUNT(*) as Total FROM SapCatalogoEmpleados sce(NOLOCK)" +
                                    " LEFT JOIN sapempleadoscatalogo sec(NOLOCK) ON sce.numempn = sec.numemp" +
                                    " INNER JOIN sapCatalogoPuestos scp(nolock) ON sce.numeropuesto = scp.numero" +
                                    " INNER JOIN sapCatalogoCentros scc(NOLOCK) ON scc.centron = sce.centron" +
                                    " INNER JOIN sapCatalogoCiudades scciu(NOLOCK) ON scc.ciudadn = scciu.ciudadn" +
                                    " WHERE sce.Empresa = CASE @Empresa WHEN 0 THEN sce.Empresa ELSE @Empresa END" +
                                    " AND sce.centron between CASE @CentroInicial WHEN 0 THEN - 1 ELSE @CentroInicial END AND CASE @CentroFinal WHEN 0 THEN 999999999 ELSE @CentroFinal END" +
                                    " AND scciu.zonaciudad = CASE @Zona WHEN 0 THEN scciu.zonaciudad ELSE @Zona END" +
                                    " AND scciu.regionzona = CASE @Region WHEN 0 THEN scciu.regionzona ELSE @Region END" +
                                    " AND scc.ciudadn = CASE @Ciudad WHEN 0 THEN scc.ciudadn ELSE @Ciudad END" +
                                    " AND scc.seccion = CASE @Seccion WHEN 0 THEN scc.seccion ELSE @Seccion END";

            string TablasConsulta = " FROM SapCatalogoEmpleados sce(NOLOCK)" +
                                    " LEFT JOIN sapempleadoscatalogo sec(NOLOCK) ON sce.numempn = sec.numemp" +
                                    " INNER JOIN sapCatalogoPuestos scp(nolock) ON sce.numeropuesto = scp.numero" +
                                    " INNER JOIN sapCatalogoCentros scc(NOLOCK) ON scc.centron = sce.centron" +
                                    " INNER JOIN sapCatalogoCiudades scciu(NOLOCK) ON scc.ciudadn = scciu.ciudadn";

            string validacionesConsulta = " WHERE sce.Empresa = CASE @Empresa WHEN 0 THEN sce.Empresa ELSE @Empresa END" +
                                          " AND sce.centron between CASE @CentroInicial WHEN 0 THEN - 1 ELSE @CentroInicial END AND CASE @CentroFinal WHEN 0 THEN 999999999 ELSE @CentroFinal END" +
                                          " AND scciu.zonaciudad = CASE @Zona WHEN 0 THEN scciu.zonaciudad ELSE @Zona END" +
                                          " AND scciu.regionzona = CASE @Region WHEN 0 THEN scciu.regionzona ELSE @Region END" +
                                          " AND scc.ciudadn = CASE @Ciudad WHEN 0 THEN scc.ciudadn ELSE @Ciudad END" +
                                          " AND scc.seccion = CASE @Seccion WHEN 0 THEN scc.seccion ELSE @Seccion END ";
            if (!esExcel)
            {
                validacionesConsulta += ") as tblConsulta where tblConsulta.Renglon between @RenglonInicial and @RenglonFinal ";
            }

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
                    if (dtConsulta.Rows.Count <= 0)
                    {
                        respuesta = "No hay información con los filtros seleccionado";
                    }
                    else if (esExcel)
                    {
                        respuesta = Utilerias.GenerarReporteExcel("ReporteDinamico.xlsx", "Reporte Dinamico", "", dtConsulta);
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
            }
            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
            }
        }
    }
}
