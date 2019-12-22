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
    /// Representing a server socket
    /// </summary>
    public class ServerSocket
    {
        /// <summary>
        /// Server socket instance
        /// </summary>
        Socket servListener = null;

        Socket servSocket = null;

        /// <summary>
        /// Client sockets list
        /// </summary>
        List<ClientSocket> clientSockets = new List<ClientSocket>();
        
        /// <summary>
        /// Get all client messages
        /// </summary>
        /// <returns></returns>
        public List<Message> GetAllMessages()
        {
            return messages;
        }

        /// <summary>
        /// Port number
        /// </summary>
        int port;

        /// <summary>
        /// The maximum number of clients waiting for a connection.
        /// </summary>
        int numberClients;

        /// <summary>
        /// Initializes a new instance of the ServerSocket class
        /// </summary>
        /// <param name="port"> Port number</param>
        /// <param name="numberClients"> The maximum number of clients waiting for a connection.</param>
        public ServerSocket(int port, int numberClients)
        {
            this.port = port;
            this.numberClients = numberClients;

            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
            servListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            servListener.Bind(ipEnd);
        }
        
        /// <summary>
        /// Wait a new client connection
        /// </summary>
        public void WaitClientConnection()
        {
            if (servListener != null)
            {
                servListener.Listen(numberClients);
                servSocket = servListener.Accept();

                clientSockets.Add(new ClientSocket(new Client(null, null), null, port));
            }
            else
            {
                throw new Exception("Server socket listener wasn't created");
            }
        }

        /// <summary>
        /// Close connection and releases all resources
        /// </summary>
        public void Close()
        {
            foreach (ClientSocket clnSocket in clientSockets)
            {
                clnSocket.Disconnect();
            }

            servSocket.Close();
        }

        private void SendString(string text)
        {
            byte[] bytes = new byte[1024];

            bytes = Encoding.ASCII.GetBytes(text);

            servSocket.Send(bytes);
        }

        private string ReceiveString()
        {
            byte[] recvdData = new byte[1024];
            string text = null;
            int numBytes;

            numBytes = servSocket.Receive(recvdData);
            text = Encoding.ASCII.GetString(recvdData, 0, numBytes);

            return text;
        }

        /// <summary>
        /// Receive message
        /// </summary>
        /// <returns></returns>
        public Message Receive()
        {
            string clientName = ReceiveString();
            string msgText = ReceiveString();

            Message message = new Message(msgText, new Client(clientName, null));
            
            return message;
        }

        /// <summary>
        /// Send a message to the client
        /// </summary>
        /// <param name="msg"> Message instance</param>
        public void Send(Message msg)
        {
            //SendString(msg.client.Name);
            //SendString(msg.Text);
            SendString("Succesfully ");
        }






    }
}
