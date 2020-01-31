using DBTask7ClassLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTask7ClassLibrary.ExcelExport
{
    /// <summary>
    /// Represents a class for session reports and some other university data
    /// </summary>
    public class Reports
    {
        private DaoSpecialties daoSpecialties;
        private DaoExaminators daoExaminators;
        private DaoGroups daoGroup;
        private DaoSubjects daoSubject;
        private DaoStudents daoStudent;
        private DaoSessionExams daoExams;
        private DaoSessionResults daoResults;

        /// <summary>
        /// Initializes a new instance of the Report class
        /// </summary>
        /// <param name="daoFactory"> Dao factory</param>
        public Reports(DaoFactory daoFactory)
        {
            daoSpecialties = daoFactory.GetDaoSpecialties();
            daoExaminators = daoFactory.GetDaoExaminators();
            daoGroup = daoFactory.GetDaoGroups();
            daoSubject = daoFactory.GetDaoSubjects();
            daoStudent = daoFactory.GetDaoStudents();
            daoExams = daoFactory.GetDaoSessExams();
            daoResults = daoFactory.GetDaoSessResults();
        }

        /// <summary>
        /// Get student session results
        /// </summary>
        /// <param name="sessionNumber"> Session number</param>
        /// <param name="groupName"> Group name</param>
        /// <returns></returns>
        public List<ReportSessionStudent> GetStudentsResults(int sessionNumber, string groupName)
        {
            var students = daoStudent.GetAllRecords();
            var subjects = daoSubject.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();

            int id = groups.Where(x => x.Name == groupName).Select(x => x.ID).First();

            List<ReportSessionStudent> studs = new List<ReportSessionStudent>();

            var allResults = from result in results
                             join exam in exams on result.ExamID equals exam.ID
                             join sbj in subjects on exam.SubjectID equals sbj.ID
                             join grp in groups on exam.GroupID equals grp.ID
                             join student in students on result.StudentID equals student.ID
                             where exam.SessionNumber == sessionNumber & exam.GroupID == id
                             select new
                             {
                                 LastName = student.LastName,
                                 FirstName = student.FirstName,
                                 MiddleName = student.MiddleName,
                                 GroupName = grp.Name,
                                 SubjectName = sbj.Name,
                                 ExamType = exam.Type,
                                 Grade = result.Grade
                             };

            foreach (var st in allResults.OrderBy(s => s.Grade).ThenBy(s => s.LastName))
            {
                studs.Add(new ReportSessionStudent()
                {
                    LastName = st.LastName,
                    FirstName = st.FirstName,
                    MiddleName = st.MiddleName,
                    GroupName = st.GroupName,
                    SubjectName = st.SubjectName,
                    ExamType = st.ExamType,
                    Grade = st.Grade
                });

            }

            return studs;
        }

        /// <summary>
        /// Get group session results
        /// </summary>
        /// <returns></returns>
        public List<ReportSessionGroup> GetGroupResults()
        {
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();

            var myGroups = exams.GroupBy(g => g.GroupID).Where(w => w.Count() >= 1).Select(s => s.Key);

            List<ReportSessionGroup> groupResults = new List<ReportSessionGroup>();

            foreach (var item in myGroups)
            {
                var allResults = from result in results
                                 join exam in exams on result.ExamID equals exam.ID
                                 join grp in groups on exam.GroupID equals grp.ID
                                 where exam.GroupID == item
                                 select result;

                int minGrade = allResults.Min(x => x.Grade);
                int maxGrade = allResults.Max(x => x.Grade);
                double avgGrade = allResults.Average(x => x.Grade);
                string groupName = groups.Where(x => x.ID == item).Select(x => x.Name).First();

                groupResults.Add(new ReportSessionGroup()
                {
                    GroupName = groupName,
                    MaxGrade = maxGrade,
                    MinGrade = minGrade,
                    AverageGrade = avgGrade
                });
            }

            return groupResults;
        }

        /// <summary>
        /// Get all students to be expelled
        /// </summary>
        /// <returns></returns>
        public List<ReportBadStudent> GetBadStudents()
        {
            var students = daoStudent.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var results = daoResults.GetAllRecords();

            List<ReportBadStudent> badStudents = new List<ReportBadStudent>();

            var allResults = from student in students
                             join result in results on student.ID equals result.StudentID
                             where result.Grade < 4
                             select student;

            var badOnes = allResults.GroupBy(g => g.ID).Select(g => g.First());

            foreach (var g in badOnes.Distinct().OrderBy(s => s.FirstName).GroupBy(g => g.GroupID))
            {
                foreach (var x in g)
                {
                    badStudents.Add(new ReportBadStudent()
                    {
                        LastName = x.LastName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        Sex = x.Sex,
                        GroupName = groups.Where(s => s.ID == x.GroupID).Select(s => s.Name).First(),
                        BirthDate = x.BirthDate
                    });
                }
            }

            return badStudents;
        }

        /// <summary>
        /// Get session results for specialties
        /// </summary>
        /// <param name="sessionNumber"> Session number</param>
        /// <returns></returns>
        public List<ReportSessionSpecialty> GetSpecialtiesResults(int sessionNumber)
        {
            var specialties = daoSpecialties.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();
            
            List<ReportSessionSpecialty> specsResults = new List<ReportSessionSpecialty>();

            var allResults = from result in results
                             join exam in exams on result.ExamID equals exam.ID
                             join grp in groups on exam.GroupID equals grp.ID
                             join spec in specialties on grp.ID equals spec.ID 
                             where exam.SessionNumber == sessionNumber
                             select new { exam.GroupID, spec.Name, exam.SessionNumber, result.Grade };
            
            foreach (var g in allResults.GroupBy(x => x.GroupID))
            {
                string name = g.First().Name;
                int snumber = g.First().SessionNumber;
                double avgGrade = g.Average(x => x.Grade);
                
                specsResults.Add(new ReportSessionSpecialty
                {
                    SpecialtyName = name,
                    SessionNumber = snumber,
                    AvgGrade = avgGrade
                });
                
            }

            return specsResults;
        }

        /// <summary>
        ///  Get results for examinators
        /// </summary>
        /// <param name="sessionNumber"> Session number</param>
        /// <returns></returns>
        public List<ReportSessionExaminator> GetExaminatorsResults(int sessionNumber)
        {
            var examinators = daoExaminators.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();

            List<ReportSessionExaminator> exmtrsResults = new List<ReportSessionExaminator>();

            var allResults = from result in results
                             join exam in exams on result.ExamID equals exam.ID
                             join grp in groups on exam.GroupID equals grp.ID
                             join extr in examinators on exam.ExaminatorID equals extr.ID
                             where exam.SessionNumber == sessionNumber
                             select new { exam.ExaminatorID, extr.FullName, exam.SessionNumber, result.Grade };

            foreach (var g in allResults.GroupBy(x => x.ExaminatorID))
            {
                string name = g.First().FullName;
                int snumber = g.First().SessionNumber;
                double avgGrade = g.Average(x => x.Grade);

                exmtrsResults.Add(new ReportSessionExaminator
                {
                    ExaminatorName = name,
                    SessionNumber = snumber,
                    AvgGrade = avgGrade
                });
            }

            return exmtrsResults;
        }

        /// <summary>
        /// Get the dynamics of changes in the average grade for subjects for all sessions
        /// </summary>
        /// <returns></returns>
        public List<ReportSessionsSubject> GetSubjectsResults()
        {
            var subjects = daoSubject.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();

            List<ReportSessionsSubject> sbjResults = new List<ReportSessionsSubject>();

            var allResults = from result in results
                             join exam in exams on result.ExamID equals exam.ID
                             join sbj in subjects on exam.SubjectID equals sbj.ID
                             select new { exam.SubjectID, sbj.Name, exam.SessionNumber, result.Grade };
            

            foreach (var s in allResults.GroupBy(x => x.SubjectID))
            {
                string name = s.First().Name;
                var obj = new ReportSessionsSubject() { SubjectName = name};

                foreach (var g in s.GroupBy(x => x.SessionNumber))
                {
                    double avgGrade = g.Average(x => x.Grade);
                    obj.AvgGrades.Add(avgGrade);
                }
                sbjResults.Add(obj);
            }

            return sbjResults;
        }
    }
}
