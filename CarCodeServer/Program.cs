using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CerCodeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 8008);
            NetworkStream stream = null;
            try
            {
                tcpListener.Start();
                Console.WriteLine( "Server waiting...");
                
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                  
                    Task.Run(() =>
                    {
                        Console.WriteLine($"Client connected... {tcpClient.Client.RemoteEndPoint}");
                        stream = tcpClient.GetStream();
                        StreamReader reader = new StreamReader(stream);
                        StreamWriter writer = new StreamWriter(stream);
                     
                        while (tcpClient.Connected)
                        { 
                            //request code of car
                            string message = reader.ReadLine();

                            Console.WriteLine("You received the following message : " + message);
                            Console.WriteLine($"{DateTime.Now.ToLongTimeString()} :: {message} ");

                            //response server for client: region                          
                            string response_msg = "Region";
                            writer.WriteLine(response_msg);
                            writer.Flush();
                        }

                        reader.Close();
                        writer.Close();
                    });
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream.Close();
                tcpListener.Stop();
               
            }
        } 
    }
}
