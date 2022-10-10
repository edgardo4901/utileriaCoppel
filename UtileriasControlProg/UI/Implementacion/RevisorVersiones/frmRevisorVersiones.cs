using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasControlProg.Entity;
using UtileriasControlProg.BO;
using System.IO;
using Renci.SshNet;
using System.Threading;
using System.Net.NetworkInformation;
using WinSCP;
using System.Diagnostics;
using Npgsql;

namespace UtileriasControlProg.UI.Implementacion
{
    public partial class frmRevisorVersiones : Form
    {

        #region Propiedades

        private List<ArchivosTiendaDetalle> archivosTiendaDetallePrincipal = new List<ArchivosTiendaDetalle>();
        private static ServidorBase servidorBase = null;
        private List<ModelBusquedaPorArchivo> archivosABuscar = new List<ModelBusquedaPorArchivo>();
        private List<ArchivosTienda> tiendasBusqueda = new List<ArchivosTienda>();
        private List<Entity.Tiendas> tiendasPrincipal = new List<UtileriasControlProg.Entity.Tiendas>();
        List<ArchivosTiendaDetalle> archivosEnviar = new List<ArchivosTiendaDetalle>();
        private DataTable table;
        private int TotalArchivosTienda = 0;


        //Estas propiedades se utilizan en los envios por bloques a las tiendas        
        List<ArchivosTienda> Bloque1 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque2 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque3 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque4 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque5 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque6 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque7 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque8 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque9 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque10 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque11 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque12 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque13 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque14 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque15 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque16 = new List<ArchivosTienda>();
        List<ArchivosTienda> Bloque17 = new List<ArchivosTienda>();



        #endregion

        #region Constructores
        public frmRevisorVersiones()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        #endregion

        #region Eventos

        public void generarArchivoTiendas()
        {
            List<string> tiendas = new List<string>();
            tiendasPrincipal = BO.TiendasBO.TraerTiendas();
            StreamReader sq = new StreamReader(@"C:\x\bloque5.txt");
            string lineOfText = "";
            while ((lineOfText = sq.ReadLine()) != null)
            {
                if (lineOfText.Trim() != "")
                    tiendas.Add(lineOfText);
            }
            sq.Close();

            int pos = 0;
            StreamWriter sw = new StreamWriter(@"C:\x\abloque5.txt");
            foreach (var item in tiendas) {
                var tda = tiendasPrincipal.Find(x => int.Parse(x.Tienda) == int.Parse(item));
                if (tda != null) {
                    sw.WriteLine("numtienda[" + pos + "] =" + int.Parse(tda.Tienda).ToString() + ";");
                    sw.WriteLine("tiendas[" + pos + "] = \"" + tda.IPservidorlocal + "\";");
                    pos++;
                }
            }
            sw.Close();




            //StreamReader read = new StreamReader(@"C:\x\script.txt");
            //string comand = read.ReadToEnd();
            //int iposision = 0;
            //foreach (var item in tiendas)
            //{
            //    var tda = tiendasPrincipal.Find(x => int.Parse(x.Tienda) == int.Parse(item));
            //    if (tda != null)
            //    {
            //        try
            //        {
            //            NpgsqlConnection con = new NpgsqlConnection("Server=" + tda.IPservidorlocal + ";Port=5432;Database=tienda." + item + ";User Id=syscontrolprogramacion;Password=f45459f3627a6d7372b261324aa4b574;");
            //            con.Open();
            //            string comando="";
            //            comando = comand;
            //            comando += Environment.NewLine;
            //            comando += "ALTER FUNCTION ctesatendidosporempleado09_ctlprog(integer) OWNER TO systienda" + item + ";";

            //            NpgsqlCommand cmd = new NpgsqlCommand(comando, con);
            //            cmd.ExecuteNonQuery();

            //            con.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
            

        }

        private void frmRevisorVersiones_Load(object sender, EventArgs e)
        {
            //Obliga al usuario a generar el servidor base
            servidorBase = (UtileriasBO.existFileServerBase((int)TipoServidor.Tienda) ? UtileriasBO.getFileServerBase((int)TipoServidor.Tienda) : null);

            while (!UtileriasBO.existFileServerBase((int)TipoServidor.Tienda))
            {
                MessageBox.Show("Se debe configurar un servidor base para la comparacion de archivos");
                frmServidorBase serverbase = new frmServidorBase(new ServidorBase(), (int)TipoServidor.Tienda);
                serverbase.Owner = this;
                serverbase.StartPosition = FormStartPosition.CenterParent;
                serverbase.ShowDialog();
                //serverbase.Dispose();
                servidorBase = (UtileriasBO.existFileServerBase((int)TipoServidor.Tienda) ? UtileriasBO.getFileServerBase((int)TipoServidor.Tienda) : null);

                while (!validaServidorBase(servidorBase))
                {
                    MessageBox.Show("Archivo de datos mal formado, debes completar todos los campos del formulario para poder avanzar");
                    serverbase = new frmServidorBase(servidorBase == null ? new ServidorBase() : servidorBase, (int)TipoServidor.Tienda);
                    serverbase.Owner = this;
                    serverbase.StartPosition = FormStartPosition.CenterParent;
                    serverbase.ShowDialog();
                    serverbase.Dispose();

                    servidorBase = (UtileriasBO.existFileServerBase((int)TipoServidor.Tienda) ? UtileriasBO.getFileServerBase((int)TipoServidor.Tienda) : null);
                }
            }

            ServidorBaseConfiguracion.ip = servidorBase.ip;
            ServidorBaseConfiguracion.usuario = servidorBase.usuario;
            ServidorBaseConfiguracion.password = servidorBase.password;

            lblServidorPrincipal.Text += servidorBase.ip;

            updateFilesServidorBase();
        }

