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

namespace UtileriasControlProg.UI.Implementacion.ProgramadorEnvios
{
    public partial class EnviosComponentes : Form
    {
        #region Propiedades
        #endregion

        #region Constructores
        public EnviosComponentes()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        #endregion

        #region Metodos

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

        #endregion

        private void btnExaminar_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            openFileDialog1.FileName = null;
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != null && openFileDialog1.FileName != string.Empty)
            {
                txtArchivo.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo");
            }
        }

        private void rdTipoTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTipoTienda.Checked)
            {
                rdDestinoUna.Text = "Por Tienda";
                rdDestinoVarias.Text = "Por Tiendas";
                rdDestinoRango.Text = "Por Rango [300]";
                rdDestinoTodas.Text = "Todas las Tiendas";
                lblProgramarEnvio.Text = "Programar Envio a Tiendas";
            }
        }

        private void rdTipoBR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTipoBR.Checked)
            {
                rdDestinoUna.Text = "Por Bodega";
                rdDestinoVarias.Text = "Por Bodegas";
                rdDestinoRango.Text = "Por Rango";
                rdDestinoTodas.Text = "Todas las BR";
                lblProgramarEnvio.Text = "Programar Envio a BR";
            }
        }

        private void rdTipoBM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTipoBM.Checked)
            {
                rdDestinoUna.Text = "Por Bodega";
                rdDestinoVarias.Text = "Por Bodegas";
                rdDestinoRango.Text = "Por Rango";
                rdDestinoTodas.Text = "Todas las BM";
                lblProgramarEnvio.Text = "Programar Envio a BM";
            }
        }

        private void rdDestinoUna_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDestinoUna.Checked)
            {
                lblTiendas.Text = "Ingresa el numero";

                txtDestinos.Text = "";
                txtDestinos.Visible = true;


                label1.Visible = true;
                txtExcepciones.Text = "";
                txtExcepciones.Visible = true;

                txtPorIp.Text = "";
                txtPorIp.Visible = false;
            }
        }

        private void rdDestinoVarias_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDestinoVarias.Checked)
            {
                lblTiendas.Text = "Ingresa los numeros separados por (,) coma";

                txtDestinos.Text = "";
                txtDestinos.Visible = true;


                label1.Visible = true;
                txtExcepciones.Text = "";
                txtExcepciones.Visible = true;

                txtPorIp.Text = "";
                txtPorIp.Visible = false;
            }
        }

        private void rdDestinoRango_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDestinoRango.Checked)
            {
                lblTiendas.Text = "Ingresa el rango separado por (-)";

                txtDestinos.Text = "";
                txtDestinos.Visible = true;


                label1.Visible = true;
                txtExcepciones.Text = "";
                txtExcepciones.Visible = true;

                txtPorIp.Text = "";
                txtPorIp.Visible = false;

            }
        }

        private void rdDestinoTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDestinoTodas.Checked)
            {
                lblTiendas.Text = "Se van a enviar a todos";

                txtDestinos.Text = "";
                txtDestinos.Visible = false;


                label1.Visible = true;
                txtExcepciones.Text = "";
                txtExcepciones.Visible = true;

                txtPorIp.Text = "";
                txtPorIp.Visible = false;
            }
        }

        private void rdDestinoPorIp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDestinoPorIp.Checked)
            {

                lblTiendas.Text = "IP del servidor";

                txtDestinos.Text = "";
                txtDestinos.Visible = false;


                label1.Visible = false;
                txtExcepciones.Text = "";
                txtExcepciones.Visible = false;

                txtPorIp.Text = "";
                txtPorIp.Visible = true;
            }
        }

        private void btnProgramarEnvio_Click(object sender, EventArgs e)
        {

        }

        private void EnviosComponentes_Load(object sender, EventArgs e)
        {

        }

        private void lblProgramarEnvio_Click(object sender, EventArgs e)
        {

        }

    }
}
