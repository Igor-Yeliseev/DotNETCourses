
namespace DBClassLibrary.DAO
{
    /// <summary>
    /// Groups factory
    /// </summary>
    public class DaoGroups : Dao<Group>
    {
        /// <summary>
        /// Initializes a new instance of the DaoGroups class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoGroups(string connectionString) : base(connectionString)
        {

        }

    }
}
