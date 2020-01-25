using DBClassLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Students factory
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
