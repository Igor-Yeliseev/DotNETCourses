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
        /// Server listener instance
        /// </summary>
        Socket servListener = null;

        /// <summary>
        /// Server socket instance
        /// </summary>
        Socket servSocket = null;

        /// <summary>
        /// Server message handler instance
        /// </summary>
        ServerMessageHandler servMsgHandler =  null;

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

            SetupEvent();
        }
        
        private void SetupEvent()
        {
            servMsgHandler = new ServerMessageHandler();

            servMsgHandler.MessageEvent += (Message message) =>
            {
                servMsgHandler.messages.Add(message);
            };
        }

        /// <summary>
        /// Get all client messages
        /// </summary>
        /// <returns></returns>
        public List<Message> GetAllMessages()
        {
            return servMsgHandler.messages;
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
            servSocket.Close();
        }

        private void SendString(string text)
        {
            byte[] bytes = new byte[1024];

            bytes = Encoding.UTF8.GetBytes(text);

            servSocket.Send(bytes);
        }

        private string ReceiveString()
        {
            byte[] recvdData = new byte[1024];
            string text = null;
            int numBytes;
            
            if(servSocket.Available > 0)
            {
                numBytes = servSocket.Receive(recvdData);
                text = Encoding.UTF8.GetString(recvdData, 0, numBytes);
            }
            
            return text;
        }

        /// <summary>
        /// Receive message
        /// </summary>
        /// <returns></returns>
        public Message Receive()
        {
            string[] data = ReceiveString().Split('|');
            string clientName = data[0];
            string msgText = data[1];

            Message message = new Message(msgText, new Client(clientName, null));
            // Вызов события
            servMsgHandler.CallMessageEvent(message);

            return message;
        }

        /// <summary>
        /// Send a message to the client
        /// </summary>
        /// <param name="msg"> Message instance</param>
        public void Send(Message msg)
        {
            SendString(msg.ToString());
        }






    }
}
