﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

namespace UtileriasControlProg.DAL
{
    public class TiendasDAL
    {


        public static List<UtileriasControlProg.Entity.Tiendas> TraerTiendas()
        {

            NpgsqlConnection con = null;
            try
            {

                List<UtileriasControlProg.Entity.Tiendas> Respuesta = new List<UtileriasControlProg.Entity.Tiendas>();

                DataSet ds = new DataSet();
                con = Utilerias.ObtenerConexionPostgreSQL("sistemas2007MAS");
                //string sql = "SELECT tienda,ipservidorlocal FROM sysservidorestdas WHERE tiposucursal = 'T' AND tienda > 0   ORDER BY tienda";
                string sql = "SELECT tienda,ip,ipsoporte FROM tiendas  ORDER BY tienda";
                NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(sql, con);
                adaptador.Fill(ds);

                Respuesta = (from a in ds.Tables[0].AsEnumerable()
                             select new UtileriasControlProg.Entity.Tiendas
                             {
                                 Tienda = a.Field<Int32>("tienda").ToString(),
                                 IPservidorlocal = a.Field<string>("ip").Trim(),
                                 IPservidorSoporte = a.Field<string>("ipsoporte").Trim()
                             }).ToList();

                return Respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}
