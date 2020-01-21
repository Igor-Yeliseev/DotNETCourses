using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Represents a class about the result of passing one exam / credit
    /// </summary>
    public class SessionResult
    {
        /// <summary>
        /// Record Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// Exam Id
        /// </summary>
        public int ExamID { get; set; }

        /// <summary>
        /// Exam grade
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Initializes a new instance of the SessionResult class
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <param name="studentId"> Student Id</param>
        /// <param name="examId"> Exam Id</param>
        /// <param name="grade"> Exam grade</param>
        public SessionResult(int id, int studentId, int examId, int grade)
        {
            ID = id;
            StudentID = studentId;
            ExamID = examId;
            Grade = grade;
        }

        /// <summary>
        /// Initializes a new instance of the SessionResult class
        /// </summary>
        /// <param name="studentId"> Student Id</param>
        /// <param name="examId"> Exam Id</param>
        /// <param name="grade"> Exam grade</param>
        public SessionResult(int studentId, int examId, int grade)
        {
            StudentID = studentId;
            ExamID = examId;
            Grade = grade;
        }
    }
}
