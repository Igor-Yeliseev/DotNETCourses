using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkLibrary
{
    /// <summary>
    /// Representing a client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// IP address
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Client class
        /// </summary>
        /// <param name="name"> Client name</param>
        /// <param name="ipAddress"> IP address of the client</param>
        public Client(string name, string ipAddress)
        {
            Name = name;
            IP = ipAddress;
        }
    }
}
