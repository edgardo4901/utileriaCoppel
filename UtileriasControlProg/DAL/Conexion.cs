using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtileriasControlProg.DAL
{
    public abstract class Conexion
    {
        public Conexion()
        {
        }
        protected SqlConnection GetConexion(string conexion)
        {
            return new SqlConnection(conexion);
        }
    }
}