        private void btnIniciarEjecucion_Click(object sender, EventArgs e)
        {
            try
            {
                //generarArchivoTiendas();
                //return;


                tiendasBusqueda = new List<ArchivosTienda>();
                if (validarIniciarEjecucion())
                {
                    if (inicializaFiltroDeBusqueda())
                    {

                        if (dataGridResultadoTiendas.DataSource != null)
                        {
                            dataGridResultadoTiendas.DataSource = null;
                            dataGridResultadoTiendas.Rows.Clear();
                            dataGridResultadoTiendas.Columns.Clear();
                            dataGridResultadoTiendas.Refresh();
                        }

                        btnKillHilo.Enabled = false;

                        //Obteniendo los archivos que vamos a procesar
                        Configuracion.ArchivosTiendaDetalleServidorBase = new List<ArchivosTiendaDetalle>();
                        if (rdTPorDirectorio.Checked)
                        {
                            
                            //

                            archivosTiendaDetallePrincipal.FindAll(x => x.Ruta.ToUpper().Contains(txtRutaPrincipal.Text.Trim().ToUpper())).ForEach(x =>
                            {
                                Configuracion.ArchivosTiendaDetalleServidorBase.Add(new ArchivosTiendaDetalle() { Ruta = x.Ruta });
                            });
                        }
                        else
                        {
                            foreach (ModelBusquedaPorArchivo item in archivosABuscar)
                            {
                                if (archivosTiendaDetallePrincipal.Find(x => x.Ruta.ToUpper().Equals(item.Archivo.ToUpper())) != null)
                                {
                                    Configuracion.ArchivosTiendaDetalleServidorBase.Add(new ArchivosTiendaDetalle() { Ruta = archivosTiendaDetallePrincipal.Find(x => x.Ruta.ToUpper().Equals(item.Archivo.ToUpper())).Ruta, MD5 = item.Md5Manual });
                                }
                                else {
                                    Configuracion.ArchivosTiendaDetalleServidorBase.Add(new ArchivosTiendaDetalle() { Ruta = item.Archivo, MD5 = item.Md5Manual });
                                }
                            }
                        }

                        if (Configuracion.ArchivosTiendaDetalleServidorBase.Count == 0)
                        {
                            MessageBox.Show("No se encontraron modulos por revisar");
                            return;
                        }

                        btnDetalleArchivosBase.Enabled = false;
                        lblGenerandoArchivosAConsultar.Visible = true;
                        lblTotalArchivos.Text = "Total Archivos: " + Configuracion.ArchivosTiendaDetalleServidorBase.Count.ToString();

                        //Iniciamos los valores de la barra de estado
                        Configuracion.TotalArchivosObtenidos = 0;

                        pgbArchivosServidor.Style = ProgressBarStyle.Blocks;
                        pgbArchivosServidor.Maximum = Configuracion.ArchivosTiendaDetalleServidorBase.Count;
                        pgbArchivosServidor.Value = 0;

                        pgArchivosPorTienda.Style = ProgressBarStyle.Blocks;
                        pgArchivosPorTienda.Maximum = 100;
                        pgArchivosPorTienda.Value = 0;

                        BO.UtileriasBO.LogSeguimiento("Inicia ejecucion con los siguientes parametros", "Tiendas: " + txtTiendas.Text + " Excepciones: " + txtTiendasExcepcion.Text);
                        new Thread(() => getMD5FromServerBase(ServidorBaseConfiguracion.ip, ref Configuracion.ArchivosTiendaDetalleServidorBase, 0, Configuracion.ArchivosTiendaDetalleServidorBase.Count - 1)).Start();



                        //string md5 = BO.CMd5.getMd5(@"C:\sys\progx\PEDIDOSEXHT.DLL");
                        //BO.CSsh.ejecutarComandSsh("10.44.15.99");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfigurarServer_Click(object sender, EventArgs e)
        {
            try
            {
                frmServidorBase serverbase = new frmServidorBase(servidorBase == null ? new ServidorBase() : servidorBase, (int)TipoServidor.Tienda);
                serverbase.Owner = this;
                serverbase.StartPosition = FormStartPosition.CenterParent;
                serverbase.ShowDialog();
                serverbase.Dispose();

                servidorBase = (UtileriasBO.existFileServerBase((int)TipoServidor.Tienda) ? UtileriasBO.getFileServerBase((int)TipoServidor.Tienda) : null);
                lblServidorPrincipal.Text = "Servidor Principal: " + servidorBase.ip;

                ServidorBaseConfiguracion.ip = servidorBase.ip;
                ServidorBaseConfiguracion.usuario = servidorBase.usuario;
                ServidorBaseConfiguracion.password = servidorBase.password;

                updateFilesServidorBase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdPorTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorTienda.Checked)
            {
                lblTiendas.Text = "Ingresa el numero de tienda";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
                lblTotalRev.Visible = true;

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }
        }

        private void rdPorTiendas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorTiendas.Checked)
            {
                lblTiendas.Text = "Ingresa las tiendas separas por (,) coma";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
                lblTotalRev.Visible = false;

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }
        }

        private void rdPorRangoTiendas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorRangoTiendas.Checked)
            {
                lblTiendas.Text = "Ingresa el rango de tiendas separados por (-)";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
                lblTotalRev.Visible = false;

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }

        }

