using DBTask7ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data.Linq;

namespace DBConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["task7ConnectionString"].ConnectionString;
            
            DataContext db = new DataContext(connectionString);

            var allStuds = from student in db.GetTable<Student>()
                        select student;

            Console.Write("Нажмите Enter для старта");
            Console.ReadLine();

            foreach (var st in allStuds)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", st.ID, st.LastName, st.FirstName, st.MiddleName, st.GroupID);
            }

            Console.ReadLine();
        }
    }
}
