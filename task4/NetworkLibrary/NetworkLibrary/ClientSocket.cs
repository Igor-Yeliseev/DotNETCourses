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

            SetupEvent();
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
                    else if(TRANSLIT.ContainsKey(Char.ToLower(msgLetter)))
                    {
                        char bigLetter = Char.ToLower(msgLetter);
                        engText += Char.ToUpper(TRANSLIT[bigLetter][0]) + TRANSLIT[bigLetter].Substring(1);
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
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg.client.Name + "|" + msg.Text);
            socket.Send(msgBytes);
        }

        /// <summary>
        /// Get response from server
        /// </summary>
        /// <returns></returns>
        public string Receive()
        {
            string answer = ReceiveString();
            
            // Транслитерация
            answer = clientMsgHandler.CallMessageEvent(answer);

            return answer;
        }

        private string ReceiveString()
        {
            byte[] recvData = new byte[1024];

            string text = null;
            
            if (socket.Available > 0)
            {
                int numBytes = socket.Receive(recvData);
                text = Encoding.UTF8.GetString(recvData, 0, numBytes);
            }
            
            return text;
        }






    }
}
