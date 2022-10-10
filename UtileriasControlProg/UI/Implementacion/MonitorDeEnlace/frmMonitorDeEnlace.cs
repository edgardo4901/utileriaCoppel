using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UtileriasControlProg.Entity;


namespace UtileriasControlProg.UI.Implementacion.MonitorDeEnlace
{
    public partial class frmMonitorDeEnlace : Form
    {
        private List<Entity.Monitor> monitorEnlace = new List<Entity.Monitor>();
        private List<ArchivosTienda> tiendasBusqueda = new List<ArchivosTienda>();
        private List<Entity.Tiendas> tiendasPrincipal = new List<UtileriasControlProg.Entity.Tiendas>();

        public frmMonitorDeEnlace()
        {
            InitializeComponent();
        }
        private void BtnIniciarEjecucion_Click(object sender, EventArgs e)
        {
            btnIniciarEjecucion.Enabled = false;
            tiendasBusqueda = new List<ArchivosTienda>();
            monitorEnlace = new List<Entity.Monitor>();
            if (inicializaFiltroDeBusqueda())
            {
                foreach (ArchivosTienda tda in tiendasBusqueda)
                {
                    var tienda = tda;
                    if (monitorEnlace.Find(x => x.Monitor1.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor2.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor3.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor4.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor5.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor6.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor7.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor8.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor9.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor10.Equals(tda.TiendaS)) == null &&
                        monitorEnlace.Find(x => x.Monitor11.Equals(tda.TiendaS)) == null)
                    {
                        agregarItemMonitor(ref tienda);
                    }
                }
                prepararDataGrid();
                new Thread(() => ejecutaHilos()).Start();
            }
        }

        public void prepararDataGrid() {

            if (DataGridViewTiendas.DataSource != null)
            {
                DataGridViewTiendas.DataSource = null;
                DataGridViewTiendas.Rows.Clear();
                DataGridViewTiendas.Columns.Clear();
                DataGridViewTiendas.Refresh();
            }
            DataGridViewTiendas.RowTemplate.Height = 50;
            DataGridViewTiendas.DataSource = UtileriasControlProg.BO.UtileriasBO.toDataTable(monitorEnlace);
            actualizarColoresCelda();
            foreach (DataGridViewColumn c in DataGridViewTiendas.Columns)
                if (c.Index != 0) c.ReadOnly = true;

            DataGridViewTiendas.Refresh();


        }

        public void ejecutaHilos() {           
            foreach (ArchivosTienda tda in tiendasBusqueda)
            {
                var tienda = tda;
                if (tienda.EstatusHilo == 0) {
                    tienda.EstatusHilo = 1;
                    new Thread(() => monitorearEnlace(ref tienda)).Start();
                    
                }
            }
                
        }

        public void actualizarColoresCelda() {

            for (int i = 0; i < DataGridViewTiendas.Rows.Count; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (DataGridViewTiendas.Rows[i].Cells[j].Value.ToString().Trim().Length > 0)
                    {
                        var tienda = tiendasBusqueda.Find(x => x.Modulos == i && x.ModulosFaltantes == j);
                        if (tienda != null) {
                            if (tienda.EstatusConexion == "RED")
                            {
                                DataGridViewTiendas.Rows[i].Cells[j].Style.BackColor = Color.Red;
                                DataGridViewTiendas.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                DataGridViewTiendas.Rows[i].Cells[j].Style.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                                DataGridViewTiendas.Rows[i].Cells[j].Style.ForeColor = Color.White;
                            }
                            else {
                                DataGridViewTiendas.Rows[i].Cells[j].Style.BackColor = Color.Green;
                                DataGridViewTiendas.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                DataGridViewTiendas.Rows[i].Cells[j].Style.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                                DataGridViewTiendas.Rows[i].Cells[j].Style.ForeColor = Color.White;
                            }
                        }
                    }
                }
               
            }

        }


