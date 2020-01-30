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
        protected DataContext db;
        Type type;

        /// <summary>
        /// Initializes a new instance of the Dao class
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public Dao(string connectionString)
        {
            this.connectionString = connectionString;
            db = new DataContext(connectionString);
            type = typeof(T);
        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public void Create(T record)
        {
            db.GetTable(type).InsertOnSubmit(record);
            db.SubmitChanges();
        }

        /// <summary>
        /// Delete a record from a table
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public void Delete(T record)
        {
            db.GetTable(type).DeleteOnSubmit(record);
            db.SubmitChanges();
        }

        /// <summary>
        /// Get all records from table
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllRecords()
        {
            var table = db.GetTable(type);

            List<T> records = new List<T>();

            foreach (var row in table)
            {
                records.Add((T)row);
            }

            return records;
        }

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <returns></returns>
        public abstract T GetById(int id);

        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        public void Update(T record)
        {
            //Object newObj = Activator.CreateInstance(typeof(T), new object[0]);
            //PropertyDescriptorCollection originalProps = TypeDescriptor.GetProperties(record);

            //foreach (PropertyDescriptor currentProp in originalProps)
            //{
            //    if(currentProp.Attributes[typeof(System.Data.Linq.Mapping.ColumnAttribute)] != null)
            //    {
            //        object val = currentProp.GetValue(record);

            //        currentProp.SetValue(newObj, val);
            //    }
            //}

            //var original = (from row in db.GetTable(type).Cast<T>()
            //            where row.ID == record.ID
            //            select row).Single();

            var original = db.GetTable(type).Cast<T>().FirstOrDefault(r => r.ID == record.ID);

            var fields = type.GetProperties();


            //for (int i = 0; i < fields.Length; i++)
            //{
            //    type.GetProperty(fields[i].Name).SetValue(original, type.GetProperty(fields[i].Name).GetValue(record));
            //}

            //original.ID = 19;

            db.GetTable<T>().Attach(original, record);
            db.SubmitChanges();
        }
    }
}
