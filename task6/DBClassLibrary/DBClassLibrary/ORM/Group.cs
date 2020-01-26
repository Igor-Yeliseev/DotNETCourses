
namespace DBClassLibrary
{
    /// <summary>
    /// Represents a student group class
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Group Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
        
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

            return (ID.Equals(gr.ID) && Name.Equals(gr.Name));
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
