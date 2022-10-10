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
            //try
            //{

            //    UtileriasControlProg.UI.Implementacion.ProgramadorEnvios.EnviosComponentes frm = new UtileriasControlProg.UI.Implementacion.ProgramadorEnvios.EnviosComponentes();
            //    frm.MdiParent = this;
            //    frm.StartPosition = FormStartPosition.Manual;
            //    frm.Location = new Point((this.ClientSize.Width - frm.Width) / 2,
            //           (this.ClientSize.Height - frm.Height) / 2);
            //    frm.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al instanciar el menu: Envios Componentes, Error: " + ex.Message);
            //}
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

    }

}
