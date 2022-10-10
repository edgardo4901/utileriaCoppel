using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UtileriasControlProg.Entity;
using System.IO;

namespace UtileriasControlProg.UI.Implementacion
{
    public partial class frmDetalleArchivoComparacion : Form
    {
        private ArchivosTienda archivosTienda;

        public frmDetalleArchivoComparacion(ArchivosTienda archivosTienda)
        {
            this.archivosTienda = archivosTienda;
            InitializeComponent();
        }

        private void frmDetalleArchivoComparacion_Load(object sender, EventArgs e)
        {
            lblTotalTiendasRevisadas.Text = "Detalle de archivos de la tienda: " + archivosTienda.TiendaS.ToString() + " IP: " + archivosTienda.Ip;
            AplicarFiltro(3);
        }

        private void AplicarFiltro(int filtro)
        {
            List<ArchivosTiendaDetalle> Filtros = new List<ArchivosTiendaDetalle>();

            //Filtrar todos los elementos
            if (filtro == 1)
            {
                Filtros = archivosTienda.ArchivosTiendaDetalle;
            }

            //Filtrar archivos iguales
            if (filtro == 2)
            {
                Filtros = archivosTienda.ArchivosTiendaDetalle.FindAll(x => x.MD5.ToUpper().Trim().Equals(x.MD5Produccion.Trim().ToUpper()));
            }

            //Filtrar archivos con diferencias
            if (filtro == 3)
            {
                Filtros = archivosTienda.ArchivosTiendaDetalle.FindAll(x => !x.MD5.ToUpper().Trim().Equals(x.MD5Produccion.Trim().ToUpper()));
            }

            MostrarInformacion(Filtros);
        }


        public void MostrarInformacion(List<ArchivosTiendaDetalle> detalle)
        {

            DataTable table = new DataTable();
            table.Columns.Add("Ruta", typeof(string));
            table.Columns.Add("Modulo", typeof(string));
            table.Columns.Add("MD5 Produccion", typeof(string));
            table.Columns.Add("MD5 Tienda", typeof(string));

            foreach (var item in detalle)
            {
                DataRow row = table.NewRow();
                row["Ruta"] = item.Ruta;
                row["Modulo"] = item.Modulo;
                row["MD5 Produccion"] = item.MD5Produccion;
                row["MD5 Tienda"] = item.MD5;
                table.Rows.Add(row);
            }

            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
            }

            dataGridView1.DataSource = table;

            if (radioButton1.Checked)
            {

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btn);
                btn.HeaderText = "Transmitir";
                btn.Text = "Enviar";
                btn.Name = "btnEnviar";
                btn.UseColumnTextForButtonValue = true;
                btn.FlatStyle = FlatStyle.Popup;
            }


