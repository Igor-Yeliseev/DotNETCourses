using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Abstract DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Dao <T>
    {
        /// <summary>
        /// Get all records from table
        /// </summary>
        /// <returns></returns>
        public abstract List<T> GetAllRecords();
        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T GetById(int id);
        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        public abstract void Update(T record);
        /// <summary>
        /// Delete specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public abstract bool Delete(T record);
        /// <summary>
        /// Add a new record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public abstract bool Create(T record);
        /// <summary>
        /// Get the number of records
        /// </summary>
        /// <returns></returns>
        public abstract int GetRecordsCount();
    }
}
