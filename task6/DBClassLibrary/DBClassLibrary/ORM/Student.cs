using System;

namespace DBClassLibrary
{
    /// <summary>
    /// Represents a student class
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Student last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Student first name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Student middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// Student gender
        /// </summary>
        public string Sex { get; set; }
        
        /// <summary>
        /// Birth date 
        /// </summary>
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        /// <param name="id"> Student Id</param>
        /// <param name="lastName"> Student last name</param>
        /// <param name="firstName"> Student first name</param>
        /// <param name="middleName"> Student middle name</param>
        /// <param name="gender"> Student gender</param>
        /// <param name="groupId"> Group Id</param>
        /// <param name="birthDate"> Student's date of birth</param>
        public Student(int id, string lastName, string firstName, string middleName, int groupId, string gender, DateTime birthDate)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            GroupID = groupId;
            Sex = gender;
            BirthDate = birthDate;
        }
        
        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        /// <param name="lastName"> Student last name</param>
        /// <param name="firstName"> Student first name</param>
        /// <param name="middleName"> Student middle name</param>
        /// <param name="gender"> Student gender</param>
        /// <param name="groupId"> Group Id</param>
        /// <param name="birthDate"> Student's date of birth</param>
        public Student(string lastName, string firstName, string middleName, int groupId, string gender, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            GroupID = groupId;
            Sex = gender;
            BirthDate = birthDate;
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

            Student stud = obj as Student;
            if (stud == null)
                return false;

            return (FirstName.Equals(stud.FirstName) && LastName.Equals(stud.LastName) &&
                    MiddleName.Equals(stud.MiddleName) && GroupID.Equals(stud.GroupID) &&
                    Sex.Equals(stud.Sex) && BirthDate.Equals(stud.BirthDate));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (LastName.GetHashCode() + 31 - FirstName.GetHashCode());
        }
    }
}
