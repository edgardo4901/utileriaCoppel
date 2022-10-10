using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using UtileriasControlProg.Entity;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace UtileriasControlProg.BO
{
    public class CSocket
    {

        public static void buscarModulo(ref ArchivosTienda Tienda)
        {
            try
            {
                BO.UtileriasBO.LogSeguimiento("Inicia exploracion en tienda ", Tienda.TiendaS);

                Int32 port = 20502;
                TcpClient client = new TcpClient();

                CEstructuras.Enviar0004 enviar = new CEstructuras.Enviar0004();
                CEstructuras.Recibir0004 recibe = new CEstructuras.Recibir0004();

                foreach (var x in Tienda.ArchivosTiendaDetalle)
                {
                    if (Tienda.KillThread == 1)
                        throw new Exception("Hilo detenido por el usuario");

                    enviar = new CEstructuras.Enviar0004();
                    recibe = new CEstructuras.Recibir0004();
                    client = new TcpClient();
                    client.ReceiveTimeout = 3000;
                    client.SendTimeout = 3000;
                    client.Connect(Tienda.Ip, port);

                    enviar.iClave = 4;
                    enviar.iModo = 1;
                    enviar.cArchivoOrigen = x.Ruta;

                    int size = Marshal.SizeOf(enviar);
                    byte[] data = new byte[size];
                    IntPtr ptrT = Marshal.AllocHGlobal(size);

                    Marshal.StructureToPtr(enviar, ptrT, false);
                    Marshal.Copy(ptrT, data, 0, size);
                    Marshal.FreeHGlobal(ptrT);

                    // Get a client stream for reading and writing.
                    // Stream stream = client.GetStream();
                    NetworkStream stream = client.GetStream();

                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);

                    recibe = new CEstructuras.Recibir0004();
                    size = Marshal.SizeOf(recibe);

                    // Buffer to store the response bytes.
                    data = new Byte[size];

                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);

                    IntPtr ptr2 = Marshal.AllocHGlobal(size);
                    Marshal.Copy(data, 0, ptr2, size);
                    recibe = (CEstructuras.Recibir0004)Marshal.PtrToStructure(ptr2, typeof(CEstructuras.Recibir0004));
                    Marshal.FreeHGlobal(ptr2);

                    if (recibe.iRespuesta == 1)
                    {
                        string md5 = "";
                        if (buscarMD5(x.Ruta, Tienda.Ip, ref md5))
                        {
                            x.MD5 = md5;
                            x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                            Tienda.ArchivosObtenidos += 1;
                        }
                        else
                        {
                            x.MD5 = "NO ENCONTRADO";
                            x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                            Tienda.ArchivosObtenidos += 1;
                        }
                    }
                    else
                    {
                        x.MD5 = "NO ENCONTRADO";
                        x.Modulo = x.Ruta.Split('/')[x.Ruta.Split('/').Length - 1];
                        Tienda.ArchivosObtenidos += 1;
                    }
                }
                BO.UtileriasBO.LogSeguimiento("Termina exploracion en tienda ", Tienda.TiendaS);
                Tienda.EstatusHilo = 1;
            }
            catch(Exception ex)
            {
                BO.UtileriasBO.LogSeguimiento("Termina exploracion en tienda " + Tienda.TiendaS + " IP_TIENDA " + Tienda.Ip + " con ERROR:  ", ex.Message);
                Tienda.ArchivosObtenidos = Tienda.ArchivosTiendaDetalle.Count;
                Tienda.EstatusHilo = 1;
                Tienda.EstatusConexion = "Ocurrio un error al revisar los archivos de la tienda, Excepcion: " + ex.Message;
            }
        }


        private static bool buscarMD5(string sRuta, string sIpTienda, ref string sMD5)
        {
            bool bRegresa = false;

            try
            {
                // Create a TcpClient.
                // The client requires a TcpServer that is connected
                // to the same address specified by the server and port
                // combination.
                Int32 port = 20502;
                TcpClient client = new TcpClient(sIpTienda, port);
                client.ReceiveTimeout = 5000;
                client.SendTimeout = 5000;

                CEstructuras.EnviarMD50004 enviar = new CEstructuras.EnviarMD50004();

                enviar.iClave = 4;
                enviar.iModo = 9;
                enviar.cOrigen = sRuta;
                enviar.cMac = GetMacAddress().ToString();

                //sprintf(enviar0004.cMac, "%.12s", cMaquina);

                int size = Marshal.SizeOf(enviar);

                byte[] data = new byte[size];

                IntPtr ptrT = Marshal.AllocHGlobal(size);

                Marshal.StructureToPtr(enviar, ptrT, false);
                Marshal.Copy(ptrT, data, 0, size);
                Marshal.FreeHGlobal(ptrT);

                // Get a client stream for reading and writing.
                // Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                CEstructuras.RecibirMD50004 recibe = new CEstructuras.RecibirMD50004();
                size = Marshal.SizeOf(recibe);

                // Buffer to store the response bytes.
                data = new Byte[size];

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);

                IntPtr ptr2 = Marshal.AllocHGlobal(size);
                Marshal.Copy(data, 0, ptr2, size);
                recibe = (CEstructuras.RecibirMD50004)Marshal.PtrToStructure(ptr2, typeof(CEstructuras.RecibirMD50004));
                Marshal.FreeHGlobal(ptr2);

                if (recibe.iRespuesta == 1)
                {
                    sMD5 = recibe.cMd5;
                }

                // Close everything.
                stream.Close();
                client.Close();

                bRegresa = true;
            }
            catch (ArgumentNullException)
            {
                throw;
                //sMensaje = "ArgumentNullException: " + e;
                //MessageBox.Show(sMensaje);
            }
            catch (SocketException)
            {
                throw;
                //sMensaje = "SocketException: " + e.ToString();
                //MessageBox.Show(sMensaje);
            }

            return bRegresa;
        }

        private static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

    }
}
