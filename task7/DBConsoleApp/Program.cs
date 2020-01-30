using DBTask7ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data.Linq;
using DBTask7ClassLibrary.DAO;

namespace DBConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["task7ConnectionString"].ConnectionString;

            //DBInitializer.InsertData(connectionString);

            DaoFactory daoFactory = DaoFactory.GetInstance(connectionString);
            var daoSubjects = daoFactory.GetDaoSubjects();

            Subject subject1 = new Subject("Двумерная визуализация");

            //daoSubjects.Create(subject1);


            subject1.Name = "DFDFFDFDFDDFD";
            subject1.ID = 19;

            daoSubjects.Update(subject1);

            //daoSubjects.Delete(subject1);

            Console.Write("Нажмите Enter для старта");
            Console.ReadLine();

            //foreach (var st in allStuds)
            //{
            //    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", st.ID, st.LastName, st.FirstName, st.MiddleName, st.GroupID);
            //}

            //Console.ReadLine();
        }
    }
}
