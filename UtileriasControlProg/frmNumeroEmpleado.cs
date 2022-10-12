using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using UtileriasControlProg.Entity;
using Newtonsoft.Json;
using UtileriasControlProg.DAL;

namespace UtileriasControlProg
{
    public partial class frmNumeroEmpleado : Form
    {
        public bool EmpleadoValido { get; set; }
        DataTable dtConsulta;
        ConexionSql oConexion;
        string conexion_principal;

        public frmNumeroEmpleado()
        {
            EmpleadoValido = false;
            oConexion = new ConexionSql();
            conexion_principal = oConexion.CreaCadenaConexion();
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
            }

            if (keyData == Keys.Enter)
            {
                validarNumeroEmpleado();
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void validarNumeroEmpleado()
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Capture el numero de empleado");
                textBox1.Focus();
                return;
            }
            int NumEmpleado = Convert.ToInt32(textBox1.Text);
            if (Entity.Configuracion.numeroEmpleadosAdministrador.Find(x => (x == NumEmpleado)) > 0)
            {
                //  Empleado con permisos de administrador puede arrancar la utileria sin validar la ip
                //  Solo validamos la huella con el HE
                //int numeroEmpleadoHE = Huella.LlamadoHuella();
                int numeroEmpleadoHE = NumEmpleado;
                if (NumEmpleado == numeroEmpleadoHE)
                {
                    Entity.Configuracion.NumeroDeEmpleado = NumEmpleado;
                    EmpleadoValido = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La huella no coincie con la base de datos de personal");
                    textBox1.Focus();
                    return;
                }

            }
            else {
                //Validamos si existen los archivos de configuracion de la utileria para obtener los empleados validos y las ips autorizadas
                if (!System.IO.File.Exists(Entity.Configuracion.centros))
                {
                    MessageBox.Show("La herramienta no cuenta con los permisos necesarios para su ejecución, favor de solicitarlos con el encargado de implementación");
                    textBox1.Focus();
                    return;
                }
                /*
                string b64 = BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingEmpleado + "90875664");
                string b62 = BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingEmpleado + "90844974");
                string b63 = BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingEmpleado + "91548462");
                string b65 = BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingIP + GetLocalIPAddress());
                string b66 = BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingIP + "10.43.74.163");
                string s64 = BO.UtileriasBO.Base64Decode(b64);
                */

                string jsonstr = "";
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(Entity.Configuracion.centros);
                while ((line = file.ReadLine()) != null)
                {
                    jsonstr += line;
                }
                file.Close();

                List<CentrosAutorizados> lstcentros = JsonConvert.DeserializeObject<List<CentrosAutorizados>>(jsonstr);

                int NumeroCentro = 0;

                dtConsulta = new DataTable();
                string query = "select centron from SapCatalogoEmpleados where Numemp = " + NumEmpleado;
                dtConsulta = oConexion.ConsultaSqlDataTable(conexion_principal, query, CommandType.Text);
                if (dtConsulta.Rows.Count > 0)
                {
                    NumeroCentro = int.Parse(dtConsulta.Rows[0]["centron"].ToString());
                }

                bool existe = false;

                foreach (CentrosAutorizados element in lstcentros)
                {
                    if (element.Centro == NumeroCentro)
                    {
                        existe = true;
                        Entity.Configuracion.MostrarBloque1 = element.MostrarBloque1;
                        Entity.Configuracion.MostrarBloque2 = element.MostrarBloque2;
                        Entity.Configuracion.MostrarBloque3 = element.MostrarBloque3;
                        Entity.Configuracion.SoloColaboradores = element.SoloColaboradores;
                        break;
                    }
                }
                if (existe)
                {
                    //int numeroEmpleadoHE = Huella.LlamadoHuella();
                    int numeroEmpleadoHE = NumEmpleado;
                    if (NumEmpleado != numeroEmpleadoHE)
                    {
                        MessageBox.Show("La huella no coincie con la base de datos de personal");
                        textBox1.Focus();
                        return;
                    }
                    if(Entity.Configuracion.SoloColaboradores.Trim() != "")
                    {
                        if (!Entity.Configuracion.SoloColaboradores.Contains(numeroEmpleadoHE.ToString()))
                        {
                            Entity.Configuracion.MostrarBloque2 = false;
                            Entity.Configuracion.MostrarBloque3 = false;
                        }
                    }
                    Entity.Configuracion.NumeroDeEmpleado = NumEmpleado;
                    EmpleadoValido = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El numero de empleado no esta autorizado");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
