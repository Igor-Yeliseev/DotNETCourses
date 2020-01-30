
namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Subjects Dao
    /// </summary>
    public class DaoSubjects : Dao<Subject>
    {
        /// <summary>
        /// Initializes a new instance of the DaoSubjects class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoSubjects(string connectionString) : base(connectionString)
        {

        }

    }
}
