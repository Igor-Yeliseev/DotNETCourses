using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// Enum representing types of the tests
    /// </summary>
    public enum TestName
    {
        /// <summary>
        /// Economics test
        /// </summary>
        Economics = 1,
        /// <summary>
        /// Physics test
        /// </summary>
        Physics,
        /// <summary>
        /// Programming test
        /// </summary>
        Programming,
        /// <summary>
        /// Literature test
        /// </summary>
        Literature,
        /// <summary>
        /// Geography test
        /// </summary>
        Geography
    }

    /// <summary>
    /// A class representing a student
    /// </summary>
    [Serializable]
    public class Student : IComparable
    {
        /// <summary>
        /// Student name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Test name
        /// </summary>
        public TestName Test { get; set; }

        /// <summary>
        /// Test date
        /// </summary>
        public DateTime TestDate { get; set; }
        
        /// <summary>
        /// Test score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        /// <param name="name"> Student name</param>
        /// <param name="testName"> Test name</param>
        /// <param name="score"> Test score</param>
        public Student(string name, TestName testName, int score)
        {
            Name = name;
            Test = testName;

            if (score >= 0 && score < 11)
            {
                Score = score;
            }
            else
            {
                throw new Exception("Invalid value of the test score.");
            }
            
        }

        /// <summary>
        /// Initializes a new instance of the Student class
        /// </summary>
        public Student()
        {

        }

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj"> An object to compare with this instance.</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Student otherStudent = obj as Student;

            if(otherStudent != null)
            {
                return Score.CompareTo(otherStudent.Score);
            }
            else
            {
                throw new ArgumentException("Object is not a Student");
            }
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

            return (Name.Equals(stud.Name) && Score.Equals(stud.Score) &&
                    Test.Equals(stud.Test));
        }

        /// <summary>
        /// Get a hash code for the current object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (23 + Score.GetHashCode() + Name.GetHashCode());
        }
    }
}
