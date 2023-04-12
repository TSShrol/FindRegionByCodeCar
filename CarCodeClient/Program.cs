using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace CarCodeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();

            NetworkStream stream = null;
           
            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                //tcpClient.Connect("127.0.0.1",8008);
                tcpClient.Connect("10.7.150.203", 8008);
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                while (true)
                {
                    Console.Write("Input message>> ");
                    var message = Console.ReadLine();
                    writer.WriteLine(message);
                    writer.Flush();

                    var response_msg=reader.ReadLine();
                    Console.WriteLine("You received the following message : " + response_msg);

                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
                tcpClient.Close();
                reader.Close();
                writer.Close();
            }
            Console.ReadKey();
        }
    }
}
