using System;
using System.Collections.Generic;
using System.Linq;
using DBClassLibrary;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TestDataBase
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["task6ConnectionString"].ConnectionString;
            //string connectionString = "server=localhost; port=3306; user=root; database=universitydb; password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                MySqlDataReader reader = null;

                MySqlCommand command = new MySqlCommand("SELECT * FROM students", connection);

                reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(Convert.ToString(reader.GetValue(i)) + ";  ");
                        }
                        Console.WriteLine();
                    }
                }

                reader.Close();

                Console.ReadLine();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Закрытие соединения с базой данных
                connection.Close();
                Console.WriteLine("Соединение было закрыто");
            }
        }
    }
}
