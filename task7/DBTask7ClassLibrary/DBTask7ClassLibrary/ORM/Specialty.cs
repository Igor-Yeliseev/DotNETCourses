using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Represents a student's specialty
    /// </summary>
    [Table(Name = "Specialties")]
    public class Specialty : IRecord
    {
        /// <summary>
        /// Specialty Id
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Specialty name
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the Specialty class
        /// </summary>
        public Specialty()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Specialty class
        /// </summary>
        /// <param name="id"> Specialty Id</param>
        /// <param name="name"> Specialty name</param>
        public Specialty(int id, string name)
        {
            ID = id;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the Specialty class
        /// </summary>
        /// <param name="name"> Specialty name</param>
        public Specialty(string name)
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

            Specialty spec = obj as Specialty;
            if (spec == null)
                return false;

            return (ID.Equals(spec.ID) && Name.Equals(spec.Name));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ID.GetHashCode() + 3 - Name.GetHashCode() + 27);
        }
        
    }
}
