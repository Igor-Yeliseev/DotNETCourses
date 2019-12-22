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
        /// Client message handler instance
        /// </summary>
        ClientMessageHandler clientMsgHandler = null;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Dictionary<char, string> TRANSLIT = new Dictionary<char, string>()
        {
            { 'а', "a" }, { 'б', "b" }, { 'в', "v" }, { 'г', "g" }, { 'д', "d" },
            { 'е', "e" }, { 'ё', "e" }, { 'ж', "zh" }, { 'з', "z" }, { 'и', "i" },
            { 'й', "y" }, { 'к', "k" }, { 'л', "l" }, { 'м', "m" }, { 'н', "n" },
            { 'о', "o" }, { 'п', "p" }, { 'р', "r" }, { 'с', "s" }, { 'т', "t" },
            { 'у', "u" }, { 'ф', "f" }, { 'х', "kh" }, { 'ц', "ts" }, { 'ч', "ch" },
            { 'ш', "sh" }, { 'щ', "sch" }, { 'ь', "" }, { 'ы', "y" }, { 'ъ', "" },
            { 'э', "e" }, { 'ю', "yu" }, { 'я', "ya" }
        };
        
        private void SetupEvent()
        {
            clientMsgHandler = new ClientMessageHandler();

            clientMsgHandler.MessageEvent += (string msgText) =>
            {
                string engText = null;

                foreach (char msgLetter in msgText)
                {
                    if(TRANSLIT.ContainsKey(msgLetter))
                    {
                        engText += TRANSLIT[msgLetter];
                    }
                    else
                    {
                        engText += msgLetter;
                    }
                }

                // return a new translited message
                return engText;
            };
        }

        /// <summary>
        /// Disconnect from server
        /// </summary>
        public void Disconnect()
        {
            socket.Disconnect(true);
        }

        /// <summary>
        /// Closes the connection and releases all resources.
        /// </summary>
        public void Close()
        {
            socket.Close();
        }

        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="msg"> Message instance</param>
        public void Send(Message msg)
        {
            byte[] clientMsg = new byte[50];
            byte[] message = new byte[1024];
            
            clientMsg = Encoding.ASCII.GetBytes(client.Name);
            message = Encoding.ASCII.GetBytes(msg.Text);
            
            socket.Send(clientMsg);
            socket.Send(message);
        }

        /// <summary>
        /// Get response from server
        /// </summary>
        /// <returns></returns>
        public string Receive()
        {
            //string answer = ReceiveString();
            string answer = ReceiveString();
            // trans
            answer = clientMsgHandler.CallMessageEvent(answer);

            return answer;
        }

        private string ReceiveString()
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
