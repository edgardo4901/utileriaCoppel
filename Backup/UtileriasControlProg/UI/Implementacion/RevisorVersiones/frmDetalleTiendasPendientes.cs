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
    public partial class frmDetalleTiendasPendientes : Form
    {
        DataTable table = new DataTable();

        public int TiendaLiberar = 0;
        public int TiendasEncontradas = 0;

        public frmDetalleTiendasPendientes(ref List<ArchivosTienda> tiendasBusqueda)
        {
            table.Columns.Add("Tienda", typeof(int));
            table.Columns.Add("Modulos", typeof(int));
            table.Columns.Add("Revisados", typeof(int));

            var items = tiendasBusqueda.FindAll(x => x.EstatusHilo == 0);

            foreach (var item in items) {
                DataRow row = table.NewRow();
                row["Tienda"] = item.Tienda;
                row["Modulos"] = item.Modulos;
                row["Revisados"] = item.ArchivosObtenidos;
                table.Rows.Add(row);
                TiendasEncontradas++;
            }

            InitializeComponent();
        }

        private void frmDetalleTiendasPendientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
            dataGridView1.Refresh();
        }

        private void btnInterrumpir_Click(object sender, EventArgs e)
        {

            if (TiendasEncontradas > 0)
            {
                var confirmResult = MessageBox.Show("¿Desea cancelar la ejecucion del hilo: " + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Tienda"].Value.ToString() + "?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    TiendaLiberar = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Tienda"].Value;
                    this.Close();
                }
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
