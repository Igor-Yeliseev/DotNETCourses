
namespace DBClassLibrary.DAO
{
    /// <summary>
    /// SessionExam factory
    /// </summary>
    public class DaoSessionExams : Dao<SessionExam>
    {
        /// <summary>
        /// Initializes a new instance of the DaoSessionExams class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoSessionExams(string connectionString) : base(connectionString)
        {

        }
    }
}
