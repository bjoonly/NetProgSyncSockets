using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    class Server
    {
        MyDbContext ctx;
        public Server()
        {
            ctx = new MyDbContext();
        }

        public List<Street>GetStreets(string index)
        {
            return ctx.Streets.Where(s => s.Postcode.Index == index).ToList();
        }
    }
    class Program
    {
        static int port = 8080;
        static void Main(string[] args)
        {
            Server server = new Server();
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipPoint = new IPEndPoint(iPAddress, port);


            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);


            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {

                listenSocket.Bind(ipPoint);
                Console.WriteLine("Server started! Waiting for connection...");

                while (true)
                {

                    int bytes = 0;
                    byte[] data = new byte[1024];
                    bytes = listenSocket.ReceiveFrom(data, ref remoteEndPoint);

                    string msg = Encoding.Unicode.GetString(data, 0, bytes);
                    Console.WriteLine($"{DateTime.Now.ToShortTimeString()}:{msg} from {remoteEndPoint}");
                    List<string>res = server.GetStreets(msg).Select(s=>s.Name).ToList();
                    string message="";
                    foreach (var item in res)
                    {
                        message += item+"\n";
                    }

                    data = Encoding.Unicode.GetBytes(message);
                    listenSocket.SendTo(data, remoteEndPoint);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
