using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DBClassLibrary;
using DBClassLibrary.DAO;
using MySql.Data.MySqlClient;
using NUnit.Framework;

namespace NUnitTests
{
    /// <summary>
    /// Unit tests class
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        MySqlConnection connection = null;
        string connectionString = null;

        /// <summary>
        /// Initializes a new instance of the UnitTest class
        /// </summary>
        public UnitTest()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Testing of Data base connection
        /// </summary>
        [Test]
        public void TestDataBase()
        {
            string rowStr = null;
            string expected = "1;  Синицин;  Евгений;  Михайлович;  2;  муж;  20.04.1999 0:00:00;  ";

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM students", connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                //Console.Write(Convert.ToString(reader.GetValue(i)) + ";  ");
                                rowStr += Convert.ToString(reader.GetValue(i)) + ";  ";
                            }
                            break;
                            //Console.WriteLine();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            Assert.AreEqual(expected, rowStr);
        }

        /// <summary>
        /// Testing of Data base connection
        /// </summary>
        [Test]
        public void TestDBInitialize()
        {
            DBInitializer.InsertGroups(connectionString);

            DBInitializer.InsertSubjects(connectionString);

            DBInitializer.InsertStudents(connectionString);

            DBInitializer.InsertExams(connectionString);
        }

        /// <summary>
        /// Testing CRUD operations for Student factory
        /// </summary>
        [Test]
        public void TestDaoStudentsCRUD()
        {
            DaoStudents daoStudents = new DaoStudents(connectionString);

            var allStudents = daoStudents.GetAllRecords();
            int count = allStudents.Count;

            Student student1 = new Student("Sinatra", "Frank", "Petrovich", 2, "male", new DateTime(1915, 4, 17));

            daoStudents.Create(student1);

            allStudents = daoStudents.GetAllRecords();
            Assert.AreEqual(count + 1, allStudents.Count);

            student1.ID = allStudents.Last().ID;

            student1.LastName = "Eliseev";
            student1.FirstName = "Igor";
            student1.MiddleName = "Andreevich";
            student1.BirthDate = new DateTime(1998, 3, 5);

            daoStudents.Update(student1);

            Student updStudent = daoStudents.GetById(student1.ID);
            Assert.AreEqual(student1, updStudent);
            
            daoStudents.Delete(student1);
            Assert.AreEqual(count, daoStudents.GetAllRecords().Count);
        }

        /// <summary>
        /// Testing CRUD operations for Groups factory
        /// </summary>
        [Test]
        public void TestDaoGroupsCRUD()
        {
            DaoGroups daoGroups = new DaoGroups(connectionString);

            var allGroups = daoGroups.GetAllRecords();
            int count = allGroups.Count;

            Group group = new Group("ITP-21");

            daoGroups.Create(group);

            allGroups = daoGroups.GetAllRecords();
            Assert.AreEqual(count + 1, allGroups.Count);

            group.ID = allGroups.Last().ID;

            group.Name = "PVP-21";

            daoGroups.Update(group);

            Group updGroup = daoGroups.GetById(group.ID);
            Assert.AreEqual(group, updGroup);

            daoGroups.Delete(group);
            Assert.AreEqual(count, daoGroups.GetAllRecords().Count);
        }

        /// <summary>
        /// Testing CRUD operations for SessionExams factory
        /// </summary>
        [Test]
        public void TestDaoSessionExamsCRUD()
        {
            DaoSessionExams daoExams = new DaoSessionExams(connectionString);

            var allExams = daoExams.GetAllRecords();
            int count = allExams.Count;

            SessionExam exam = new SessionExam(2, 8, "exam", new DateTime(2020, 12, 21));
            daoExams.Create(exam);

            allExams = daoExams.GetAllRecords();
            Assert.AreEqual(count + 1, allExams.Count);

            exam.ID = allExams.Last().ID;

            exam.GroupID = 3;
            exam.SubjectID = 3;

            daoExams.Update(exam);

            SessionExam updExam = daoExams.GetById(exam.ID);
            Assert.AreEqual(exam, updExam);

            daoExams.Delete(exam);
            Assert.AreEqual(count, daoExams.GetAllRecords().Count);
        }
    }
}
