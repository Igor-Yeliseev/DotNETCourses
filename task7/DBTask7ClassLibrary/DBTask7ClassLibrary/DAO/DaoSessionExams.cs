using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// SessionExam Dao
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

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override SessionExam GetById(int id)
        {
            var instance = db.GetTable<SessionExam>().Single(r => r.ID == id);

            return instance;
        }
    }
}
