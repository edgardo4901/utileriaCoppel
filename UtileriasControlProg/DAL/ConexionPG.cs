using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml.Linq;
using System.Data.Odbc;
using System.Diagnostics;
using Npgsql;
using UtileriasControlProg.Entity;

namespace UtileriasControlProg.DAL
{
    class ConexionPG
    {

        public static NpgsqlConnectionStringBuilder psqlConnBuild(int tipo)
        {
            NpgsqlConnectionStringBuilder connstring = new NpgsqlConnectionStringBuilder();
            //pruebas
            connstring.Host = "10.27.113.144";
            connstring.Database = "nominacontabilidad";
            connstring.UserName = "syscarterasemisiones";
            connstring.Password = "986d07369215b51a3a257473b4ee917b";
            connstring.Enlist = true;
            //connstring.Port = 5432;

            /*connstring.Host = "10.44.1.12";
            connstring.Database = "nominacontabilidad";
            connstring.UserName = "sysingresos";
            connstring.Password = "1299e3097ebcb90b651b4510559c63a7";
            connstring.Enlist = true;
            //connstring.Port = 5432;*/

            connstring.Timeout = 1024;

            return connstring;
        }

        public static bool abreconexionPG(ref NpgsqlConnection conexion,int tipo)
        {
            String sMensaje = "";
            bool bRegresa = false;

            conexion.ConnectionString = psqlConnBuild(1).ConnectionString;

            try
            {
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    bRegresa = true;
                }
            }
            catch (OdbcException oe)
            {
                sMensaje = "No se pudo establecer la conexión al servidor ";
                bRegresa = false;
            }

            return bRegresa;
        }

        public static void cierraconexionPG(NpgsqlConnection conexion)
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public static System.Data.DataTable fEjecutarConsulta(string sConsulta, NpgsqlConnection odbc)
        {
            DataTable dt = new DataTable();
            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sConsulta, odbc);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
