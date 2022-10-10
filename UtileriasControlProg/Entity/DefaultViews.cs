using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.Entity
{
    class DefaultViews
    {
    }

    public class ModelBusquedaPorArchivo
    {
        public string Archivo { get; set; }
        public string Md5Manual { get; set; }
    }

    public class ModelTiendas { 
        public List<ArchivosTienda> Archivos { get; set; }
        public ModelTiendas()
        {
            Archivos = new List<ArchivosTienda>();
        }
    }


    



}
