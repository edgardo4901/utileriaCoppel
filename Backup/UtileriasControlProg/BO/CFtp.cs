using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
//using FluentFTP;
//using FluentFTP.Proxy;
using WinSCP;
using UtileriasControlProg.Entity;

namespace UtileriasControlProg.BO
{
    public class CFtp
    {

        public static bool esServidorValido(string ip, string usr, string pass)
        {
            try
            {
                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Ftp,
                    HostName = ip,
                    UserName = (usr == null || usr == string.Empty ? ServidorBaseConfiguracion.usuario : usr),
                    Password = (pass == null || pass == string.Empty ? ServidorBaseConfiguracion.password : pass)
                };
                using (Session session = new Session())
                {
                    session.Open(options);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void getFileFromProduccion(string ip, List<string> Files)
        {
            try
            {
                //Preparamos el directorio raiz
                string dRaiz = @"C:\UtileriasControlProg";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\RevisorVersiones";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\Files";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);


                
                //Preparamos el inicio de sesion para descargar los archivos del servidor de produccion
                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    HostName = ip,
                    UserName = ServidorBaseConfiguracion.usuario,
                    Password = ServidorBaseConfiguracion.password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (Session session = new Session())
                {
                    session.Open(options);

                    //Recorremos cada uno de los archivos que vamos a descargar
                    foreach (var item in Files)
                    {

                        string[] directoryToPath = item.Split('/');
                        string directoryToCopy = dRaiz;

                        //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                        for (int i = 0; i < directoryToPath.Length; i++)
                        {
                            if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                            {
                                directoryToCopy += @"\" + directoryToPath[i].Trim();
                                if (!Directory.Exists(directoryToCopy))
                                    Directory.CreateDirectory(directoryToCopy);
                            }
                        }

                        directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();

                        //En caso de que el archivo haya sido descargado previamente lo borramos de la ruta local de la maquina
                        if (File.Exists(directoryToCopy))
                            File.Delete(directoryToCopy);


                        //Aqui realizamos la descarga del archivo
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;

                        TransferOperationResult transferResult;
                        transferResult = session.GetFiles(item, directoryToCopy, false, transferOptions);

                        transferResult.Check();

                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            Console.WriteLine("Download of {0} succeeded", transfer.FileName);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void uploadFileFromLocal(string ip, List<string> Files)
        {
            try
            {
                //Preparamos el directorio raiz
                string dRaiz = @"C:\UtileriasControlProg";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\RevisorVersiones";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);

                dRaiz += @"\Files";
                if (!Directory.Exists(dRaiz))
                    Directory.CreateDirectory(dRaiz);



                //Preparamos el inicio de sesion para descargar los archivos del servidor de produccion
                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Sftp,
                    HostName = ip,
                    UserName = ServidorBaseConfiguracion.usuario,
                    Password = ServidorBaseConfiguracion.password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (Session session = new Session())
                {
                    session.Open(options);

                    //Recorremos cada uno de los archivos que vamos a descargar
                    foreach (var item in Files)
                    {

                        string[] directoryToPath = item.Split('/');
                        string directoryToCopy = dRaiz;

                        //Aqui el sistema prepara las carpeta donde se va a realizar la descarga
                        for (int i = 0; i < directoryToPath.Length; i++)
                        {
                            if (directoryToPath[i].Trim().Length > 0 && !directoryToPath[i].Contains(".") && i < (directoryToPath.Length - 1))
                            {
                                directoryToCopy += @"\" + directoryToPath[i].Trim();
                                if (!Directory.Exists(directoryToCopy))
                                    Directory.CreateDirectory(directoryToCopy);
                            }
                        }

                        directoryToCopy += @"\" + directoryToPath[directoryToPath.Length - 1].Trim();

                        //Preguntamos si el archivo que vamos a transmitir existe en el directorio local
                        if (!File.Exists(directoryToCopy))
                            throw new Exception("El archivo: " + directoryToCopy + " No existe en el equipo local, favor de avisar a sistemas");

                        //try
                        //{
                        //    RemovalOperationResult operatonRemove;
                        //    operatonRemove = session.RemoveFiles(item);
                        //    operatonRemove.Check();
                        //}
                        //catch { }
                        

                        //Aqui realizamos la descarga del archivo
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        transferOptions.FilePermissions = new FilePermissions { Octal = "775" };

                        TransferOperationResult transferResult;
                        //Probamos la funcion enviando el archivo al directorio temporal
                        //transferResult = session.PutFiles(directoryToCopy, "/tmp/" + directoryToPath[directoryToPath.Length - 1].Trim(), false, transferOptions);                        
                        transferResult = session.PutFiles(directoryToCopy, item, false, transferOptions);

                        transferResult.Check();

                        foreach (TransferEventArgs transfer in transferResult.Transfers)
                        {
                            Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        



        





        public static void getFilesByWINSCP(string ip, string path)
        {
            try
            {

                string dRaiz = @"C:\UtileriasControlProg";
                string dTdas = "tdas";
                string pathFullLocal = dRaiz + @"\" + dTdas;

                if (!Directory.Exists(dRaiz))
                {
                    Directory.CreateDirectory(dRaiz);
                }

                if (!Directory.Exists(dRaiz + @"\" + dTdas))
                {
                    Directory.CreateDirectory(dRaiz + @"\" + dTdas);
                }

                string[] directoriosBuscar = path.Split('/');
                string dDirectorio = "";

                foreach (string directorio in directoriosBuscar)
                {
                    if (directorio != "")
                    {
                        dDirectorio += directorio + @"\";

                        if (!Directory.Exists(pathFullLocal + @"\" + dDirectorio))
                        {
                            Directory.CreateDirectory(pathFullLocal + @"\" + dDirectorio);
                        }
                    }
                }

                SessionOptions options = new SessionOptions()
                {
                    Protocol = Protocol.Ftp,
                    HostName = ip,
                    UserName = ServidorBaseConfiguracion.usuario,
                    Password = ServidorBaseConfiguracion.password
                    //,GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (Session session = new Session())
                {

                    // Connect
                    session.Open(options);

                    RemoteDirectoryInfo archiLevel1 = session.ListDirectory(path);

                    foreach (RemoteFileInfo fileLevel1 in archiLevel1.Files)
                    {

                        if (fileLevel1.IsDirectory && !fileLevel1.Name.Trim().Contains("."))
                        {
                            //if(Directory.Exists())

                            string pathLevel2 = path + "/" + fileLevel1.Name;

                            RemoteDirectoryInfo archiLevel2 = session.ListDirectory(pathLevel2);
                            foreach (RemoteFileInfo fileLevel2 in archiLevel2.Files)
                            {

                            }
                        }
                        if (!fileLevel1.IsDirectory)
                        {
                        }
                    }

                    //// Upload files
                    //TransferOptions transferOptions = new TransferOptions();
                    //transferOptions.TransferMode = TransferMode.Binary;

                    //TransferOperationResult transferResult;
                    //transferResult =
                    //    session.PutFiles(@"d:\toupload\*", "/home/user/", false, transferOptions);

                    //// Throw on any error
                    //transferResult.Check();

                    //// Print results
                    //foreach (TransferEventArgs transfer in transferResult.Transfers)
                    //{
                    //    Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                    //}


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public static void otroCliente(string ip)
        //{
        //    try
        //    {
        //        FtpClient client = new FtpClient();
        //        client.Host = ip;
        //        client.Credentials = new NetworkCredential(ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password);
        //        client.Connect();

        //        // get a list of files and directories in the "/htdocs" folder
        //        foreach (FtpListItem item in client.GetListing("../../"))
        //        {

        //            // if this is a file
        //            if (item.Type == FtpFileSystemObjectType.File)
        //            {

        //                // get the file size
        //                long size = client.GetFileSize(item.FullName);

        //            }

        //            // get modified date/time of the file or folder
        //            DateTime time = client.GetModifiedTime(item.FullName);

        //            // calculate a hash for the file on the server side (default algorithm)
        //            //string hash = client.GetMD5(item.FullName);

        //        }

        //        client.Disconnect();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}




        public static void setConectionFTP(string ip)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ip + "/sysx/progs");
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(ServidorBaseConfiguracion.usuario, ServidorBaseConfiguracion.password);
                request.KeepAlive = false;
                request.UseBinary = true;
                request.UsePassive = true;



                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

                reader.Close();
                response.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
