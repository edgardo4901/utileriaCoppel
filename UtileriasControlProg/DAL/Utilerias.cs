using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Xml;
using System.IO;
using UtileriasControlProg.Entity;
using System.Data;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Windows.Forms;
using iTextSharp.text;

namespace UtileriasControlProg.DAL
{
    public class Utilerias
    {

        public static NpgsqlConnection ObtenerConexionPostgreSQL(string conectionName)
        {
            try
            {

                XmlDocument configuracion = new XmlDocument();
                configuracion.Load(@"Conexion.xml");
                string ip = configuracion.SelectSingleNode("/XmlConfiguracion/PostgreSql[@NombreConexion='" + conectionName + "']").SelectSingleNode("IP").InnerText;
                string usuario = configuracion.SelectSingleNode("/XmlConfiguracion/PostgreSql[@NombreConexion='" + conectionName + "']").SelectSingleNode("User").InnerText;
                string pass = configuracion.SelectSingleNode("/XmlConfiguracion/PostgreSql[@NombreConexion='" + conectionName + "']").SelectSingleNode("Password").InnerText;
                string basedatos = configuracion.SelectSingleNode("/XmlConfiguracion/PostgreSql[@NombreConexion='" + conectionName + "']").SelectSingleNode("Database").InnerText;
                string drivr = configuracion.SelectSingleNode("/XmlConfiguracion/PostgreSql[@NombreConexion='" + conectionName + "']").SelectSingleNode("Driver").InnerText;

                NpgsqlConnection con = new NpgsqlConnection("Server=" + ip + ";Port=5432;Database=" + basedatos + ";User Id=" + usuario + ";Password=" + pass + ";");
                con.Open();
                return con;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool existFileServerBase(int Tipo)
        {
            try
            {
                bool existe = false;
                switch (Tipo)
                {
                    case (int)TipoServidor.Tienda:
                        if (File.Exists(@"ServidorBaseTienda.txt"))
                            existe = true;
                        break;
                    case (int)TipoServidor.BodegaRopa:
                        if (File.Exists(@"ServidorBaseBR.txt"))
                            existe = true;
                        break;
                    case (int)TipoServidor.BodegaMuebles:
                        if (File.Exists(@"ServidorBaseBM.txt"))
                            existe = true;
                        break;
                    default:
                        break;
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void createFileServerBase(int Tipo, ServidorBase servidor)
        {
            try
            {
                string nomFile = "";
                switch (Tipo)
                {
                    case (int)TipoServidor.Tienda:
                        nomFile = @"ServidorBaseTienda.txt";
                        break;
                    case (int)TipoServidor.BodegaRopa:
                        nomFile = @"ServidorBaseBR.txt";
                        break;
                    case (int)TipoServidor.BodegaMuebles:
                        nomFile = @"ServidorBaseBM.txt";
                        break;
                    default:
                        break;
                }

                using (StreamWriter sw = new StreamWriter(nomFile))
                {
                    sw.WriteLine(servidor.ip);
                    sw.WriteLine(servidor.usuario);
                    sw.WriteLine(servidor.password);
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar archivo de servidor base: " + ex.Message);
            }
        }
        public static ServidorBase getDataServerBase(int Tipo)
        {

            try
            {
                List<string> fileData = new List<string>();

                string nomFile = "";
                switch (Tipo)
                {
                    case (int)TipoServidor.Tienda:
                        nomFile = @"ServidorBaseTienda.txt";
                        break;
                    case (int)TipoServidor.BodegaRopa:
                        nomFile = @"ServidorBaseBR.txt";
                        break;
                    case (int)TipoServidor.BodegaMuebles:
                        nomFile = @"ServidorBaseBM.txt";
                        break;
                    default:
                        break;
                }

                string line = "";
                StreamReader file = new StreamReader(nomFile);
                while ((line = file.ReadLine()) != null)
                {
                    fileData.Add(line);
                }
                file.Close();

                ServidorBase servidor = new ServidorBase();
                servidor.ip = fileData[0];
                servidor.usuario = fileData[1];
                servidor.password = fileData[2];

                return servidor;

            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }


        public static string GenerarReporteExcel(string NombreReporte, string titulo, string subTitulo, DataTable dtDatos)
        {
            string RutaReporte = @"C:\ReportesUtilerias\";
            string RutaRuta = @"C:\ReportesUtilerias";
            RutaReporte += NombreReporte;

            //si no existe carpeta la crea
            try
            {
                if (!Directory.Exists(RutaRuta))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(RutaRuta);
                }

                int iRenglonTitulo = 1, iRenglonEncabezado = 3, iRenglonFila = 5;
                Document objDocumento = new Document(PageSize.A4, 15, 15, 20, 10);

                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "ReportesCoppel";
                    p.Workbook.Properties.Title = "Reportes Coppel";
                    p.Workbook.Properties.Company = "Coppel S.A de C.V.";

                    /*SE AGREGA UNA NUEVA HOJA*/
                    p.Workbook.Worksheets.Add("ReporteDinamico");
                    ExcelWorksheet ws = p.Workbook.Worksheets[1];
                    ws.Name = "Hoja 1";

                    try
                    {

                        /*SE IMPRIME TITULO*/
                        var cell_encabezado0 = ws.Cells["A" + iRenglonTitulo];
                        cell_encabezado0.Value = titulo + "  " + subTitulo;
                        cell_encabezado0.Style.Font.Bold = true;
                        cell_encabezado0.Style.Font.Size = 12;
                        using (ExcelRange r = ws.Cells["A" + iRenglonTitulo + ":I" + iRenglonTitulo])
                        {
                            r.Merge = true;
                            r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        }

                        int contador = 1;
                        foreach (DataColumn column in dtDatos.Columns)
                        {
                            Console.Write(column.ColumnName);
                            var cell_encabezado = ws.Cells[regresarCelda(contador) + iRenglonEncabezado];
                            cell_encabezado.Value = column.ColumnName;
                            cell_encabezado.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cell_encabezado.Worksheet.Column(contador + 1).Width = 35;
                            contador++;
                        }

                        foreach (DataRow row in dtDatos.Rows)
                        {
                            contador = 1;
                            foreach (DataColumn column in row.Table.Columns)
                            {
                                var cell_dato1 = ws.Cells[regresarCelda(contador) + (iRenglonFila)];//cantidad 1
                                cell_dato1.Value = row[column.ColumnName];
                                cell_dato1.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell_dato1.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell_dato1.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                cell_dato1.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                //cell_dato1.Style.Numberformat.Format = "  ";
                                cell_dato1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                                contador++;
                            }
                            iRenglonFila++;
                        }


                    }//FIN FOR QUE IMPRIME LAS 5 TABLAS
                     //}
                    catch (OutOfMemoryException)
                    {
                        //MessageBox.Show("Error en ejecutar ");
                        GenerarReporteExcel(titulo, subTitulo, NombreReporte, dtDatos);
                    }

                    /*se guarda el archivo creado*/
                    string sNombreArchivo = (RutaReporte);
                    try
                    {
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(@sNombreArchivo, bin);
                        Application.DoEvents();
                        return "Reporte generado en: " + RutaReporte;
                    }
                    catch (Exception ex)
                    {
                        return "No se pudo generar el reporte, favor de validar que no este siendo utilizado o este abierto";
                    }
                }//fin using
            }
            catch (IOException ioex)
            {
                return "No se pudo generar el reporte, favor de validar que exista la ruta:" + RutaReporte;
            }
        }

        public static string regresarCelda(int contrador)
        {
            string celda = "";
            switch (contrador)
            {
                case 1:
                    celda = "B";
                    break;
                case 2:
                    celda = "C";
                    break;
                case 3:
                    celda = "D";
                    break;
                case 4:
                    celda = "E";
                    break;
                case 5:
                    celda = "F";
                    break;
                case 6:
                    celda = "G";
                    break;
                case 7:
                    celda = "H";
                    break;
                case 8:
                    celda = "I";
                    break;
                case 9:
                    celda = "J";
                    break;
                case 10:
                    celda = "K";
                    break;
                case 11:
                    celda = "L";
                    break;
                case 12:
                    celda = "M";
                    break;
                case 13:
                    celda = "N";
                    break;
                case 14:
                    celda = "O";
                    break;
                case 15:
                    celda = "P";
                    break;
                case 16:
                    celda = "Q";
                    break;
                case 17:
                    celda = "R";
                    break;
                case 18:
                    celda = "S";
                    break;
                case 19:
                    celda = "T";
                    break;
                case 20:
                    celda = "U";
                    break;
                case 21:
                    celda = "V";
                    break;
                case 22:
                    celda = "W";
                    break;
                case 23:
                    celda = "X";
                    break;
                case 24:
                    celda = "Y";
                    break;
                case 25:
                    celda = "Z";
                    break;
                case 26:
                    celda = "AA";
                    break;
                case 27:
                    celda = "AB";
                    break;
                case 28:
                    celda = "AC";
                    break;
                case 29:
                    celda = "AD";
                    break;
                case 30:
                    celda = "AE";
                    break;
                case 31:
                    celda = "AF";
                    break;
                case 32:
                    celda = "AG";
                    break;
                case 33:
                    celda = "AH";
                    break;
                case 34:
                    celda = "AI";
                    break;
                case 35:
                    celda = "AJ";
                    break;
                case 36:
                    celda = "AK";
                    break;
                case 37:
                    celda = "AL";
                    break;
                case 38:
                    celda = "AM";
                    break;
                case 39:
                    celda = "AN";
                    break;
                case 40:
                    celda = "AO";
                    break;
                case 41:
                    celda = "AP";
                    break;
                case 42:
                    celda = "AQ";
                    break;
                case 43:
                    celda = "AR";
                    break;
                case 44:
                    celda = "AS";
                    break;
                case 45:
                    celda = "AT";
                    break;
                case 46:
                    celda = "AU";
                    break;
                case 47:
                    celda = "AV";
                    break;
                case 48:
                    celda = "AW";
                    break;
                case 49:
                    celda = "AX";
                    break;
                case 50:
                    celda = "AY";
                    break;
                case 51:
                    celda = "AZ";
                    break;
                case 52:
                    celda = "BA";
                    break;
                case 53:
                    celda = "BB";
                    break;
                default:
                    celda = "ABC";
                    break;
            }
            return celda;
        }
    }
}
