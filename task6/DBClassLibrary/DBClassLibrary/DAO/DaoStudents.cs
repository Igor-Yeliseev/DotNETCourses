namespace DBClassLibrary.DAO
{
    /// <summary>
    /// Students Dao
    /// </summary>
    public class DaoStudents : Dao<Student>
    {
        /// <summary>
        /// Initializes a new instance of the DaoStudents class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoStudents(string connectionString) :base (connectionString)
        {

        }
    }
}
