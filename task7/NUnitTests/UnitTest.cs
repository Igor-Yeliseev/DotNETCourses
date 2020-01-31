using DBTask7ClassLibrary;
using DBTask7ClassLibrary.DAO;
using DBTask7ClassLibrary.ExcelExport;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

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
        /// Testing object equality
        /// </summary>
        [Test]
        public void TestEntitiesEquals()
        {
            Examinator examinator1 = new Examinator(1, "Петр Петрович Иванов");
            Examinator examinator2 = new Examinator(1, "Петр Петрович Иванов");
            Assert.AreEqual(examinator1, examinator2);

            Specialty specialty1 = new Specialty(2, "Экономист");
            Specialty specialty2 = new Specialty(2, "Экономист");
            Assert.AreEqual(specialty1, specialty2);

            Student std1 = new Student(2, "Igor", "Yeliseev", "Andreevich", 1, "male", new DateTime(1999, 5, 22));
            Student std2 = new Student(2, "Igor", "Yeliseev", "Andreevich", 1, "male", new DateTime(1999, 5, 22));
            Assert.AreEqual(std1, std2);

            Subject sbj1 = new Subject(2, "Geography");
            Subject sbj2 = new Subject(2, "Geography");
            Assert.AreEqual(sbj1, sbj2);

            Group group1 = new Group(1, "IS-21", 1);
            Group group2 = new Group(1, "IS-21", 1);
            Assert.AreEqual(group1, group2);

            SessionExam exam1 = new SessionExam(21, 1, 2, "exam", 2, new DateTime(2020, 1, 12));
            SessionExam exam2 = new SessionExam(21, 1, 2, "exam", 2, new DateTime(2020, 1, 12));
            Assert.AreEqual(exam1, exam2);

            SessionResult result1 = new SessionResult(1, 1, 3, 8);
            SessionResult result2 = new SessionResult(1, 1, 3, 8);
            Assert.AreEqual(result1, result2);
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

        /// <summary>
        /// Testing save to Excel tables
        /// </summary>
        [Test]
        public void TestExcelExport()
        {
            Reports reports = new Reports(daoFactory);

            var specsResults = reports.GetSpecialtiesResults(2);
            ExcelExport.SaveToXlsx(@"D:\", "Specialties", specsResults);

            var extrsResults = reports.GetExaminatorsResults(2);
            ExcelExport.SaveToXlsx(@"D:\", "Examinators", extrsResults);

            var sbjResults = reports.GetSubjectsResults();
            ExcelExport.SaveToXlsx(@"D:\", "AllSessionsSubjects", sbjResults);

            var studentsResults = reports.GetStudentsResults(1, "ИТИ-31");
            var groupResults = reports.GetGroupResults();
            var badStudents = reports.GetBadStudents();

            ExcelExport.SaveToXlsx(@"D:\", "StudentsITI-21", studentsResults);
            ExcelExport.SaveToXlsx(@"D:\", "Groups", groupResults);
            ExcelExport.SaveToXlsx(@"D:\", "BadStudents", badStudents);

        }
    }
}
