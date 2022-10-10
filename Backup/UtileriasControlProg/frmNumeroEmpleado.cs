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
            if (Entity.Configuracion.numeroEmpleadosValidos.Find(x => (x == NumEmpleado)) > 0)
            {
                Entity.Configuracion.NumeroDeEmpleado = NumEmpleado;
                if (Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress())) != null
                    && Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress())) != string.Empty)
                {
                    Entity.Configuracion.IP = Entity.Configuracion.ipsAutorizadas.Find(x => x.Equals(GetLocalIPAddress()));
                    EmpleadoValido = true;
                    this.Close();
                    
                }
                else {
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
