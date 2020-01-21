using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Represents a student group class
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Group Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Initializes a new instance of the Group class
        /// </summary>
        /// <param name="id"> Group Id</param>
        /// <param name="name"> Group name</param>
        public Group(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the Group class
        /// </summary>
        /// <param name="name"> Group name</param>
        public Group(string name)
        {
            Name = name;
        }
    }
}
