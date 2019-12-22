using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Delegate describing the message processing function
    /// </summary>
    /// <returns></returns>
    public delegate string ReceiveMessage();

    /// <summary>
    /// Representing a message appearance processing class
    /// </summary>
    public class ClientMessageHandler
    {
        /// <summary>
        /// Event that occurs when a message is received
        /// </summary>
        public event ReceiveMessage OnLoadMessage;
    }

    public class ServerMessageHandler
    {
        /// <summary>
        /// Event that occurs when a message is received
        /// </summary>
        public event ReceiveMessage OnLoadMessage;

        /// <summary>
        /// List of client messages
        /// </summary>
        public List<Message> messages = new List<Message>();
        
    }
}
