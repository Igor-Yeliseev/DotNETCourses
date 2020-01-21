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


        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Subject sbj = obj as Subject;
            if (sbj == null)
                return false;

            return (ID.Equals(sbj.ID) && Name.Equals(sbj.Name));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Name.GetHashCode() * 2 - ID.GetHashCode());
        }
    }
}
