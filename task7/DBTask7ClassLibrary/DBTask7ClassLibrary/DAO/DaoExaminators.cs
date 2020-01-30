
namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Examinators Dao
    /// </summary>
    public class DaoExaminators : Dao<Examinator>
    {
        /// <summary>
        /// Initializes a new instance of the DaoExaminators class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoExaminators(string connectionString) : base(connectionString)
        {

        }
    }
}
