using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Representing a client socket
    /// </summary>
    public class ClientSocket
    {
        /// <summary>
        /// Socket instance
        /// </summary>
        Socket socket;

        /// <summary>
        /// Client instance
        /// </summary>
        Client client;

        /// <summary>
        /// Server IP
        /// </summary>
        string serverIP;

        /// <summary>
        /// Port number
        /// </summary>
        int port;

        /// <summary>
        /// Initializes a new instance of the ClientSocket class
        /// </summary>
        /// <param name="client"> Client instance</param>
        /// <param name="serverIP"> Server IP</param>
        /// <param name="port"> Port number</param>
        public ClientSocket(Client client, string serverIP, int port)
        {
            this.client = client;
            this.serverIP = serverIP;
            this.port = port;
        }

        /// <summary>
        /// Connect to server
        /// </summary>
        public void Connect()
        {
            IPAddress ip = IPAddress.Parse(serverIP);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(ipe);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Disconnect from server
        /// </summary>
        public void Disconnect()
        {
            if(socket != null)
            {
                socket.Disconnect(true);
            }
            else
            {
                throw new Exception("The socket wasn't created.");
            }
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msg"> Message instance</param>
        public void Send(Message msg) // д.б. bool чтобы знать отправилось ли сообщение
        {
            byte[] clientMsg = new byte[50];
            byte[] message = new byte[1024];
            
            clientMsg = Encoding.ASCII.GetBytes(client.Name);
            message = Encoding.ASCII.GetBytes(msg.Text);
            
            socket.Send(clientMsg);
            socket.Send(message);
        }

        private string receiveString()
        {
            string recvMsg = null;
            int bytesrcv;
            byte[] recvData = new byte[1024];

            if (socket.Available > 0)
            {
                bytesrcv = socket.Receive(recvData);
                recvMsg = Encoding.ASCII.GetString(recvData, 0, bytesrcv);
            }

            return recvMsg;
        }






    }
}
