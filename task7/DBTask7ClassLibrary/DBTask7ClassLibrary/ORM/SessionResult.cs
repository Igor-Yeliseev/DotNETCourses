using System.Data.Linq.Mapping;

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Represents a class about the result of passing one exam / credit
    /// </summary>
    [Table(Name = "sessionresults")]
    public class SessionResult : IRecord
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        [Column(Name = "StudentID")]
        public int StudentID { get; set; }

        /// <summary>
        /// Exam Id
        /// </summary>
        [Column(Name = "ExamID")]
        public int ExamID { get; set; }

        /// <summary>
        /// Exam grade
        /// </summary>
        [Column(Name = "Grade")]
        public int Grade { get; set; }

        /// <summary>
        /// Initializes a new instance of the SessionResult class
        /// </summary>
        public SessionResult()
        {

        }

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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SessionResult res = obj as SessionResult;
            if (res == null)
                return false;

            return (ID.Equals(res.ID) && StudentID.Equals(res.StudentID) &&
                    ExamID.Equals(res.ExamID) && Grade.Equals(res.Grade));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ID.GetHashCode() * 2 - StudentID.GetHashCode() - Grade.GetHashCode());
        }
    }
}
