using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
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

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SessionResult GetById(int id)
        {
            var instance = db.GetTable<SessionResult>().Single(r => r.ID == id);

            return instance;
        }
    }
}
