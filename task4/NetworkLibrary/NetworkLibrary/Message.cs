using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Representing a message class
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Client instance
        /// </summary>
        public Client client { get; set; }

        /// <summary>
        /// Initializes a new instance of the Message class
        /// </summary>
        /// <param name="text"> Message text</param>
        /// <param name="client"> Client instance</param>
        public Message(string text, Client client)
        {
            Text = text;
            this.client = client;
        }
    }
}
