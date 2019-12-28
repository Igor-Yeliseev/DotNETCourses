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
    public class Student : IComparable
    {
        /// <summary>
        /// Student name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Test name
        /// </summary>
        public TestName Test { get; private set; }

        /// <summary>
        /// Test date
        /// </summary>
        public DateTime TestDate { get; set; }

        private int score;

        /// <summary>
        /// Test score
        /// </summary>
        public int Score
        {
            get
            {
                return score;
            }
            private set
            {
                if (value >= 0 && value < 11)
                {
                    score = value;
                }
                else
                {
                    throw new Exception("Invalid value of the test score.");
                }
            }
        }

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
            Score = score;
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
            {
                throw new ArgumentException("Object is not a Student");
            }
        }
    }
}
