using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace UtileriasControlProg
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void cargarReporteDinamico()
        {
            try
            {

                UtileriasControlProg.UI.Personal.frmReporteDinamico frmReporteDinamico = new UtileriasControlProg.UI.Personal.frmReporteDinamico();
                frmReporteDinamico.MdiParent = this;
                frmReporteDinamico.StartPosition = FormStartPosition.CenterParent;
                frmReporteDinamico.WindowState = FormWindowState.Maximized;
                frmReporteDinamico.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al instanciar el menu: Monitoreo de enlace, Error: " + ex.Message);
            }
        }

        private void programacionDeEnviosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                cargarReporteDinamico();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al instanciar el menu: Monitoreo de enlace, Error: " + ex.Message);
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
            UtileriasControlProg.frmNumeroEmpleado emp = new frmNumeroEmpleado();
            emp.Owner = this;
            emp.StartPosition = FormStartPosition.CenterParent;
            emp.ShowDialog();
            if (!emp.EmpleadoValido)
            {
                this.Close();
            }
            else
            {
                cargarReporteDinamico();
            }
            
        }
    }

}
