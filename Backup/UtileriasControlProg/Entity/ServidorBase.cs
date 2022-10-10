using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.Entity
{
    public class ServidorBase
    {
        public string ip { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
    }


    public static class ServidorBaseConfiguracion
    {
        public static string ip { get; set; }
        public static string usuario { get; set; }
        public static string password { get; set; }
    }
}
