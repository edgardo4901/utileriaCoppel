using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtileriasControlProg.DAL;
using UtileriasControlProg.Entity;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace UtileriasControlProg.BO
{
    public class UtileriasBO
    {
        public static void createFileServerBase(int Tipo, ServidorBase servidor)
        {
            Utilerias.createFileServerBase(Tipo, servidor);
        }

        public static bool existFileServerBase(int Tipo)
        {
            return Utilerias.existFileServerBase(Tipo);
        }
        public static ServidorBase getFileServerBase(int Tipo)
        {
            return Utilerias.getDataServerBase(Tipo);
        }

        public static void Log(string cadena, string funcion)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("LogUtileriasControlProg.txt", true))
                {
                    sw.WriteLine("==============================================");
                    sw.WriteLine(DateTime.Now.ToString() + " - " + funcion + " - " + cadena);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LogSeguimiento(string evento, string cadena)
        {
            try
            {
                string path = "LogSeguimiento" + DateTime.Today.ToShortDateString().Replace("/", "") + ".txt";
                using (StreamWriter sw = new StreamWriter(path, System.IO.File.Exists(path)))
                {
                    sw.WriteLine(Configuracion.IP + " : " + Configuracion.NumeroDeEmpleado + " : " + DateTime.Now.ToString() + " : " + evento + " : " + cadena);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static DataTable toDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
