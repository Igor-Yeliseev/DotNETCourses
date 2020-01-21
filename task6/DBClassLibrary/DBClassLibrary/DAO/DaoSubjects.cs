using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary.DAO
{
    /// <summary>
    /// Subjects factoty
    /// </summary>
    public class DaoSubjects : DaoFactory<Subject>
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
