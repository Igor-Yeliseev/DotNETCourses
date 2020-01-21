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
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Type type = record.GetType();
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name.ToLower() + "s";

                connection.Open();

                string columns = "";
                string values = "";

                MySqlCommand command = new MySqlCommand();

                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "ID")
                        continue;
                    
                    columns += field.Name + ", ";
                    values += "@" + field.Name + ", ";

                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(record));
                }
                
                columns = columns.TrimEnd(new char[] { ',', ' ' });
                values = values.TrimEnd(new char[] { ',', ' ' });

                string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";

                command.Connection = connection;
                command.CommandText = query;
                int answer = command.ExecuteNonQuery();

                return (answer > 0) ? true : false;
            }
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
                string id = "@" + idProp.Name;

                string query = $"DELETE FROM {table} WHERE ID = {id}";

                MySqlCommand command = new MySqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@ID", idProp.GetValue(record));

                answer = command.ExecuteNonQuery();
            }
            return (answer > 0) ? true : false;
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="record"> Record instance</param>
        public override void Update(T record)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string correctedData = "";
                
                Type type = record.GetType();
                PropertyInfo idProp = type.GetProperty("ID");
                string id = "@" + idProp.Name;

                connection.Open();
                MySqlCommand command = new MySqlCommand();

                PropertyInfo[] classFields = type.GetProperties();

                string table = type.Name.ToLower() + "s";
                
                foreach (PropertyInfo field in classFields)
                {
                    if (!field.CanWrite || field.Name == "ID")
                        continue;

                    correctedData += field.Name + "= @" + field.Name + ", ";
                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(record));
                }

                correctedData = correctedData.TrimEnd(new char[] { ',', ' ' });

                string query = $"UPDATE {table} SET {correctedData} WHERE ID = {id}";
                command.Parameters.AddWithValue(id, idProp.GetValue(record));

                command.Connection = connection;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get all records from a table
        /// </summary>
        /// <returns></returns>
        public override List<T> GetAllRecords()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Type type = typeof(T);
                string table = type.Name.ToLower() + "s"; 
                PropertyInfo[] fields = type.GetProperties();

                connection.Open();

                string query = $"SELECT * FROM {table}";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<T> records = new List<T>();
                
                if(reader.HasRows)
                {
                    object[] args = new object[reader.FieldCount];

                    while(reader.Read())
                    {
                        if(reader.FieldCount != fields.Length)
                        {
                            throw new Exception($"Mismatch of the number of {typeof(T)} class fields and DataReader fields.");
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            args[i] = reader.GetValue(i);
                        }

                        T obj = (T)Activator.CreateInstance(typeof(T), args);
                        records.Add(obj);

                        Array.Clear(args, 0, reader.FieldCount);
                    }
                }
                else
                {
                    throw new Exception("There are no records in the table.");
                }

                return records;
            }
        }

        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <returns></returns>
        public override T GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Type type = typeof(T);
                string table = type.Name.ToLower() + "s";
                PropertyInfo[] fields = type.GetProperties();
                string query = $"SELECT * FROM {table} WHERE ID={id}";
            
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    object[] args = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        if (reader.FieldCount != fields.Length)
                        {
                            throw new Exception($"Mismatch of the number of {typeof(T)} class fields and DataReader fields.");
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            args[i] = reader.GetValue(i);
                        }
                    }

                    return (T)Activator.CreateInstance(typeof(T), args);
                }
                else
                {
                    throw new Exception("There are no records in the table.");
                }
            }
        }
    }
}
