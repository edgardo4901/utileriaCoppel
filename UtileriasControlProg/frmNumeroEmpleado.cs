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

namespace UtileriasControlProg
{
    public partial class frmNumeroEmpleado : Form
    {
        public bool EmpleadoValido { get; set; }

        public frmNumeroEmpleado()
        {
            EmpleadoValido = false;
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
                int numeroEmpleadoHE = Huella.LlamadoHuella();
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
                if (!System.IO.File.Exists(Entity.Configuracion.fileIps) && !System.IO.File.Exists(Entity.Configuracion.fileEmpleado))
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
                System.IO.StreamReader sr = new System.IO.StreamReader(Entity.Configuracion.fileEmpleado);
                string line = "";
                while ((line = sr.ReadLine()) != null) {
                    if (line != string.Empty) {
                        string sEmpleado = BO.UtileriasBO.Base64Decode(line);
                        sEmpleado = sEmpleado.Replace(Entity.Configuracion.encodingEmpleado, "");
                        Entity.Configuracion.numeroEmpleadosValidos.Add(int.Parse(sEmpleado.Trim()));
                    }
                }

                sr = new System.IO.StreamReader(Entity.Configuracion.fileIps);
                line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != string.Empty)
                    {
                        string sIP = BO.UtileriasBO.Base64Decode(line);
                        sIP = sIP.Replace(Entity.Configuracion.encodingIP, "");
                        Entity.Configuracion.ipsAutorizadas.Add(sIP.Trim());
                    }
                }

                if (Entity.Configuracion.numeroEmpleadosValidos.Find(x => (x == NumEmpleado)) > 0)
                {
                    int numeroEmpleadoHE = Huella.LlamadoHuella();
                    if (NumEmpleado != numeroEmpleadoHE)
                    {
                        MessageBox.Show("La huella no coincie con la base de datos de personal");
                        textBox1.Focus();
                        return;
                    }
                    Entity.Configuracion.NumeroDeEmpleado = NumEmpleado;
                    if (Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress())) != null
                        && Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress())) != string.Empty)
                    {
                        Entity.Configuracion.IP = Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress()));
                        EmpleadoValido = true;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Esta ip no esta autorizada para utilizar la herramienta");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El numero de empleado no autorizado");
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
