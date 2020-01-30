using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
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
        public DaoStudents(string connectionString) : base(connectionString)
        {

        }

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Student GetById(int id)
        {
            var instance = from record in db.GetTable<Student>()
                           where record.ID == id
                           select record;
            return (instance as Student);
        }
    }
}
