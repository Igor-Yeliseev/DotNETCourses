using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Represents a subject class
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Subject ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Subject name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the Subject class
        /// </summary>
        /// <param name="id"> Subject Id</param>
        /// <param name="name"> Subject name</param>
        public Subject(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the Subject class
        /// </summary>
        /// <param name="name"> Subject name</param>
        public Subject(string name)
        {
            Name = name;
        }
    }
}