            dataGridView1.AutoResizeColumns();
            dataGridView1.Refresh();
        }

        private void rdTodos_Click(object sender, EventArgs e)
        {
            btnEnviarTodo.Visible = false;
            AplicarFiltro(1);
        }

        private void rdOk_Click(object sender, EventArgs e)
        {
            btnEnviarTodo.Visible = false;
            AplicarFiltro(2);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            btnEnviarTodo.Visible = true;
            AplicarFiltro(3);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dataGridView1.Columns["btnEnviar"] != null)
                    {
                        if (e.ColumnIndex == dataGridView1.Columns["btnEnviar"].Index)
                        {

                            var confirmResult = MessageBox.Show("Se va a realizar el envio del archivo a la tienda ¿Desea continuar?", "Confirmar", MessageBoxButtons.YesNo);
                            if (confirmResult == DialogResult.Yes)
                            {
                                List<string> FilesDownload = new List<string>();

                                string rutaFile = dataGridView1.Rows[e.RowIndex].Cells["Ruta"].Value.ToString();
                                string MD5Produccion = dataGridView1.Rows[e.RowIndex].Cells["MD5 Produccion"].Value.ToString().ToUpper().Trim();


                                if (!ExisteArchivoLocal(rutaFile))
                                {
                                    FilesDownload.Add(rutaFile);
                                }
                                else
                                {
                                    //Revisamos el MD5 del archivo local contra el MD5 de produccion para decidir si descargamos el archivo o no
                                    string MD5Local = ObtenerMD5Local(rutaFile);
                                    if (!MD5Produccion.Equals(MD5Local))
                                    {
                                        FilesDownload.Add(rutaFile);
                                    }
                                }

                                //Preguntamos si es necesario descargar el archivo a la maquina local
                                if (FilesDownload.Count > 0)
                                {
                                    BO.CFtp.getFileFromProduccion(ServidorBaseConfiguracion.ip, FilesDownload);
                                }


                                List<string> filesToUpload = new List<string>();
                                filesToUpload.Add(rutaFile);
                                BO.CFtp.uploadFileFromLocal(archivosTienda.Ip, filesToUpload);


                                archivosTienda.ArchivosTiendaDetalle.Find(x => x.Ruta.Equals(rutaFile)).MD5 = MD5Produccion;
                                MessageBox.Show("Termine");
                                frmRevisorVersiones.EndTask("WinSCP");
                                AplicarFiltro(3);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar enviar, Error: " + ex.Message);
                frmRevisorVersiones.EndTask("WinSCP");
            }
        }

        private string PreparaDirectorioLocal(string item)
        {
            //Preparamos el directorio raiz
            string dRaiz = @"C:\UtileriasControlProg";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\RevisorVersiones";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            dRaiz += @"\Files";
            if (!Directory.Exists(dRaiz))
                Directory.CreateDirectory(dRaiz);

            string[] directoryToPath = item.Split('/');
            string directoryToCopy = dRaiz;

            //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
            for (int i = 0; i < directoryToPath.Length; i++)
            {
                if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                {
                    directoryToCopy += @"\" + directoryToPath[i].Trim();
                    if (!Directory.Exists(directoryToCopy))
                        Directory.CreateDirectory(directoryToCopy);
                }
            }

            directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();
            return directoryToCopy;
        }

        private bool ExisteArchivoLocal(string item)
        {
            string directoryToCopy = PreparaDirectorioLocal(item);

            //En caso de que el archivo haya sido descargado previamente lo borramos de la ruta local de la maquina
            if (File.Exists(directoryToCopy))
                return true;
            else
                return false;

        }

        private string ObtenerMD5Local(string item)
        {
            string directoryToCopy = PreparaDirectorioLocal(item);
            string MD5Local = BO.CMd5.getMd5(directoryToCopy);
            return MD5Local.ToUpper().Trim(); ;
        }

        private void btnEnviarTodo_Click(object sender, EventArgs e)
        {
            try
            {

                var confirmResult = MessageBox.Show("¿Desea enviar todos los archivos al servidor de la tienda?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    btnEnviarTodo.Enabled = false;

                    List<string> FilesDownload = new List<string>();
                    List<string> filesToUpload = new List<string>();


                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["Ruta"] != null && dataGridView1.Rows[i].Cells["Ruta"].Value != null && dataGridView1.Rows[i].Cells["Ruta"].Value.ToString().Length > 0)
                        {
                            string rutaFile = dataGridView1.Rows[i].Cells["Ruta"].Value.ToString();
                            string MD5Produccion = dataGridView1.Rows[i].Cells["MD5 Produccion"].Value.ToString().ToUpper().Trim();

                            if (!ExisteArchivoLocal(rutaFile))
                            {
                                FilesDownload.Add(rutaFile);
                            }
                            else
                            {
                                //Revisamos el MD5 del archivo local contra el MD5 de produccion para decidir si descargamos el archivo o no
                                string MD5Local = ObtenerMD5Local(rutaFile);
                                if (!MD5Produccion.Equals(MD5Local))
                                {
                                    FilesDownload.Add(rutaFile);
                                }
                            }
                            filesToUpload.Add(rutaFile);
                            archivosTienda.ArchivosTiendaDetalle.Find(x => x.Ruta.Equals(rutaFile)).MD5 = MD5Produccion;
                        }
                    }

                    //Preguntamos si es necesario descargar el archivo a la maquina local
                    if (FilesDownload.Count > 0)
                    {
                        BO.CFtp.getFileFromProduccion(ServidorBaseConfiguracion.ip, FilesDownload);
                    }

                    BO.CFtp.uploadFileFromLocal(archivosTienda.Ip, filesToUpload);

                    MessageBox.Show("Termine");
                    frmRevisorVersiones.EndTask("WinSCP");
                    AplicarFiltro(3);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar enviar, Error: " + ex.Message);
                frmRevisorVersiones.EndTask("WinSCP");
            }
        }




    }
}
