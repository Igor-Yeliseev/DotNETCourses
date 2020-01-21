using System;
using System.Reflection;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DBClassLibrary.DAO
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DaoFactory<T> : Dao<T>
    {

        private string connectionString = null;

        /// <summary>
        /// Dao 
        /// </summary>
        /// <param name="connectionString"> Connection string to data base</param>
        public DaoFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public override bool Create(T record)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a record from a table
        /// </summary>
        /// <param name="record"> Record instance</param>
        /// <returns></returns>
        public override bool Delete(T record)
        {
            int answer = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                Type type = record.GetType();

                string table = type.Name.ToLower() + 's';

                PropertyInfo idProp = type.GetProperty("ID");

                string query = $"DELETE FROM {table} WHERE ID = {idProp}";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@ID", idProp.GetValue(record));

                answer = command.ExecuteNonQuery();
            }

            return (answer > 0) ? true : false;
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="record"> Record instance</param>
        public override void Update(T record)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all records from a table
        /// </summary>
        /// <returns></returns>
        public override List<T> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <returns></returns>
        public override T GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the number of records
        /// </summary>
        /// <returns></returns>
        public override int GetRecordsCount()
        {
            throw new NotImplementedException();
        }
        
    }
}
