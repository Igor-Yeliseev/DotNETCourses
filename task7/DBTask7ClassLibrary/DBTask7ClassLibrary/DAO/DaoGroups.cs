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

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Group GetById(int id)
        {
            var instance = db.GetTable<Group>().Single(r => r.ID == id);

            return instance;
        }
    }
}
