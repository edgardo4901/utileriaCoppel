using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Xml;
using System.IO;
using UtileriasControlProg.Entity;

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
    }
}
