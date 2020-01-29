using System;
using System.Data.Linq.Mapping;

namespace DBTask7ClassLibrary
{
    /// <summary>
    /// Represents a session exam class
    /// </summary>
    [Table(Name = "sessionexams")]
    public class SessionExam
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Group Id
        /// </summary>
        [Column(Name = "GroupID")]
        public int GroupID { get; set; }

        /// <summary>
        /// Subject Id
        /// </summary>
        [Column(Name = "SubjectID")]
        public int SubjectID { get; set; }

        /// <summary>
        /// Type of exam (credit / exam) 
        /// </summary>
        [Column(Name = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// Exam date
        /// </summary>
        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Session number
        /// </summary>
        [Column(Name = "SessionNumber")]
        public int SessionNumber { get; set; }

        /// <summary>
        /// Initializes a new instance of the SessionExam class
        /// </summary>
        /// <param name="id"> Record Id</param>
        /// <param name="groupId"> Group Id</param>
        /// <param name="subjectId"> Subject Id</param>
        /// <param name="type"> Type of exam (credit / exam)</param>
        /// <param name="sessNumber"> Session number</param>
        /// <param name="date"> Exam date</param>
        public SessionExam(int id, int groupId, int subjectId, string type, int sessNumber, DateTime date)
        {
            ID = id;
            GroupID = groupId;
            SubjectID = subjectId;
            Type = type;
            SessionNumber = sessNumber;
            Date = date;
        }

        /// <summary>
        /// Initializes a new instance of the SessionExam class
        /// </summary>
        /// <param name="groupId"> Group Id</param>
        /// <param name="subjectId"> Subject Id</param>
        /// <param name="type"> Type of exam (credit / exam)</param>
        /// <param name="sessNumber"> Session number</param>
        /// <param name="date"> Exam date</param>
        public SessionExam(int groupId, int subjectId, string type, int sessNumber, DateTime date)
        {
            GroupID = groupId;
            SubjectID = subjectId;
            Type = type;
            SessionNumber = sessNumber;
            Date = date;
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

            SessionExam exm = obj as SessionExam;
            if (exm == null)
                return false;

            return (ID.Equals(exm.ID) && GroupID.Equals(exm.GroupID) &&
                    SubjectID.Equals(exm.SubjectID) && Type.Equals(exm.Type) &&
                    Date.Equals(exm.Date));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ID.GetHashCode() + 37 - GroupID.GetHashCode() - SubjectID.GetHashCode());
        }
    }
}
