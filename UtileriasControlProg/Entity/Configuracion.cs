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
        public static List<int> numeroEmpleadosAdministrador = new List<int>() { 91548462, 97631833 };
        public static List<int> numeroEmpleadosValidos = new List<int>() {};
        public static List<string> ipsAutorizadas = new List<string>() { };
        public static bool MostrarBloque1 = false;
        public static bool MostrarBloque2 = false;
        public static bool MostrarBloque3 = false;
        public static int NumeroDeEmpleado = 0;
        public static string IP = "";
        public static string SoloColaboradores = "";

        public static string fileEmpleado = "empleado.dat";
        public static string fileIps = "ip.dat";
        public static string centros = "centros.dat";
        public static string parametros = "parametros.dat";
        public static string encodingEmpleado = "ESTE EL NUMERO DE EMPLEADO NO SEAS METICHE TE LA TIRAS DE HACKER MAN ||||||||||";
        public static string encodingIP = "ESTE EL IP DE LA MICRO DE COPPEL DE LA RED INTERNA NO SEAS METICHE TE LA TIRAS DE HACKER MAN ||||||||||";

    }
}
