using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Represents an examinator class
    /// </summary>
    [Table(Name = "Examinators")]
    public class Examinator : IRecord
    {
        /// <summary>
        /// Examinator Id
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Examinator full name
        /// </summary>
        [Column(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Initializes a new instance of the Examinator class
        /// </summary>
        public Examinator()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Examinator class
        /// </summary>
        /// <param name="id"> Examinator Id</param>
        /// <param name="fullName"> Examinator full name</param>
        public Examinator(int id, string fullName)
        {
            ID = id;
            FullName = fullName;
        }

        /// <summary>
        /// Initializes a new instance of the Examinator class
        /// </summary>
        /// <param name="fullName"> Examinator full name</param>
        public Examinator(string fullName)
        {
            FullName = fullName;
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

            Examinator extr = obj as Examinator;
            if (extr == null)
                return false;

            return (ID.Equals(extr.ID) && FullName.Equals(extr.FullName));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (FullName.GetHashCode() * 2 - ID.GetHashCode());
        }
    }
}
