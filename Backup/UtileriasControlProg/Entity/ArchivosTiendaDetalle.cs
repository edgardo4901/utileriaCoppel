using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.Entity
{
    public class ArchivosTiendaDetalle
    {
        public string Ruta { get; set; }
        public string Modulo { get; set; }
        public string MD5 { get; set; }
        public string MD5Produccion { get; set; }
        public int Estatus { get; set; }
    }
}
