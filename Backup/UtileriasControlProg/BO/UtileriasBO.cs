using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtileriasControlProg.DAL;
using UtileriasControlProg.Entity;
using System.IO;

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

    }
}
