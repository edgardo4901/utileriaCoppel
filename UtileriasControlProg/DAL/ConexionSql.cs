using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtileriasControlProg.Entity;

namespace UtileriasControlProg.DAL
{
    public class ConexionSql : Conexion
    {
        public string CreaCadenaConexion()
        {
            try
            {
                EstructuraConexion estructuraConexion = new EstructuraConexion();

                //pruebas
                /*estructuraConexion.IP = "10.44.75.100";
                estructuraConexion.User = "syspruebasadmon";
                estructuraConexion.CtrCo = "1299e3097";
                estructuraConexion.Database = "Personal";*/

                estructuraConexion.IP = "10.44.1.13";
                estructuraConexion.User = "syspersonal";
                estructuraConexion.CtrCo = "d894dab691238a6b66b73b2a94abd3f5";
                estructuraConexion.Database = "Personal";

                if (estructuraConexion != null)
                {
                    return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", estructuraConexion.IP, estructuraConexion.Database, estructuraConexion.User, estructuraConexion.CtrCo);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string CreaCadenaConexionHojaVida()
        {
            try
            {
                EstructuraConexion estructuraConexion = new EstructuraConexion();

                //pruebas
                /*estructuraConexion.IP = "10.44.74.18";
                estructuraConexion.User = "syshojadevida";
                estructuraConexion.CtrCo = "91aeb44eb8010f022c1ed8481b4cc7f9";
                estructuraConexion.Database = "hojadevida";*/

                estructuraConexion.IP = "10.50.2.152";
                estructuraConexion.User = "syshojadevida";
                estructuraConexion.CtrCo = "98bc79c18c7944b3782bb83de6b4ead2";
                estructuraConexion.Database = "hojadevida";

                if (estructuraConexion != null)
                {
                    return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", estructuraConexion.IP, estructuraConexion.Database, estructuraConexion.User, estructuraConexion.CtrCo);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ConsultaSqlDataTable(string ConnectionString, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConexion(ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    try
                    {

                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Conexion: " + ConnectionString);

                        command.CommandTimeout = 0;
                        command.CommandText = commandText;
                        command.CommandType = commandType;
                        if (parameters != null) { command.Parameters.AddRange(parameters); }
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Estableciendo Conexion");
                        connection.Open();
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Conexion Establecida");
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Leyendo Informacion");
                        using (var reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Termino Leer Informacion");
                        connection.Close();
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Cierra Conexion");
                    }

                    catch (Exception ex)
                    {
                        BO.UtileriasBO.LogSeguimiento("ConsultaSqlDataTable", "Error: " + ex.Message);
                        throw new Exception(ex.Message);
                    }
                    finally {
                        if (connection.State == ConnectionState.Open) {
                            connection.Close();
                        }
                    }
                }
                return dt;
            }
        }

    }
}
