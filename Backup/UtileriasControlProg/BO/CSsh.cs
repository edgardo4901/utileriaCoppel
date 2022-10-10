using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;
using UtileriasControlProg.Entity;
namespace UtileriasControlProg.BO
{
    public class CSsh
    {
        public static string ejecutarComandSsh(string ip, string comand)
        {
            try
            {
                using (SshClient cliente = new SshClient(ip, ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password))
                {
                    cliente.Connect();
                    //var response = cliente.RunCommand("md5sum /sysx/progs/progx/ca/CA0001.DLL");
                    var response = cliente.RunCommand(comand);
                    string res = response.Result;
                    cliente.Disconnect();
                    cliente.Dispose();
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void getMD5FromServer(string ip, ref List<ArchivosTiendaDetalle> ListaArchivosTiendaDetalle, ref int totalArchivosObtenidos)
        {
            try
            {
                totalArchivosObtenidos = 0;
                using (SshClient cliente = new SshClient(ip, ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password))
                {
                    cliente.Connect();

                    foreach (ArchivosTiendaDetalle x in ListaArchivosTiendaDetalle)
                    {
                        var response = cliente.RunCommand("md5sum " + x.Ruta);
                        string res = response.Result;
                        x.MD5 = res.Split(' ')[0];
                        x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                        totalArchivosObtenidos += 1;
                    }
                    cliente.Disconnect();
                    cliente.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void getMD5FromServerFork(string ip, ref List<ArchivosTiendaDetalle> ListaArchivosTiendaDetalle, int start, int end)
        {
            try
            {
                Configuracion.HilosEnUso++;
                if (end > ListaArchivosTiendaDetalle.Count)
                {
                    end = ListaArchivosTiendaDetalle.Count - 1;
                }
                using (SshClient cliente = new SshClient(ip, ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password))
                {
                    cliente.Connect();
                    for (int i = start; i <= end; i++)
                    {
                        var x = ListaArchivosTiendaDetalle[i];
                        var response = cliente.RunCommand("md5sum " + x.Ruta);
                        string res = response.Result;
                        x.MD5 = res.Split(' ')[0];
                        x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                        Configuracion.TotalArchivosObtenidos += 1;
                    }
                    cliente.Disconnect();
                    cliente.Dispose();
                }
                Configuracion.HilosEnUso--;
            }
            catch (Exception ex)
            {
                Configuracion.HilosEnUso--;
                throw ex;
            }
        }


       
    }
}
