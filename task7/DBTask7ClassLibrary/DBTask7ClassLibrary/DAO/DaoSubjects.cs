using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Subject GetById(int id)
        {
            var instance = db.GetTable<Subject>().Single(r => r.ID == id);
            
            return instance;
        }
    }
}
