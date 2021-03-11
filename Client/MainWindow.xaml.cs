using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{

    public partial class MainWindow : Window
    {
        int port = 8080;
        string address = "127.0.0.1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                EndPoint remoteIpPoint = new IPEndPoint(IPAddress.Any, 0);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                string message = "";


                message = textBox.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.SendTo(data, ipPoint);


                int bytes = 0;
                message = "";
                data = new byte[1024];
                do
                {
                    bytes = socket.ReceiveFrom(data, ref remoteIpPoint);
                    message += Encoding.Unicode.GetString(data, 0, bytes);
                } while (socket.Available > 0);
                string[] streets = message.Split(new char[] { '\n' });
                foreach (var item in streets)
                {
                    listBox.Items.Add(item);
                }


                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
