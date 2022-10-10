using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasControlProg.Entity;

namespace UtileriasControlProg.UI.Implementacion
{
    public partial class frmDetalleArchivoBase : Form
    {
        public frmDetalleArchivoBase()
        {
            InitializeComponent();
        }

        private void frmDetalleArchivoBase_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Configuracion.ArchivosTiendaDetalleServidorBase;
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].Visible = false;
            dataGridView1.Columns[dataGridView1.Columns.Count - 2].Visible = false;
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Refresh();
        }
    }
}
