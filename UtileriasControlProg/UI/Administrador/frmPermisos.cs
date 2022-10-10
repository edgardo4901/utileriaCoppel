using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UtileriasControlProg.UI.Administrador
{
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Debe capturar el numero de empleado que desea agregar a la herramienta");
                textBox1.Focus();
                return;
            }

            try
            {
                int n = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("El tipo de dato debe ser numerico");
                textBox1.Focus();
                return;
            }

            if (Entity.Configuracion.numeroEmpleadosAdministrador.Find(x => (x == Entity.Configuracion.NumeroDeEmpleado)) > 0)
            {
                int numeroEmpleadoHE = Huella.LlamadoHuella();
                if (Entity.Configuracion.NumeroDeEmpleado != numeroEmpleadoHE)
                {
                    MessageBox.Show("La huella no coincie con la base de datos de personal");
                    textBox1.Focus();
                    return;
                }

                try
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(Entity.Configuracion.fileEmpleado, true);
                    sw.WriteLine(BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingEmpleado + textBox1.Text));
                    sw.Close();
                    sw.Dispose();
                    MessageBox.Show("Empleado agregado correctamente al archivo dat");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al agregar el empleado: " + ex.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Debe capturar la ip que desea agregar a la herramienta");
                textBox2.Focus();
                return;
            }
            
            if (Entity.Configuracion.numeroEmpleadosAdministrador.Find(x => (x == Entity.Configuracion.NumeroDeEmpleado)) > 0)
            {
                int numeroEmpleadoHE = Huella.LlamadoHuella();
                if (Entity.Configuracion.NumeroDeEmpleado != numeroEmpleadoHE)
                {
                    MessageBox.Show("La huella no coincie con la base de datos de personal");
                    textBox2.Focus();
                    return;
                }

                try
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(Entity.Configuracion.fileIps, true);
                    sw.WriteLine(BO.UtileriasBO.Base64Encode(Entity.Configuracion.encodingIP + textBox2.Text));
                    sw.Close();
                    sw.Dispose();
                    MessageBox.Show("Ip registrada correctamente al archivo dat");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al agregar la ip: " + ex.Message);
                }
            }
        }
    }
}
