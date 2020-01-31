using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Data Access Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Dao<T> : IDao<T>
        where T : class, IRecord
    {
        string connectionString;
        Type type;

        /// <summary>
        /// Initializes a new instance of the Dao class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public Dao(string connectionString)
        {
            this.connectionString = connectionString;
            type = typeof(T);
        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public void Create(T record)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                db.GetTable(type).InsertOnSubmit(record);
                db.SubmitChanges();
            }    
        }

        /// <summary>
        /// Delete a record from a table
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public void Delete(T record)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                T instance = db.GetTable(type).Cast<T>().Single(r => r.ID == record.ID);
                db.GetTable(type).DeleteOnSubmit(instance);
                db.SubmitChanges();
            }   
        }

        /// <summary>
        /// Get all records from table
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllRecords()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                var table = db.GetTable(type);
                List<T> records = new List<T>();
                
                foreach (T row in table)
                {
                    records.Add(row);
                }

                return records;
            }
        }

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                var instance = db.GetTable(type).Cast<T>().Single(r => r.ID == id);
                return instance;
            }
        }

        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        public void Update(T record)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                var results = db.GetTable<T>().Where(r => r.ID == record.ID);

                if (results.Any())
                {
                    // Иначе не хотело обновлять
                    var ctx = new DataContext(connectionString);
                    
                    ctx.GetTable<T>().Attach(record);
                    ctx.Refresh(RefreshMode.KeepCurrentValues, record);
                    ctx.SubmitChanges();
                }
            }

        }
    }
}
