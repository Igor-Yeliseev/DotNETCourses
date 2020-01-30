
namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Specialties Dao
    /// </summary>
    public class DaoSpecialties : Dao<Specialty>
    {
        /// <summary>
        /// Initializes a new instance of the DaoSpecialties class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoSpecialties(string connectionString) : base(connectionString)
        {

        }
    }
}
