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
                estructuraConexion.IP = "10.44.75.100";
                estructuraConexion.User = "syspruebasadmon";
                estructuraConexion.CtrCo = "1299e3097";
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

        public DataTable ConsultaSqlDataTable(string ConnectionString, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (var connection = GetConexion(ConnectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandTimeout = 0;
                        command.CommandText = commandText;
                        command.CommandType = commandType;
                        if (parameters != null) { command.Parameters.AddRange(parameters); }
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                        connection.Close();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                return dt;
            }
        }

    }
}
