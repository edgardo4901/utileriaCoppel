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

namespace UtileriasControlProg.UI.Implementacion
{
    public partial class frmServidorBase : Form
    {
        private ServidorBase serverbase = null;
        private int tipoServidor = 0;


        public frmServidorBase(ServidorBase serverbase, int tipoServidor)
        {
            this.serverbase = serverbase;
            this.tipoServidor = tipoServidor;
            InitializeComponent();
        }

        private void frmServidorBase_Load(object sender, EventArgs e)
        {
            txtIp.Text = serverbase.ip;
            txtUsuario.Text = serverbase.usuario;
            txtPassword.Text = serverbase.password;

            switch (tipoServidor)
            {
                case (int)TipoServidor.Tienda:
                    lblTipoCambio.Text = "Modificar servidor base de TIENDA";
                    break;
                case (int)TipoServidor.BodegaRopa:
                    lblTipoCambio.Text = "Modificar servidor base de BR";
                    break;
                case (int)TipoServidor.BodegaMuebles:
                    lblTipoCambio.Text = "Modificar servidor base de BM";
                    break;
                default:
                    break;
            }
        }

        public void GuardarDatos()
        {

            try
            {
                if (validaDatos())
                {
                    var confirmResult = MessageBox.Show("¿Desea guardar los cambios en el sistema?", "Confirmar", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        serverbase.ip = txtIp.Text;
                        serverbase.usuario = txtUsuario.Text;
                        serverbase.password = txtPassword.Text;
                        UtileriasBO.createFileServerBase(tipoServidor, serverbase);

                        MessageBox.Show("Datos guardados correctamente");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar guardar los datos del servidor base: " + ex.Message);
            }
        }

        private bool validaDatos()
        {
            if (txtIp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe capturar la ip del servidor");
                txtIp.Focus();
                return false;
            }

            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe capturar el usuario");
                txtUsuario.Focus();
                return false;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe capturar el password");
                txtPassword.Focus();
                return false;
            }

            //Valida que el servidor tenga conexion
            if (!BO.CFtp.esServidorValido(txtIp.Text.Trim(), txtUsuario.Text.Trim(), txtPassword.Text.Trim()))
            {
                MessageBox.Show("El servidor capturado no es valido");
                txtIp.Focus();
                return false;
            }

            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

    
    }
}
