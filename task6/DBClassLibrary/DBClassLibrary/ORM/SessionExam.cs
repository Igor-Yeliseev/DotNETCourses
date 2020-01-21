using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Represents a session exam class
    /// </summary>
    public class SessionExam
    {
        /// <summary>
        /// Record Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupID { get; set; }
        
        /// <summary>
        /// Subject Id
        /// </summary>
        public int SubjectID { get; set; }

        /// <summary>
        /// Type of exam (credit / exam) 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Exam date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Initializes a new instance of the SessionExam class
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <param name="groupId"> Group Id</param>
        /// <param name="subjectId"> Subject Id</param>
        /// <param name="type"> Type of exam (credit / exam)</param>
        /// <param name="date"> Exam date</param>
        public SessionExam(int id, int groupId, int subjectId, string type, DateTime date)
        {
            ID = id;
            GroupID = groupId;
            SubjectID = subjectId;
            Type = type;
            Date = date;
        }

        /// <summary>
        /// Initializes a new instance of the SessionExam class
        /// </summary>
        /// <param name="groupId"> Group Id</param>
        /// <param name="subjectId"> Subject Id</param>
        /// <param name="type"> Type of exam (credit / exam)</param>
        /// <param name="date"> Exam date</param>
        public SessionExam(int groupId, int subjectId, string type, DateTime date)
        {
            GroupID = groupId;
            SubjectID = subjectId;
            Type = type;
            Date = date;
        }
    }
}
