using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.BO
{
    public class TiendasBO
    {
        public static List<UtileriasControlProg.Entity.Tiendas> TraerTiendas()
        {
            return DAL.TiendasDAL.TraerTiendas();
        }
    }
}