        private void rdFiltroPorIP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFiltroPorIP.Checked)
            {
                lblTiendas.Text = "IP del servidor a consultar";
                txtTiendas.Text = "";
                txtTiendas.Enabled = false;
                txtTiendas.Visible = false;
                lblTotalRev.Visible = true;

                label1.Visible = false;
                txtTiendasExcepcion.Visible = false;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = true;
                txtIPServer.Visible = true;
            }
        }

        private void rDTodasLasTiendas_CheckedChanged(object sender, EventArgs e)
        {
            if (rDTodasLasTiendas.Checked)
            {
                lblTiendas.Text = "Se van a consultar todas las tiendas";
                txtTiendas.Text = "";
                txtTiendas.Enabled = false;
                txtTiendas.Visible = false;
                lblTotalRev.Visible = false;

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }
        }

        private void btnDetalleArchivosBase_Click(object sender, EventArgs e)
        {
            try
            {
                frmDetalleArchivoBase frm_detallebase = new frmDetalleArchivoBase();
                frm_detallebase.Owner = this;
                frm_detallebase.StartPosition = FormStartPosition.CenterParent;
                frm_detallebase.ShowDialog();
                frm_detallebase.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string md5Manual = "";

            if (txtRutaPrincipal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar la ruta del archivo");
                txtMD5.Text = "MD5 MANUAL";
                txtRutaPrincipal.Focus();
                return;
            }

            //if (!txtRutaPrincipal.Text.Trim().Contains('.'))
            //{
            //    MessageBox.Show("Debe ingresar un archivo valido");
            //    txtMD5.Text = "MD5 MANUAL";
            //    txtRutaPrincipal.Focus();
            //    return;
            //}

            var itemsSinFiltro = archivosTiendaDetallePrincipal.FindAll(x => x.Ruta.ToUpper().Trim().Contains(txtRutaPrincipal.Text.ToUpper()));
            var itemsFiltrados = new List<ArchivosTiendaDetalle>();


            bool busquedaArchivoExistente = true;

            if (itemsSinFiltro.ToList().Count == 0)
            {

                var confirmResult = MessageBox.Show(
                    "No se encontro el archivo especificado en la lista de directorios" + Environment.NewLine +
                    "                        ¿Desea realizar la busqueda?"
                    , "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (txtMD5.Text.ToUpper().Trim() == "MD5 MANUAL" || txtMD5.Text.ToUpper().Trim().Length == 0)
                    {
                        MessageBox.Show("Para poder realizar esta busqueda es necesario especificar el MD5 MANUAL");
                        txtMD5.Text = "MD5 MANUAL";
                        txtMD5.Focus();
                        return;
                    }

                    if (!txtRutaPrincipal.Text.ToUpper().Trim().Contains("/"))
                    {
                        MessageBox.Show("Para poder realizar esta busqueda es necesario especificar la UBICACION del archivo");
                        txtRutaPrincipal.Focus();
                        return;
                    }
                    busquedaArchivoExistente = false;

                }
                else
                {
                    txtRutaPrincipal.Text = "";
                    txtMD5.Text = "MD5 MANUAL";
                    txtRutaPrincipal.Focus();
                    return;
                }
            }





            if (!txtMD5.Text.ToUpper().Equals("MD5 MANUAL") && txtMD5.Text.Trim().Length > 0)
            {

                var confirmResult = MessageBox.Show("La comparacion del archivo se va a realizar con el MD5: " + txtMD5.Text, "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    md5Manual = txtMD5.Text;
                }
                else
                {
                    txtMD5.Text = "MD5 MANUAL";
                    return;
                }
            }

            if (busquedaArchivoExistente)
            {
                foreach (var ruta in itemsSinFiltro)
                {

                    var archivo = (txtRutaPrincipal.Text.Contains('/') ? ruta.Ruta : ruta.Ruta.Split('/')[ruta.Ruta.Split('/').Length - 1]);
                    if (archivo.Trim().ToUpper().Equals(txtRutaPrincipal.Text.Trim().ToUpper()))
                    {
                        itemsFiltrados.Add(ruta);
                    }
                }

                if (itemsFiltrados.ToList().Count == 0)
                {
                    MessageBox.Show("No se encontro el archivo especificado en la lista de directorios");
                    txtRutaPrincipal.Text = "";
                    txtMD5.Text = "MD5 MANUAL";
                    txtRutaPrincipal.Focus();
                    return;
                }

                foreach (var item in itemsFiltrados)
                {
                    if (archivosABuscar.Find(x => x.Archivo.Equals(item.Ruta)) == null)
                        archivosABuscar.Add(new ModelBusquedaPorArchivo() { Archivo = item.Ruta, Md5Manual = md5Manual });
                }
            }
            else
            {
                //AQUI VOY

                string[] ruta = txtRutaPrincipal.Text.Trim().Split('/');
                string rutafinal = "";

                for (int i = 0; i < ruta.Length - 1; i++)
                {
                    rutafinal += ruta[i].Trim().ToLower() + "/";
                }

                rutafinal += ruta[ruta.Length - 1].Trim();
                archivosABuscar.Add(new ModelBusquedaPorArchivo() { Archivo = rutafinal, Md5Manual = md5Manual });

            }




           



            inicializaDataGridArchivosABuscar();
            lblTotalArchivosFiltros.Text = "Total Archivos: " + archivosABuscar.Count;
            txtRutaPrincipal.Text = "";
            txtMD5.Text = "MD5 MANUAL";
            txtRutaPrincipal.Focus();
        }

        private void rdTPorDirectorio_Click(object sender, EventArgs e)
        {
            archivosABuscar = new List<ModelBusquedaPorArchivo>();
            txtRutaPrincipal.Text = "/sysx/progs/progx/";
            btnAddFile.Enabled = false;
            btnAddFile.Visible = false;
            txtMD5.Enabled = false;            
            txtMD5.Text = "MD5 MANUAL";
            txtMD5.Visible = false;
            lblTotalArchivosFiltros.Visible = false;            
            inicializaDataGridArchivosABuscar();
        }

        private void rdTPorArchivo_Click(object sender, EventArgs e)
        {
            archivosABuscar = new List<ModelBusquedaPorArchivo>();
            btnAddFile.Enabled = true;
            btnAddFile.Visible = true;
            txtMD5.Enabled = true;
            txtMD5.Visible = true;
            txtMD5.Text = "MD5 MANUAL";
            inicializaDataGridArchivosABuscar();
            lblTotalArchivosFiltros.Visible = true;            
            lblTotalArchivosFiltros.Text = "Total Archivos: " + archivosABuscar.Count;
        }

        private void dgBusquedaPorArchivos_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            List<ModelBusquedaPorArchivo> ListAux = new List<ModelBusquedaPorArchivo>();

            for (int i = 0; i < dgBusquedaPorArchivos.Rows.Count; i++)
            {
                ListAux.Add(archivosABuscar.Find(x => x.Archivo.Equals(dgBusquedaPorArchivos.Rows[i].Cells["Archivo"].Value.ToString())));
            }
            archivosABuscar = new List<ModelBusquedaPorArchivo>();
            ListAux.ForEach(x => { archivosABuscar.Add(x); });
            inicializaDataGridArchivosABuscar();
        }

        private void rdResTodasLasTiendas_Click(object sender, EventArgs e)
        {
            procesarInformacionTienda(true);
            btnEnviarTodo.Visible = false;
            pgEnviarTodo.Visible = false;

            pgEnviarTodo.Style = ProgressBarStyle.Blocks;
            pgEnviarTodo.Maximum = 100;
            pgEnviarTodo.Value = 0;
        }

        private void rdResModulosDesactualizados_Click(object sender, EventArgs e)
        {
            procesarInformacionTienda(false);
            btnEnviarTodo.Visible = true;
            pgEnviarTodo.Visible = true;

            pgEnviarTodo.Style = ProgressBarStyle.Blocks;
            pgEnviarTodo.Maximum = 100;
            pgEnviarTodo.Value = 0;

        }

        private void btnEnviarTodo_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdResModulosDesactualizados.Checked)
                {
                    new Thread(IniciaEnvioMasivo).Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridResultadoTiendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dataGridResultadoTiendas.Columns["btnDetalle"].Index)
                    {
                        if (dataGridResultadoTiendas.Rows[e.RowIndex].Cells["Tienda"].Value.ToString() != string.Empty)
                        {
                            frmDetalleArchivoComparacion formulario = new frmDetalleArchivoComparacion(tiendasBusqueda.Find(x => x.TiendaS == dataGridResultadoTiendas.Rows[e.RowIndex].Cells["Tienda"].Value.ToString()));
                            formulario.Owner = this;
                            formulario.StartPosition = FormStartPosition.CenterParent;
                            formulario.ShowDialog();
                            procesarInformacionTienda(rdResTodasLasTiendas.Checked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar los elementos del detalle, Error: " + ex.Message);
            }
        }

        private void btnKillHilo_Click(object sender, EventArgs e)
        {
            try
            {
                frmDetalleTiendasPendientes frm_detallebase = new frmDetalleTiendasPendientes(ref tiendasBusqueda);
                frm_detallebase.Owner = this;
                frm_detallebase.StartPosition = FormStartPosition.CenterParent;
                frm_detallebase.ShowDialog();
                if (frm_detallebase.TiendaLiberar > 0)
                {
                    if (tiendasBusqueda.Find(x => x.Tienda == frm_detallebase.TiendaLiberar) != null)
                    {
                        tiendasBusqueda.Find(x => x.Tienda == frm_detallebase.TiendaLiberar).KillThread = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMD5_Click(object sender, EventArgs e)
        {
            txtMD5.SelectAll();
        }

        #endregion

        #region Metodos

        private bool inicializaFiltroDeBusqueda()
        {

            if (!rdFiltroPorIP.Checked)
            {
                tiendasPrincipal = BO.TiendasBO.TraerTiendas();
                List<Entity.Tiendas> TiendasFiltros = new List<UtileriasControlProg.Entity.Tiendas>();
                List<Entity.Tiendas> TiendasFiltrosExclusion = new List<UtileriasControlProg.Entity.Tiendas>();


                if (rdPorTienda.Checked)
                {
                    if (txtTiendas.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Debe indicar la tienda en la que se realizara la busqueda");
                        txtTiendas.Focus();
                        return false;
                    }

                    if (tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(txtTiendas.Text.Trim())) == null)
                    {
                        MessageBox.Show("La tienda ingresada no existe en la base de datos");
                        txtTiendas.Focus();
                        return false;
                    }

                    TiendasFiltros.Add(tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(txtTiendas.Text.Trim())));

                }
                else if (rdPorTiendas.Checked)
                {
                    if (txtTiendas.Text.Trim().Length == 0 || !txtTiendas.Text.Trim().Contains(','))
                    {
                        MessageBox.Show("Debe indicar las tiendas en las que se realizara la busqueda");
                        txtTiendas.Focus();
                        return false;
                    }

                    var tiendasPorComa = txtTiendas.Text.Trim().Split(',');
                    foreach (var item in tiendasPorComa)
                    {
                        if (item.Trim().Length > 0)
                        {
                            if (!isNumber(item.Trim()))
                            {
                                MessageBox.Show("Las tiendas ingresadas contien caracteres no validos");
                                txtTiendas.Focus();
                                return false;
                            }
                            if (tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(item.Trim())) != null && TiendasFiltros.Find(a => a.Tienda.Trim().Equals(item.Trim())) == null)
                            {
                                TiendasFiltros.Add(tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(item.Trim())));
                            }
                        }
                    }
                }
                else if (rdPorRangoTiendas.Checked)
                {
                    if (txtTiendas.Text.Trim().Length == 0 || !txtTiendas.Text.Trim().Contains('-'))
                    {
                        MessageBox.Show("Debe indicar las tiendas en las que se realizara la busqueda");
                        txtTiendas.Focus();
                        return false;
                    }

                    var tiendasPorRango = txtTiendas.Text.Trim().Split('-');
                    if (tiendasPorRango.Length > 2)
                    {
                        MessageBox.Show("Debe indicar el formato correcto para realizar la busqueda por rangos \n ####-####");
                        txtTiendas.Focus();
                        return false;
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        if (!isNumber(tiendasPorRango[i]))
                        {
                            MessageBox.Show("Los rangos de tiendas deben ser numericos \n ####-####");
                            txtTiendas.Focus();
                            return false;
                        }
                    }

                    int startNumber = int.Parse(tiendasPorRango[0]);
                    int endNumber = int.Parse(tiendasPorRango[1]);
                    if (startNumber > endNumber)
                    {
                        MessageBox.Show("El rango inicial debe ser menor que el rango final \n ####-####");
                        txtTiendas.Focus();
                        return false;
                    }

                    //Aqui llena las tiendas que contempla el rango
                    for (int i = startNumber; i <= endNumber; i++)
                    {
                        if (tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(i.ToString().Trim())) != null)
                        {
                            TiendasFiltros.Add(tiendasPrincipal.Find(x => x.Tienda.Trim().Equals(i.ToString().Trim())));
                        }
                    }
                }
                else if (rDTodasLasTiendas.Checked)
                {
                    TiendasFiltros = tiendasPrincipal;
                }

                if (txtTiendasExcepcion.Text.Trim().Length > 0)
                {
                    if (!txtTiendasExcepcion.Text.Trim().Contains(','))
                    {
                        MessageBox.Show("Debe ingresar el formato correcto de las tiendas que se van a excluir o bien dejar este campo en blanco");
                        txtTiendasExcepcion.Focus();
                        return false;
                    }

                    var tiendasPorComa = txtTiendasExcepcion.Text.Trim().Split(',');
                    foreach (var item in tiendasPorComa)
                    {
                        if (item.Trim().Length > 0)
                        {
                            if (!isNumber(item.Trim()))
                            {
                                MessageBox.Show("Las tiendas a excluir contienen caracteres no validos, favor de verificar");
                                txtTiendasExcepcion.Focus();
                                return false;
                            }
                            TiendasFiltrosExclusion.Add(new Entity.Tiendas() { Tienda = item.Trim() });
                        }
                    }

                    //Excluimos las tiendas del filtro principal
                    foreach (Entity.Tiendas excluir in TiendasFiltrosExclusion)
                    {
                        TiendasFiltros.RemoveAll(x => x.Tienda.Trim().Equals(excluir.Tienda.Trim()));
                    }

                }


                //Formamos el archivo principal de busqueda
                if (TiendasFiltros.Count == 0)
                {
                    MessageBox.Show("No se detectaron tiendas por revisar");
                    txtTiendasExcepcion.Focus();
                    return false;
                }

                foreach (var tienda in TiendasFiltros)
                {

                    if (chkProduccion.Checked)
                    {
                        ArchivosTienda tda = new ArchivosTienda();
                        tda.Tienda = int.Parse(tienda.Tienda);
                        tda.TiendaS = tienda.Tienda;
                        tda.Ip = tienda.IPservidorlocal;
                        tiendasBusqueda.Add(tda);
                    }

                    if (chkSoporte.Checked)
                    {
                        ArchivosTienda tda = new ArchivosTienda();
                        tda.Tienda = int.Parse(tienda.Tienda);
                        tda.TiendaS = tienda.Tienda + " - SOP";
                        tda.Ip = tienda.IPservidorSoporte;
                        tiendasBusqueda.Add(tda);
                    }

                }
            }
            else
            {
                if (!BO.CFtp.esServidorValido(txtIPServer.Text.Trim(), null, null))
                {
                    MessageBox.Show("La IP proporcionada para la busqueda no es valida");
                    txtIPServer.Focus();
                    return false;
                }

                ArchivosTienda tda = new ArchivosTienda();
                tda.Tienda = 0;
                tda.TiendaS = "0";
                tda.Ip = txtIPServer.Text.Trim();
                tiendasBusqueda.Add(tda);
            }

            return true;
        }

        private bool isNumber(string cadena)
        {
            try
            {
                int.Parse(cadena);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void inicializaDataGridArchivosABuscar()
        {
            if (dgBusquedaPorArchivos.DataSource != null)
            {
                dgBusquedaPorArchivos.DataSource = null;
                dgBusquedaPorArchivos.Rows.Clear();
                dgBusquedaPorArchivos.Columns.Clear();
                dgBusquedaPorArchivos.Refresh();
            }

            dgBusquedaPorArchivos.DataSource = toDataTable(archivosABuscar);
            dgBusquedaPorArchivos.Columns[0].Width = 250;            

            for (int i = 0; i < dgBusquedaPorArchivos.Rows.Count; i++)
            {
                if (dgBusquedaPorArchivos.Rows[i].Cells["Md5Manual"].Value.ToString().Trim().Length > 0)
                {
                    dgBusquedaPorArchivos.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    dgBusquedaPorArchivos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            dgBusquedaPorArchivos.Refresh();
            lblTotalArchivosFiltros.Text = "Total Archivos: " + archivosABuscar.Count;
        }

        public void updateFilesServidorBase()
        {
            //ServidorBaseConfiguracion.ip
            //Aqui toma la lectura de directorios del servidor principal aun que se cambie el origen de comparacion esto por que en los servidores de tiendas no se tienen permisos para ejecutar comandos find y mkdir entre otros
            string allFiles = BO.CSsh.ejecutarComandSsh("10.44.15.99", "find /sysx/");
            setListadoDeModulos(allFiles);
            getListadoDeModulos();
        }

        public void getMD5FromServerBase(string ip, ref List<ArchivosTiendaDetalle> ListaArchivosTiendaDetalle, int start, int end)
        {
            try
            {
                if (end > ListaArchivosTiendaDetalle.Count)
                {
                    end = ListaArchivosTiendaDetalle.Count - 1;
                }
                using (SshClient cliente = new SshClient(ip, ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password))
                {
                    cliente.Connect();
                    for (int i = start; i <= end; i++)
                    {
                        var x = ListaArchivosTiendaDetalle[i];
                        if (x.MD5 == null || x.MD5.Trim().Length == 0)
                        {
                            var response = cliente.RunCommand("md5sum " + x.Ruta);
                            string res = response.Result;
                            x.MD5 = res.Split(' ')[0];
                        }
                        x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                        Configuracion.TotalArchivosObtenidos++;

                        if (rdFiltroPorIP.Checked || rdPorTienda.Checked)
                            lblTotalRev.Text = string.Format("Total Rev: {0}", Configuracion.TotalArchivosObtenidos);

                        pgbArchivosServidor.Value = Configuracion.TotalArchivosObtenidos;
                        pgbArchivosServidor.Update();

                    }
                    cliente.Disconnect();
                    cliente.Dispose();
                }
                btnDetalleArchivosBase.Enabled = true;
                lblGenerandoArchivosAConsultar.Visible = false;

                //Preguntamos si el usuario quiere iniciar la ejecucion de la busqueda por tiendas
                var confirmResult = MessageBox.Show("Se va a iniciar con la exploración de archivos en los servidores de tiendas" + Environment.NewLine + "¿Desea continuar?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    iniciarBusquedaDeArchivosPorTienda();
                }
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.Log(ex.Message, "getMD5FromServerBase");
            }
        }

        public void getMD5FromTienda(ref ArchivosTienda Tienda)
        {
            try
            {
                BO.UtileriasBO.LogSeguimiento("Inicia exploracion en tienda ", Tienda.TiendaS);
                using (SshClient cliente = new SshClient(Tienda.Ip, ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password))
                {
                    cliente.Connect();

                    foreach (var x in Tienda.ArchivosTiendaDetalle)
                    {
                        if (Tienda.KillThread == 1)
                            throw new Exception("Hilo detenido por el usuario");

                        var response = cliente.RunCommand("md5sum " + x.Ruta);
                        string res = response.Result;
                        x.MD5 = res.Split(' ')[0];
                        x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                        Tienda.ArchivosObtenidos += 1;
                        if (rdFiltroPorIP.Checked || rdPorTienda.Checked)
                            lblTotalRev.Text = string.Format("Total Rev: {0}", Tienda.ArchivosObtenidos);
                    }
                    cliente.Disconnect();
                    cliente.Dispose();
                }
                Tienda.EstatusHilo = 1;
                BO.UtileriasBO.LogSeguimiento("Termina exploracion en tienda ", Tienda.TiendaS);
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.LogSeguimiento("Termina exploracion en tienda " + Tienda.TiendaS + " IP_TIENDA " + Tienda.Ip + " con ERROR:  ", ex.Message);
                Tienda.ArchivosObtenidos = Tienda.ArchivosTiendaDetalle.Count;
                Tienda.EstatusHilo = 1;
                Tienda.EstatusConexion = "Ocurrio un error al revisar los archivos de la tienda, Excepcion: " + ex.Message;
            }
        }

        private void iniciarBusquedaDeArchivosPorTienda()
        {
            lblTotalTiendas.Text = "Total Tiendas: " + tiendasBusqueda.Count;
            lblTotalTiendasRevisadas.Text = "Total Tiendas Rev: 0";
            TotalArchivosTienda = Configuracion.ArchivosTiendaDetalleServidorBase.Count * tiendasBusqueda.Count;
            pgArchivosPorTienda.Style = ProgressBarStyle.Blocks;
            pgArchivosPorTienda.Maximum = TotalArchivosTienda;
            pgArchivosPorTienda.Value = 0;
            btnKillHilo.Enabled = true;

            foreach (var item in tiendasBusqueda)
            {
                foreach (var archivo in Configuracion.ArchivosTiendaDetalleServidorBase)
                {
                    item.ArchivosTiendaDetalle.Add(new ArchivosTiendaDetalle()
                    {
                        Ruta = archivo.Ruta,
                        Modulo = archivo.Modulo,
                        MD5Produccion = archivo.MD5
                    });
                }
            }

            //Si la busqueda no es por todas la tiendas
            //Para activar el funcionamiento por bloques en necesario activar
            //if (!rDTodasLasTiendas.Checked)
            //{
                //Esta parte del codigo ejecuta todos los hilos de un jalon y la funcion de arriba debe ejecutar los hilos por bloques de 200
                new Thread(monitorearAvanceTienda).Start();
                int contador = 0;
                foreach (var item in tiendasBusqueda)
                {
                    ArchivosTienda architda = item;
                    if (!rdFiltroPorIP.Checked)
                    {
                        if (contador == 100) {
                            contador = 0;
                            Thread.Sleep(1000);
                        }

                        if (rdTPorArchivo.Checked)
                        {                            
                            new Thread(() => CSocket.buscarModulo(ref architda)).Start();
                            //new Thread(() => getMD5FromTienda(ref architda)).Start();
                        }
                        else
                        {
                            new Thread(() => getMD5FromTienda(ref architda)).Start();
                        }
                        
                        
                    }
                    else
                    {
                        getMD5FromTienda(ref architda);
                    }
                    contador++;
                }
            //}
            //else
            //{
            //    //Se van a consultar las tiendas por bloques de 300 en 300
            //    //Con este codigo distribuimos el trabajo de los hilos por bloques de ejecucion para que ejecute por bloques de N cantidad de hilos y el sistema no continua con la siguiente ejecucion hasta terminar con el bloque            

            //    int TopePorBloque = 300;
            //    int BloquesEjecutar = (int)Math.Ceiling(decimal.Parse(tiendasBusqueda.Count.ToString()) / Convert.ToDecimal(TopePorBloque));

            //    //Ingresa la informacion a los bloques de busqueda para ejecutar los hilos por bloque
            //    for (int i = 0; i < TopePorBloque; i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque1.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = TopePorBloque; i < (TopePorBloque * 2); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque2.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 2); i < (TopePorBloque * 3); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque3.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 3); i < (TopePorBloque * 4); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque4.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 4); i < (TopePorBloque * 5); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque5.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 5); i < (TopePorBloque * 6); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque6.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 6); i < (TopePorBloque * 7); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque7.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 7); i < (TopePorBloque * 8); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque8.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 8); i < (TopePorBloque * 9); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque9.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 9); i < (TopePorBloque * 10); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque10.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 10); i < (TopePorBloque * 11); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque11.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 11); i < (TopePorBloque * 12); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque12.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 12); i < (TopePorBloque * 13); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque13.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 13); i < (TopePorBloque * 14); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque14.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 14); i < (TopePorBloque * 15); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque15.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 15); i < (TopePorBloque * 16); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque16.Add(tiendasBusqueda[i]);
            //    }

            //    for (int i = (TopePorBloque * 16); i < (TopePorBloque * 17); i++)
            //    {
            //        if (i < tiendasBusqueda.Count)
            //            Bloque17.Add(tiendasBusqueda[i]);
            //    }


            //    //Prepara el inicio de la ejecucion de los hilos por bloques
            //    new Thread(monitorearAvanceTienda).Start();

            //    if (Bloque1.Count > 0)
            //    {                    
            //        foreach (var item in Bloque1)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque1.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque1.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque2.Count > 0)
            //    {
            //        foreach (var item in Bloque2)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque2.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque2.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }


            //    if (Bloque3.Count > 0)
            //    {
            //        foreach (var item in Bloque3)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque3.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque3.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque4.Count > 0)
            //    {
            //        foreach (var item in Bloque4)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque4.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque4.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque5.Count > 0)
            //    {
            //        foreach (var item in Bloque5)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque5.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque5.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque6.Count > 0)
            //    {
            //        foreach (var item in Bloque6)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque6.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque6.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque7.Count > 0)
            //    {
            //        foreach (var item in Bloque7)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque7.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque7.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque8.Count > 0)
            //    {
            //        foreach (var item in Bloque8)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque8.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque8.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque9.Count > 0)
            //    {
            //        foreach (var item in Bloque9)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque9.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque9.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque10.Count > 0)
            //    {
            //        foreach (var item in Bloque10)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque10.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque10.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque11.Count > 0)
            //    {
            //        foreach (var item in Bloque11)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque11.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque11.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque12.Count > 0)
            //    {
            //        foreach (var item in Bloque12)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque12.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque12.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque13.Count > 0)
            //    {
            //        foreach (var item in Bloque13)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque13.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque13.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque14.Count > 0)
            //    {
            //        foreach (var item in Bloque14)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque14.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque14.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque15.Count > 0)
            //    {
            //        foreach (var item in Bloque15)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque15.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque15.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque16.Count > 0)
            //    {
            //        foreach (var item in Bloque16)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque16.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque16.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //    if (Bloque17.Count > 0)
            //    {
            //        foreach (var item in Bloque17)
            //        {
            //            ArchivosTienda architda = item;
            //            new Thread(() => getMD5FromTienda(ref architda)).Start();
            //        }
            //        while (Bloque17.FindAll(x => x.EstatusHilo == 0).Count > 0)
            //        {
            //            Console.WriteLine("Hilos Pendientes por procesar: " + Bloque17.FindAll(x => x.EstatusHilo == 0).Count);
            //        }
            //    }

            //}
        }

        public void monitorearAvanceTienda(List<ArchivosTienda> Bloque)
        {
            foreach (var item in Bloque)
            {
                ArchivosTienda architda = item;
                new Thread(() => getMD5FromTienda(ref architda)).Start();
            }

            var archivosObtenidos = Bloque.Sum(x => x.ArchivosObtenidos);
            int TotalArchivosBloque = Configuracion.ArchivosTiendaDetalleServidorBase.Count * Bloque.Count;

            //pgArchivosPorTienda.Value = archivosObtenidos;
            //pgArchivosPorTienda.Update();

            while (archivosObtenidos < TotalArchivosBloque)
            {
                archivosObtenidos = Bloque.Sum(x => x.ArchivosObtenidos);
                //pgArchivosPorTienda.Value = archivosObtenidos;
                //pgArchivosPorTienda.Update();
                Thread.Sleep(50);
            }
        }

        public void monitorearAvanceTienda()
        {

            var archivosObtenidos = tiendasBusqueda.Sum(x => x.ArchivosObtenidos);
            pgArchivosPorTienda.Value = archivosObtenidos;
            pgArchivosPorTienda.Update();

            while (archivosObtenidos < TotalArchivosTienda)
            {
                lblTotalTiendasRevisadas.Text = "Total Tiendas Rev: " + tiendasBusqueda.FindAll(z => z.EstatusHilo == 1).Count;
                //Console.WriteLine(tiendasBusqueda.FindAll(z => z.EstatusHilo == 1).Count);
                archivosObtenidos = tiendasBusqueda.Sum(x => x.ArchivosObtenidos);
                pgArchivosPorTienda.Value = archivosObtenidos;
                pgArchivosPorTienda.Update();
                Thread.Sleep(50);
            }

            groupBox3.Enabled = true;
            rdResTodasLasTiendas.Checked = true;

            procesarInformacionTienda(true);
        }

        private void inicializaGridResultado()
        {
            table = new DataTable();
            table.Columns.Add("Tienda", typeof(string));
            table.Columns.Add("Ip", typeof(string));
            table.Columns.Add("Modulos", typeof(int));
            table.Columns.Add("ModulosOutdate", typeof(int));
            table.Columns.Add("ModulosFaltantes", typeof(int));
            table.Columns.Add("EstatusConexion", typeof(string));

            if (dataGridResultadoTiendas.DataSource != null)
            {
                dataGridResultadoTiendas.DataSource = null;
                dataGridResultadoTiendas.Rows.Clear();
                dataGridResultadoTiendas.Columns.Clear();
                dataGridResultadoTiendas.Refresh();
            }

        }
        
        private void procesarInformacionTienda(bool allFiles)
        {

            inicializaGridResultado();
            int reg = 0;
            foreach (ArchivosTienda item in tiendasBusqueda)
            {
                reg++;
                item.ArchivosTiendaDetalle.FindAll(x => x.MD5 == null).ForEach(x => { x.MD5 = ""; });

                var modulosDesactualizados = item.ArchivosTiendaDetalle.FindAll(x => !x.MD5.ToUpper().Trim().Equals(x.MD5Produccion.ToUpper().Trim()));
                if (allFiles)
                {
                    DataRow row = table.NewRow();
                    row["Tienda"] = item.TiendaS;
                    row["Ip"] = item.Ip;
                    row["Modulos"] = item.ArchivosTiendaDetalle.Count;
                    row["ModulosOutdate"] = modulosDesactualizados.Count;
                    row["ModulosFaltantes"] = 0;
                    row["EstatusConexion"] = item.EstatusConexion;
                    table.Rows.Add(row);
                }
                else
                {
                    if (modulosDesactualizados.Count > 0)
                    {
                        DataRow row = table.NewRow();
                        row["Tienda"] = item.TiendaS;
                        row["Ip"] = item.Ip;
                        row["Modulos"] = item.ArchivosTiendaDetalle.Count;
                        row["ModulosOutdate"] = modulosDesactualizados.Count;
                        row["ModulosFaltantes"] = 0;
                        row["EstatusConexion"] = item.EstatusConexion;
                        table.Rows.Add(row);
                    }
                }
            }

            if (dataGridResultadoTiendas.DataSource != null)
            {
                dataGridResultadoTiendas.DataSource = null;
                dataGridResultadoTiendas.Rows.Clear();
                dataGridResultadoTiendas.Columns.Clear();
                dataGridResultadoTiendas.Refresh();
            }

            if (table.Rows.Count == 0)
            {
                DataRow row = table.NewRow();
                row["ModulosOutdate"] = 0;
                row["Tienda"] = "";
                table.Rows.Add(row);
            }
                

            dataGridResultadoTiendas.DataSource = table;
            dataGridResultadoTiendas.ScrollBars = ScrollBars.Both;


            dataGridResultadoTiendas.Columns["Ip"].Width = 250;
            dataGridResultadoTiendas.Columns["EstatusConexion"].Width = 300;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridResultadoTiendas.Columns.Add(btn);
            btn.HeaderText = "Detalle";
            btn.Text = "Ver";
            btn.Name = "btnDetalle";
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Popup;

            dataGridResultadoTiendas.Refresh();

            /*Aplicamos los estilos al grid*/
            for (int i = 0; i < dataGridResultadoTiendas.Rows.Count; i++)
            {
                dataGridResultadoTiendas.Rows[i].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                if ((int)dataGridResultadoTiendas.Rows[i].Cells["ModulosOutdate"].Value > 0)
                {
                    dataGridResultadoTiendas.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridResultadoTiendas.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    dataGridResultadoTiendas.Rows[i].DefaultCellStyle.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

                }
            }
        }

        private bool validaServidorBase(ServidorBase sb)
        {
            if (sb == null)
                return false;
            if (sb.ip.Trim().Length == 0)
                return false;
            if (sb.usuario.Trim().Length == 0)
                return false;
            if (sb.password.Trim().Length == 0)
                return false;
            return true;
        }

        private void setListadoDeModulos(string contenido)
        {
            using (StreamWriter sw = new StreamWriter(@"ArchivosServidorBase.txt"))
            {
                sw.WriteLine(contenido);
                sw.Close();
            }
        }

        private void getListadoDeModulos()
        {
            archivosTiendaDetallePrincipal = new List<ArchivosTiendaDetalle>();
            string line = "";
            StreamReader file = new StreamReader(@"ArchivosServidorBase.txt");

            string lineaAux = "";
            while ((line = file.ReadLine()) != null)
            {

                if (lineaAux.Contains("."))
                {
                    if (!lineaAux.Contains(".listing"))
                    {
                        archivosTiendaDetallePrincipal.Add(new ArchivosTiendaDetalle() { Ruta = lineaAux });
                    }
                }
                else
                {
                    if (lineaAux.Trim().Length > 0 && !line.Contains(lineaAux + "/"))
                    {
                        archivosTiendaDetallePrincipal.Add(new ArchivosTiendaDetalle() { Ruta = lineaAux });
                    }
                }
                lineaAux = line.Trim();
            }
            file.Close();

            if (lineaAux.Contains("."))
            {
                if (!lineaAux.Contains(".listing"))
                {
                    archivosTiendaDetallePrincipal.Add(new ArchivosTiendaDetalle() { Ruta = lineaAux });
                }
            }
            else
            {
                if (lineaAux.Trim().Length > 0 && !line.Contains(lineaAux + "/"))
                {
                    archivosTiendaDetallePrincipal.Add(new ArchivosTiendaDetalle() { Ruta = lineaAux });
                }
            }
        }

        public bool validarIniciarEjecucion()
        {

            if (rdTPorDirectorio.Checked)
            {
                if (txtRutaPrincipal.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar la ruta principal de busqueda");
                    txtRutaPrincipal.Focus();
                    return false;
                }
                return true;
            }

            if (rdTPorArchivo.Checked)
            {
                if (archivosABuscar.Count == 0)
                {
                    MessageBox.Show("Debe ingresar los archivos que se van a buscar");
                    txtRutaPrincipal.Focus();
                    return false;
                }
                return true;
            }

            bool tiposTiendas = false;

            if (chkProduccion.Checked) {
                tiposTiendas = true;
            }

            if (chkSoporte.Checked)
            {
                tiposTiendas = true;
            }

            if (rdFiltroPorIP.Checked)
            {
                tiposTiendas = true;
            }

            if (!tiposTiendas) {
                MessageBox.Show("Debe especificar el tipo de servidor en que se realizara la busqueda");
                return false;
            }




            MessageBox.Show("Ocurrio un error al definir el tipo de busqueda que se va a realizar");
            return false;




        }

        public DataTable toDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            return pingable;
        }

        public void IniciaEnvioMasivo()
        {
            try
            {
                var tiendasRealizarEnvios = tiendasBusqueda.FindAll(x => x.ArchivosTiendaDetalle.FindAll(a => !a.MD5.ToUpper().Trim().Equals(a.MD5Produccion.ToUpper().Trim())).Count > 0);
                int TotalArchivosaEnviar = tiendasRealizarEnvios.Sum(x => x.ArchivosTiendaDetalle.FindAll(a => !a.MD5.ToUpper().Trim().Equals(a.MD5Produccion.ToUpper().Trim())).Count);

                if (TotalArchivosaEnviar == 0)
                {
                    MessageBox.Show("No se detectaron archivos a enviar a las tiendas");
                    return;
                }

                var confirmResult = MessageBox.Show("¿Quieres enviar los archivos desde el SERVIDOR BASE?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    
                    archivosEnviar = new List<ArchivosTiendaDetalle>();

                    foreach (var tda in tiendasRealizarEnvios)
                    {
                        foreach (ArchivosTiendaDetalle item in tda.ArchivosTiendaDetalle)
                        {
                            if (archivosEnviar.Find(x => x.Ruta.Equals(item.Ruta)) == null)
                            {
                                if (!item.MD5Produccion.Equals(item.MD5))
                                {
                                    archivosEnviar.Add(new ArchivosTiendaDetalle()
                                    {
                                        Ruta = item.Ruta,
                                        MD5Produccion = item.MD5Produccion,
                                        Estatus = 0
                                    });
                                }
                            }
                        }
                    }


                    //Iniciamos con la descarga de los archivos y el proceso que monitorea la descarga de archivos
                    new Thread(() => { monitorearAvanceDownloadMasivo(ref archivosEnviar, archivosEnviar.Count); }).Start();
                    new Thread(() => { getFileFromProduccionFromArchivoTienda(ServidorBaseConfiguracion.ip, ref archivosEnviar); }).Start();
                }
                else
                {
                    var confirmEnvioManual = MessageBox.Show("¿Quieres enviar los archivos desde el DISCO LOCAL C:?", "Confirmar", MessageBoxButtons.YesNo);
                    if (confirmEnvioManual == DialogResult.Yes)
                    {
                        //Verificamos que los archivos que vamos a enviar existan localmente
                        if (verificarExistenciaDeLosArchivos())
                        {
                            //Verificamos que el MD5LocalCuadre
                            if (verificarMD5Local(archivosEnviar))
                            {

                                BO.UtileriasBO.LogSeguimiento("Inicia envio masivo de archivos desde  ", "SERVIDOR LOCAL");


                                new Thread(() => { monitorearAvanceEnvioMasivo(ref tiendasRealizarEnvios, TotalArchivosaEnviar); }).Start();

                                
                                //Aqui preguntamos si el radio de todas las tiendas esta seleccionado, de ser asi
                                ThreadPool.SetMaxThreads(50, 50);
                                foreach (var tienda in tiendasRealizarEnvios)
                                {
                                    ArchivosTienda tmpTienda = tienda;
                                    //new Thread(() => { uploadFileFromArchivoTienda(ref tmpTienda); }).Start();                                    
                                    ThreadPool.QueueUserWorkItem(state => uploadFileFromArchivoTienda(ref tmpTienda));
                                }




                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se realizo ninguna accion", "Aviso");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.Log(ex.Message, "IniciaEnvioMasivo");
            }
        }

        public void monitorearAvanceDownloadMasivo(ref List<ArchivosTiendaDetalle> tdasEnvio, int TotalArchivosaDescargar)
        {
            try
            {
                lblEnvioTodasTiendas.BeginInvoke((Action)(() =>
                {
                    lblEnvioTodasTiendas.Visible = true;
                    lblEnvioTodasTiendas.Text = "Preparando archivos a transmitir a las tiendas...";
                }));

                var archivosDescargados = tdasEnvio.Sum(x => x.Estatus);

                pgEnviarTodo.Style = ProgressBarStyle.Blocks;
                pgEnviarTodo.Maximum = TotalArchivosaDescargar;
                pgEnviarTodo.Value = archivosDescargados;
                pgEnviarTodo.Update();

                while (archivosDescargados < TotalArchivosaDescargar)
                {
                    archivosDescargados = tdasEnvio.Sum(x => x.Estatus);
                    pgEnviarTodo.Value = archivosDescargados;
                    pgEnviarTodo.Update();
                    Thread.Sleep(50);
                }

                //Una vez descargados los archivos se debe proceder con el envio masivo igual que con el envio manual
                //Hasta aqui vamos a dejar la descarga de archivos

                lblEnvioTodasTiendas.Visible = false;
                lblEnvioTodasTiendas.Text = "";

                //Preguntamos si el usuario quiere iniciar la ejecucion de la busqueda por tiendas
                var confirmResult = MessageBox.Show("Se va a iniciar con el envio de los archivos a las tiendas" + Environment.NewLine + "¿Desea continuar?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {

                    //Verificamos que los archivos que vamos a enviar existan localmente
                    if (verificarExistenciaDeLosArchivos())
                    {

                        //Verificamos que el MD5LocalCuadre
                        if (verificarMD5Local(archivosEnviar))
                        {
                            BO.UtileriasBO.LogSeguimiento("Inicia envio masivo de archivos desde  ", "SERVIDOR BASE");
                            var tiendasRealizarEnvios = tiendasBusqueda.FindAll(x => x.ArchivosTiendaDetalle.FindAll(a => !a.MD5.ToUpper().Trim().Equals(a.MD5Produccion.ToUpper().Trim())).Count > 0);
                            int TotalArchivosaEnviar = tiendasRealizarEnvios.Sum(x => x.ArchivosTiendaDetalle.FindAll(a => !a.MD5.ToUpper().Trim().Equals(a.MD5Produccion.ToUpper().Trim())).Count);

                            new Thread(() => { monitorearAvanceEnvioMasivo(ref tiendasRealizarEnvios, TotalArchivosaEnviar); }).Start();
                            foreach (var tienda in tiendasRealizarEnvios)
                            {
                                ArchivosTienda tmpTienda = tienda;
                                new Thread(() => { uploadFileFromArchivoTienda(ref tmpTienda); }).Start();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.Log(ex.Message, "monitorearAvanceDownloadMasivo");
            }
        }

        public bool verificarMD5Local(List<ArchivosTiendaDetalle> archivosAVerificarMD5)
        {

            List<ArchivosTiendaDetalle> ArchivosConMd5Diferente = new List<ArchivosTiendaDetalle>();

            //Preparamos el directorio raiz
            string dRaiz = @"C:\UtileriasControlProg";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\RevisorVersiones";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\Files";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);


            foreach (var item in archivosAVerificarMD5)
            {
                string[] directoryToPath = item.Ruta.Split('/');
                string directoryToCopy = dRaiz;

                //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                for (int i = 0; i < directoryToPath.Length; i++)
                {
                    if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                    {
                        directoryToCopy += @"\" + directoryToPath[i].Trim();
                        if (!Directory.Exists(directoryToCopy))
                            Directory.CreateDirectory(directoryToCopy);
                    }
                }

                directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();
                string Md5Local = BO.CMd5.getMd5(directoryToCopy);
                if (!item.MD5Produccion.Trim().ToUpper().Equals(Md5Local.ToUpper().Trim()))
                {
                    ArchivosConMd5Diferente.Add(new ArchivosTiendaDetalle()
                    {
                        Ruta = directoryToPath[directoryToPath.Length - 1].Trim(),
                        MD5Produccion = item.MD5Produccion,
                        MD5 = Md5Local
                    });
                }
            }
            if (ArchivosConMd5Diferente.Count > 0)
            {
                string md5dif = "RUTA-------------------------MD5---------------------MD5PROD" + Environment.NewLine;
                ArchivosConMd5Diferente.ForEach(x =>
                {
                    md5dif += x.Ruta + " " + x.MD5 + " " + x.MD5Produccion + Environment.NewLine;
                });

                MessageBox.Show(md5dif, "El MD5 de los siguientes archivos esta mal");
                return false;

            }

            return true;

        }

        public bool verificarExistenciaDeLosArchivos()
        {
            var tiendasRealizarEnvios = tiendasBusqueda.FindAll(x => x.ArchivosTiendaDetalle.FindAll(a => !a.MD5.ToUpper().Trim().Equals(a.MD5Produccion.ToUpper().Trim())).Count > 0);

            archivosEnviar = new List<ArchivosTiendaDetalle>();

            List<string> archivosFaltantes = new List<string>();

            foreach (var tda in tiendasRealizarEnvios)
            {
                foreach (ArchivosTiendaDetalle item in tda.ArchivosTiendaDetalle)
                {
                    if (archivosEnviar.Find(x => x.Ruta.Equals(item.Ruta)) == null)
                    {
                        if (!item.MD5.Trim().ToUpper().Equals(item.MD5Produccion.Trim().ToUpper()))
                        {
                            archivosEnviar.Add(new ArchivosTiendaDetalle()
                            {
                                Ruta = item.Ruta,
                                MD5Produccion = item.MD5Produccion
                            });
                        }
                    }
                }
            }

            //Preparamos el directorio raiz
            string dRaiz = @"C:\UtileriasControlProg";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\RevisorVersiones";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\Files";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            foreach (var item in archivosEnviar)
            {

                string[] directoryToPath = item.Ruta.Split('/');
                string directoryToCopy = dRaiz;

                //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                for (int i = 0; i < directoryToPath.Length; i++)
                {
                    if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                    {
                        directoryToCopy += @"\" + directoryToPath[i].Trim();
                        if (!Directory.Exists(directoryToCopy))
                            Directory.CreateDirectory(directoryToCopy);
                    }
                }

                directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();

                //En caso de que el archivo haya sido descargado previamente lo borramos de la ruta local de la maquina
                if (!File.Exists(directoryToCopy))
                    archivosFaltantes.Add(directoryToCopy);
            }

            if (archivosFaltantes.Count > 0)
            {
                string archivosnoexisten = "";
                archivosFaltantes.ForEach(x =>
                {
                    archivosnoexisten += x.Trim() + Environment.NewLine;
                });
                MessageBox.Show(archivosnoexisten, "No se encontraron los siguientes archivos");
                return false;
            }

            return true;
        }

        public void monitorearAvanceEnvioMasivo(ref List<ArchivosTienda> tdasEnvio, int TotalArchivosaEnviar)
        {
            try
            {
                lblEnvioTodasTiendas.BeginInvoke((Action)(() =>
                {
                    lblEnvioTodasTiendas.Visible = true;
                    lblEnvioTodasTiendas.Text = "Enviando archivos a las tiendas porfavor espere...";
                }));


                var archivosEnviados = tdasEnvio.Sum(x => x.ArchivosEnviados);

                pgEnviarTodo.Style = ProgressBarStyle.Blocks;
                pgEnviarTodo.Maximum = TotalArchivosaEnviar;
                pgEnviarTodo.Value = archivosEnviados;
                pgEnviarTodo.Update();

                while (archivosEnviados < TotalArchivosaEnviar)
                {
                    archivosEnviados = tdasEnvio.Sum(x => x.ArchivosEnviados);
                    pgEnviarTodo.Value = archivosEnviados;
                    pgEnviarTodo.Update();
                    Thread.Sleep(50);
                }

                MessageBox.Show("Termine de enviar los archivos");
                EndTask("WinSCP");

                lblEnvioTodasTiendas.Visible = false;
                lblEnvioTodasTiendas.Text = "";

                procesarInformacionTienda(rdResTodasLasTiendas.Checked);
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.Log(ex.Message, "monitorearAvanceEnvioMasivo");

            }
        }
        
        

        public static void getFileFromProduccionFromArchivoTienda(string ip, ref List<ArchivosTiendaDetalle> Files)
        {
            try
            {
                //Preparamos el directorio raiz
                string dRaiz = @"C:\UtileriasControlProg";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\RevisorVersiones";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\Files";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);



                //Preparamos el inicio de sesion para descargar los archivos del servidor de produccion
                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    HostName = ip,
                    UserName = ServidorBaseConfiguracion.usuario,
                    Password = ServidorBaseConfiguracion.password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (WinSCP.Session session = new WinSCP.Session())
                {
                    session.Open(options);

                    //Recorremos cada uno de los archivos que vamos a descargar
                    foreach (var item in Files)
                    {

                        string[] directoryToPath = item.Ruta.Split('/');
                        string directoryToCopy = dRaiz;

                        //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                        for (int i = 0; i < directoryToPath.Length; i++)
                        {
                            if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                            {
                                directoryToCopy += @"\" + directoryToPath[i].Trim();
                                if (!Directory.Exists(directoryToCopy))
                                    Directory.CreateDirectory(directoryToCopy);
                            }
                        }

                        directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();

                        //En caso de que el archivo haya sido descargado previamente lo borramos de la ruta local de la maquina
                        if (File.Exists(directoryToCopy))
                            File.Delete(directoryToCopy);


                        //Aqui realizamos la descarga del archivo
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;

                        TransferOperationResult transferResult;
                        transferResult = session.GetFiles(item.Ruta, directoryToCopy, false, transferOptions);

                        transferResult.Check();

                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                        }
                        item.Estatus = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Files.ForEach(x =>
                {
                    x.Estatus = 1;
                });
                BO.UtileriasBO.Log(" - " + ip + " - " + ex.Message, "getFileFromProduccionFromArchivoTienda");
            }
        }

        public static void uploadFileFromArchivoTienda(ref ArchivosTienda tienda)
        {
            try
            {
                BO.UtileriasBO.LogSeguimiento("Inicia Envio de Archivos a TIENDA ", tienda.TiendaS);

                //Preparamos el directorio raiz
                string dRaiz = @"C:\UtileriasControlProg";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\RevisorVersiones";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\Files";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);



                //Preparamos el inicio de sesion para descargar los archivos del servidor de produccion
                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    HostName = tienda.Ip,
                    UserName = ServidorBaseConfiguracion.usuario,
                    Password = ServidorBaseConfiguracion.password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (WinSCP.Session session = new WinSCP.Session())
                {
                    session.Open(options);

                    //Recorremos cada uno de los archivos que vamos a descargar
                    foreach (var item in tienda.ArchivosTiendaDetalle)
                    {
                        if (item.MD5.Trim().ToUpper().Equals(item.MD5Produccion.Trim().ToUpper()))
                            continue;

                        BO.UtileriasBO.LogSeguimiento("Enviando Archivo : " + item.Ruta, " a TIENDA: " + tienda.TiendaS);

                        string[] directoryToPath = item.Ruta.Split('/');
                        string directoryToCopy = dRaiz;

                        //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                        for (int i = 0; i < directoryToPath.Length; i++)
                        {
                            if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                            {
                                directoryToCopy += @"\" + directoryToPath[i].Trim();
                                if (!Directory.Exists(directoryToCopy))
                                    Directory.CreateDirectory(directoryToCopy);
                            }
                        }

                        directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();

                        //Preguntamos si el archivo que vamos a transmitir existe en el directorio local
                        if (!File.Exists(directoryToCopy))
                            throw new Exception("El archivo: " + directoryToCopy + " No existe en el equipo local, favor de avisar a sistemas");

                        //  try
                        //  {
                        //    RemovalOperationResult operatonRemove;
                        //    operatonRemove = session.RemoveFiles(item.Ruta);
                        //    operatonRemove.Check();
                        //  }
                        //  catch { }


                        //Aqui realizamos la descarga del archivo
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        transferOptions.FilePermissions = new FilePermissions { Octal = "775" };

                        TransferOperationResult transferResult;
                        //Probamos la funcion enviando el archivo al directorio temporal
                        //transferResult = session.PutFiles(directoryToCopy, "/tmp/" + directoryToPath[directoryToPath.Length - 1].Trim(), false, transferOptions);
                        transferResult = session.PutFiles(directoryToCopy, item.Ruta, false, transferOptions);

                        transferResult.Check();

                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                        }
                        tienda.ArchivosEnviados++;
                        item.MD5 = item.MD5Produccion;

                        BO.UtileriasBO.LogSeguimiento("Archivo Enviado: " + item.Ruta, " a TIENDA: " + tienda.TiendaS);
                    }
                }
            }
            catch (Exception ex)
            {
                BO.UtileriasBO.LogSeguimiento("Error al enviar los Archivos a TIENDA ", tienda.TiendaS + " ERROR: " + ex.Message);
                tienda.ArchivosEnviados = tienda.ArchivosTiendaDetalle.Count;
                BO.UtileriasBO.Log(tienda.Tienda.ToString() + " - " + tienda.Ip + " - " + ex.Message, "uploadFileFromArchivoTienda");
            }
        }

        #endregion

        public static void EndTask(string taskname)
        {
            string processName = taskname;
            string fixstring = taskname.Replace(".exe", "");

            if (taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(fixstring))
                {
                    process.Kill();
                }
            }
            else if (!taskname.Contains(".exe"))
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
        }

        
    }
}