        public void agregarItemMonitor(ref ArchivosTienda tda)
        {
            int col = 0;
            int reg = 0;
            bool primeraVez = true;
            bool disponibilidad = false;
            foreach (Entity.Monitor monitor in monitorEnlace)
            {
                if (primeraVez)
                {
                    reg = 0;
                    primeraVez = false;
                }
                else
                {
                    reg++;
                }
                if (monitor.Monitor1 == null || monitor.Monitor1.Equals(""))
                {
                    col = 0;
                    disponibilidad = true;
                    monitor.Monitor1 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor2 == null || monitor.Monitor2.Equals(""))
                {
                    col = 1;
                    disponibilidad = true;
                    monitor.Monitor2 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor3 == null || monitor.Monitor3.Equals(""))
                {
                    col = 2;
                    disponibilidad = true;
                    monitor.Monitor3 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor4 == null || monitor.Monitor4.Equals(""))
                {
                    col = 3;
                    disponibilidad = true;
                    monitor.Monitor4 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor5 == null || monitor.Monitor5.Equals(""))
                {
                    col = 4;
                    disponibilidad = true;
                    monitor.Monitor5 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor6 == null || monitor.Monitor6.Equals(""))
                {
                    col = 5;
                    disponibilidad = true;
                    monitor.Monitor6 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor7 == null || monitor.Monitor7.Equals(""))
                {
                    col = 6;
                    disponibilidad = true;
                    monitor.Monitor7 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor8 == null || monitor.Monitor8.Equals(""))
                {
                    col = 7;
                    disponibilidad = true;
                    monitor.Monitor8 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor9 == null || monitor.Monitor9.Equals(""))
                {
                    col = 8;
                    disponibilidad = true;
                    monitor.Monitor9 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor10 == null || monitor.Monitor10.Equals(""))
                {
                    col = 9;
                    disponibilidad = true;
                    monitor.Monitor10 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }
                else if (monitor.Monitor11 == null || monitor.Monitor11.Equals(""))
                {
                    col = 10;
                    disponibilidad = true;
                    monitor.Monitor11 = tda.TiendaS;
                    tda.Modulos = reg;
                    tda.ModulosFaltantes = col;
                }

            }
            if (!disponibilidad) {
                if (!primeraVez)
                {
                    reg++;
                    col = 0;
                }
                monitorEnlace.Add(new Entity.Monitor() { Monitor1 = tda.TiendaS, Monitor2 = "", Monitor3 = "", Monitor4 = "", Monitor5 = "", Monitor6 = "", Monitor7 = "", Monitor8 = "", Monitor9 = "", Monitor10 = "", Monitor11 = "" });
                tda.Modulos = reg;
                tda.ModulosFaltantes = col;
            }
            
        }

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
                        if (tiendasBusqueda.Find(x => x.TiendaS.Equals("TDA: "+tienda.Tienda)) == null) {
                            ArchivosTienda tda = new ArchivosTienda();
                            tda.EstatusConexion = "RED";
                            tda.Tienda = int.Parse(tienda.Tienda);
                            tda.TiendaS = "TDA: " + tienda.Tienda;
                            tda.Ip = tienda.IPservidorlocal;
                            tiendasBusqueda.Add(tda);
                        }
                    }

                    if (chkSoporte.Checked)
                    {
                        if (tiendasBusqueda.Find(x => x.TiendaS.Equals("SOP: "+tienda.Tienda)) == null)
                        {
                            ArchivosTienda tda = new ArchivosTienda();
                            tda.EstatusConexion = "RED";
                            tda.Tienda = int.Parse(tienda.Tienda);
                            tda.TiendaS = "SOP: " + tienda.Tienda;
                            tda.Ip = tienda.IPservidorSoporte;
                            tiendasBusqueda.Add(tda);
                        }
                            
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

        private void RdPorTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorTienda.Checked)
            {
                lblTiendas.Text = "Ingresa el numero de tienda";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
               

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }
        }

        private void RdPorTiendas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorTiendas.Checked)
            {
                lblTiendas.Text = "Ingresa las tiendas separas por (,) coma";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
                

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }
        }

        private void RdPorRangoTiendas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPorRangoTiendas.Checked)
            {
                lblTiendas.Text = "Ingresa el rango de tiendas separados por (-)";
                txtTiendas.Text = "";
                txtTiendas.Enabled = true;
                txtTiendas.Visible = true;
                

                label1.Visible = true;
                txtTiendasExcepcion.Visible = true;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = false;
                txtIPServer.Visible = false;
            }

        }

        private void RdFiltroPorIP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFiltroPorIP.Checked)
            {
                lblTiendas.Text = "IP del servidor a consultar";
                txtTiendas.Text = "";
                txtTiendas.Enabled = false;
                txtTiendas.Visible = false;
                

                label1.Visible = false;
                txtTiendasExcepcion.Visible = false;
                txtTiendasExcepcion.Text = "";

                txtIPServer.Text = "";
                txtIPServer.Enabled = true;
                txtIPServer.Visible = true;
            }
        }

     

        public void monitorearEnlace(ref ArchivosTienda tda)
        {
            if (tda.EstatusHilo == 1 && tda.KillThread == 0) {

                Ping pingSender = new Ping();
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                // Wait 10 seconds for a reply.
                int timeout = 1000;
                // Set options for transmission:
                // The data can go through 64 gateways or routers
                // before it is destroyed, and the data packet
                // cannot be fragmented.
                PingOptions options = new PingOptions(64, true);

                int respuestas = 0;
                bool mostroNotificacion = false;
                while (tda.KillThread == 0) {
                    
                    try {
                        PingReply reply = pingSender.Send(tda.Ip, timeout, buffer, options);

                        if (reply.Status == IPStatus.Success)
                        {
                            respuestas++;
                            tda.EstatusConexion = "GREEN";
                            int i = tda.Modulos;
                            int j = tda.ModulosFaltantes;
                            DataGridViewTiendas.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            if (respuestas >= 15 && !mostroNotificacion) {
                                notifyIcon1.ShowBalloonTip(5000, "Conexión recuperada", "Se ha recuperado un nuevo enlace favor de verificar el monitor", ToolTipIcon.Info);
                                respuestas = 0;
                                mostroNotificacion = true;
                            }                            
                            /*
                            Console.WriteLine("Address: {0}", reply.Address.ToString());
                            Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                            Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                            Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                            Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                            */

                        }
                        else
                        {
                            tda.EstatusConexion = "RED";
                            int i = tda.Modulos;
                            int j = tda.ModulosFaltantes;
                            DataGridViewTiendas.Rows[i].Cells[j].Style.BackColor = Color.Red;
                            respuestas = 0;
                            ///Console.WriteLine(reply.Status);
                        }
                    }
                    catch (Exception ex) {
                        tda.EstatusConexion = "RED";
                        int i = tda.Modulos;
                        int j = tda.ModulosFaltantes;
                        DataGridViewTiendas.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        respuestas = 0;
                        //Console.WriteLine(ex.Message);
                    }
                    //Thread.Sleep(2000);
                }
                tda.EstatusHilo = 0;
            }
        }

        private void DataGridViewTiendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.RowIndex.ToString() + "-" +e.ColumnIndex.ToString());
        }

        private void FrmMonitorDeEnlace_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            //Apagamos todos los hilos
            foreach (ArchivosTienda tda in tiendasBusqueda)
            {                
                tda.KillThread = 1;
            }

            //Verificamos que ya no existan hilos activos
            while (tiendasBusqueda.FindAll(x => x.EstatusHilo == 1).Count > 0)
            {
                Thread.Sleep(1000);
            }

            btnIniciarEjecucion.Enabled = true;
        }
    }
}
