using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Groups Dao
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
