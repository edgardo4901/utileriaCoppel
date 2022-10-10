using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.Entity
{
    public class ArchivosTienda
    {
        public int Tienda { get; set; }
        public string TiendaS { get; set; }
        public string Ip { get; set; }
        public int Modulos { get; set; }
        public int ModulosOutdate { get; set; }
        public int ModulosFaltantes { get; set; }
        public string EstatusConexion { get; set; }
        public int EstatusHilo { get; set; }
        public int ArchivosObtenidos { get; set; }
        public int ArchivosEnviados { get; set; }
        public int ArchivosDescargados { get; set; }
        public int KillThread { get; set; }
        public List<ArchivosTiendaDetalle> ArchivosTiendaDetalle;

        public ArchivosTienda()
        {
            ArchivosTiendaDetalle = new List<ArchivosTiendaDetalle>();
            EstatusConexion = "";
        }

    }
}
