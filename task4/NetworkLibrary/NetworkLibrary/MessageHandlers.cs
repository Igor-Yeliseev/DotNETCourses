using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Delegate describing the function of recoding a message
    /// </summary>
    /// <param name="msgText"> Message text</param>
    /// <returns></returns>
    public delegate string ReceiveClientMessage(string msgText);
    /// <summary>
    /// Delegate describing the function of adding client messages
    /// </summary>
    public delegate void ReceiveServerMessage(Message message);

    /// <summary>
    /// Representing a client message handler class
    /// </summary>
    public class ClientMessageHandler
    { 
        /// <summary>
        /// Event that occurs when a message is received
        /// </summary>
        public event ReceiveClientMessage MessageEvent;

        /// <summary>
        /// Call an event
        /// </summary>
        /// <param name="message"> Message instance</param>
        /// <returns></returns>
        public string CallMessageEvent(string msgText)
        {
            return MessageEvent(msgText);
        }
    }

    /// <summary>
    /// Representing a server message handler class
    /// </summary>
    public class ServerMessageHandler
    {
        /// <summary>
        /// Event that occurs when a message is received
        /// </summary>
        public event ReceiveServerMessage MessageEvent;

        /// <summary>
        /// Call an event
        /// </summary>
        /// <param name="message"> Message instance</param>
        public void CallMessageEvent(Message message)
        {
            MessageEvent(message);
        }

        /// <summary>
        /// List of client messages
        /// </summary>
        public List<Message> messages = new List<Message>();
    }
}
