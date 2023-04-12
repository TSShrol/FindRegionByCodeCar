using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CerCodeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindCarCodeNumber("BK");
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
        public static string FindCarCodeNumber(string carCode)
        {
            string result = "Not found";
            using (DbContextCodeCar db = new DbContextCodeCar())
            {
                var carCodes = db.CarNumberCodes.Include(c => c.Region).ToList();
                var carRegion = carCodes.FirstOrDefault(c => c.Code == carCode);
                if (carRegion != null)
                    result = carRegion.Region.NameRegion;
                foreach (var code in carCodes)
                {
                    Console.WriteLine($"Id: {code.Id}\tCode: {code.Code}\tRegionId: {code.RegionId}");
                }
                Console.WriteLine($"Region: {carRegion.Region.NameRegion}");
            }
            return result;
        }
    }
}
