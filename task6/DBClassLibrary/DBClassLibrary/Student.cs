using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClassLibrary
{
    /// <summary>
    /// Student gender
    /// </summary>
    enum Sex
    {
        /// <summary>
        /// Male
        /// </summary>
        Male = 1,
        /// <summary>
        /// Female
        /// </summary>
        Female
    }

    /// <summary>
    /// Represents a student class
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Student last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Student middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Student Id
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Student gender
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// Group Id
        /// </summary>
        public int GroupID { get; set; }

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
        public Student(int id, string lastName, string firstName, string middleName, string gender, int groupId, DateTime birthDate)
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
        public Student(string lastName, string firstName, string middleName, string gender, int groupId, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            GroupID = groupId;
            Sex = gender;
            BirthDate = birthDate;
        }
    }
}
