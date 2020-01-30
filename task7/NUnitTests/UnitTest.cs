using DBTask7ClassLibrary;
using DBTask7ClassLibrary.DAO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    /// <summary>
    /// Unit tests class
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        string connectionString = null;

        DaoFactory daoFactory;

        /// <summary>
        /// Initializes a new instance of the UnitTest class
        /// </summary>
        public UnitTest()
        {
            connectionString = ConfigurationManager.ConnectionStrings["task7ConnectionString"].ConnectionString;
            daoFactory = DaoFactory.GetInstance(connectionString);
        }

        /// <summary>
        /// Testing DBInitializer class
        /// </summary>
        [Test]
        public void TestInitDB()
        {
            DBInitializer.InsertData(connectionString);
        }
            
        /// <summary>
        /// Testing CRUD operations for Group factory
        /// </summary>
        [Test]
        public void TestDaoGroupsCRUD()
        {
            DaoGroups daoGroups = daoFactory.GetDaoGroups();

            Group group = new Group("TPT-22", 2);
            
            var allGroups = daoGroups.GetAllRecords();
            int count = allGroups.Count;

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
        /// Testing CRUD operations for Student factory
        /// </summary>
        [Test]
        public void TestDaoStudentsCRUD()
        {
            DaoStudents daoStudents = daoFactory.GetDaoStudents();

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
        /// Testing CRUD operations for SessionExam factory
        /// </summary>
        [Test]
        public void TestDaoSessionExamsCRUD()
        {
            DaoSessionExams daoExams = daoFactory.GetDaoSessExams();

            var allExams = daoExams.GetAllRecords();
            int count = allExams.Count;

            SessionExam exam = new SessionExam(2, 8, "exam", 1, new DateTime(2020, 12, 21));
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
