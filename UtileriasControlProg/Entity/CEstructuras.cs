using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace UtileriasControlProg.Entity
{
    public class CEstructuras
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Tienda19Envia
        {
            public short iClave;
            public int lValorSeguridad;
            public int iSistema;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string cMac;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Tienda19Recibe
        {
            public int iRespuesta;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string cMd5;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 66)]
            public string cModulo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 130)]
            public string cRuta;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Enviar0004
        {
            public short iClave;
            public int lValorSeguridad,
                       iModo,
                       iHoraArc,
                       lFechaArc;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string cArchivoOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string cArchivoDestino;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Recibir0004
        {
            public int iRespuesta;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct EnviarMD50004
        {
            public short iClave;
            public int lValorSeguridad,
                       iModo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string cOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
            public string cMac;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RecibirMD50004
        {
            public int iRespuesta;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string cMd5;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Enviar0015
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string cArchivo;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Recibir0015
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string cArchivo;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RecibirTamanio0015
        {
            public int iTamanio;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Recibirbyn0015
        {
            public byte cArchivo;
        };
    }
}
