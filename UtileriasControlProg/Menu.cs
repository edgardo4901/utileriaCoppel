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

        private void revisorVersionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                UtileriasControlProg.UI.Implementacion.frmRevisorVersiones frmRevisor = new UtileriasControlProg.UI.Implementacion.frmRevisorVersiones();
                frmRevisor.MdiParent = this;
                frmRevisor.StartPosition = FormStartPosition.Manual;
                frmRevisor.Location = new Point((this.ClientSize.Width - frmRevisor.Width) / 2,
                       (this.ClientSize.Height - frmRevisor.Height) / 2);
                frmRevisor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al instanciar el menu: Revisor versiones, Error: " + ex.Message);
            }
        }

        private void programacionDeEnviosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                UtileriasControlProg.UI.Implementacion.MonitorDeEnlace.frmMonitorDeEnlace frmRevisor = new UtileriasControlProg.UI.Implementacion.MonitorDeEnlace.frmMonitorDeEnlace();
                frmRevisor.MdiParent = this;
                frmRevisor.StartPosition = FormStartPosition.CenterParent;
                frmRevisor.WindowState = FormWindowState.Maximized;
                //frmRevisor.Location = new Point((this.ClientSize.Width - frmRevisor.Width) / 2,
                       //(this.ClientSize.Height - frmRevisor.Height) / 2);
                frmRevisor.Show();
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
            
        }

        private void PermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Entity.Configuracion.numeroEmpleadosAdministrador.Find(x => (x == Entity.Configuracion.NumeroDeEmpleado)) > 0)
            {
                try
                {

                    UtileriasControlProg.UI.Administrador.frmPermisos frmRevisor = new UtileriasControlProg.UI.Administrador.frmPermisos();
                    frmRevisor.MdiParent = this;
                    frmRevisor.StartPosition = FormStartPosition.Manual;
                    frmRevisor.Location = new Point((this.ClientSize.Width - frmRevisor.Width) / 2,
                           (this.ClientSize.Height - frmRevisor.Height) / 2);
                    frmRevisor.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al instanciar el menu: Alta de permisos, Error: " + ex.Message);
                }
            }
        }
    }

}
