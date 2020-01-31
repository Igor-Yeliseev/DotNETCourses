using System.Data.Linq.Mapping; 

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Represents a student group class
    /// </summary>
    [Table(Name = "groups")]
    public class Group : IRecord
    {
        /// <summary>
        /// Group Id
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Specialty ID
        /// </summary>
        [Column(Name = "SpecID")]
        public int SpecID { get; set; }

        /// <summary>
        /// Initializes a new instance of the Group class
        /// </summary>
        public Group()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Group class
        /// </summary>
        /// <param name="id"> Group Id</param>
        /// <param name="name"> Group name</param>
        /// <param name="specId"> Specialty ID</param>
        public Group(int id, string name, int specId)
        {
            ID = id;
            Name = name;
            SpecID = specId;
        }

        /// <summary>
        /// Initializes a new instance of the Group class
        /// </summary>
        /// <param name="name"> Group name</param>
        /// <param name="specId"> Specialty ID</param>
        public Group(string name, int specId)
        {
            Name = name;
            SpecID = specId;
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

            Group gr = obj as Group;
            if (gr == null)
                return false;

            return (ID.Equals(gr.ID) && Name.Equals(gr.Name) && SpecID.Equals(gr.SpecID));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ID.GetHashCode() + 17);
        }
    }
}
