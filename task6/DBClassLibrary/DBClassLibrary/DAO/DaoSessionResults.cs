
namespace DBClassLibrary.DAO
{
    /// <summary>
    /// SessionResults factory
    /// </summary>
    public class DaoSessionResults : Dao<SessionResult>
    {
        /// <summary>
        /// Initializes a new instance of the DaoSessionResults class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoSessionResults(string connectionString) : base(connectionString)
        {

        }
    }
}
