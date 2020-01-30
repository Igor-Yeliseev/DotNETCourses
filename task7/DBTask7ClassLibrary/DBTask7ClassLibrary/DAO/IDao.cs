using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.DAO
{
    /// <summary>
    /// Interface DAO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDao<T>
    {
        /// <summary>
        /// Update specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        void Update(T record);
        /// <summary>
        /// Delete specific record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        void Delete(T record);
        /// <summary>
        /// Add a new record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        void Create(T record);
        /// <summary>
        /// Get all records from table
        /// </summary>
        /// <returns></returns>
        List<T> GetAllRecords();
    }
}
