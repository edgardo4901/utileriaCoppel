using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtileriasControlProg.Entity
{
    public static class Configuracion
    {
        /*
        IP 		NUMERO EMPLEADO	NOMBRE
        10.26.58.84		96622849 LUQUE CAMARGO ALEJANDRA
        10.26.58.111	97631833 GAXIOLA CERVANTES RUBEN ALBERTO
        10.26.58.108	95088954 RODRIGUEZ ESCARREGA VICTOR HUGO
         */
        public static List<ArchivosTiendaDetalle> ArchivosTiendaDetalleServidorBase;
        public static int TotalArchivosValidar = 0;
        public static int TotalArchivosObtenidos = 0;
        public static List<byte> ArchivosObtenidos = null;
        public static int ArchivosPorHilo = 100;
        public static int HilosPermitidos = 50;
        public static int HilosEnUso = 0;
        public static List<int> numeroEmpleadosValidos = new List<int>() { 91548462, 98798545, 96622849, 97631833, 95088954 };
        public static List<string> ipsAutorizadas = new List<string>() {"10.43.74.163", "10.26.58.84", "10.26.58.111", "10.26.58.108","10.26.58.88" };
        public static int NumeroDeEmpleado = 0;
        public static string IP = "";

    }
}
