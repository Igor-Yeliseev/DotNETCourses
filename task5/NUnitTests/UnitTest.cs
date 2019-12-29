using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryTreeLibrary;

namespace NUnitTests
{
    /// <summary>
    /// Unit tests class
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        /// <summary>
        /// Binary tree of students
        /// </summary>
        Tree<Student> tree = new Tree<Student>();
        /// <summary>
        /// Students array
        /// </summary>
        Student[] students = null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public UnitTest()
        {
            students = new Student[6];
            students[0] = new Student("Peter", TestName.Literature, 6);
            students[1] = new Student("Vova", TestName.Literature, 3);
            students[2] = new Student("Sasha", TestName.Literature, 8);
            students[3] = new Student("Igor", TestName.Literature, 7);
            students[4] = new Student("Alex", TestName.Literature, 9);
            students[5] = new Student("Jane", TestName.Literature, 1);

            tree.Add(students[0]);
            tree.Add(students[1]);
            tree.Add(students[2]);
            tree.Add(students[3]);
            tree.Add(students[4]);
            tree.Add(students[5]);
        }


        /// <summary>
        /// Testing of Student class
        /// </summary>
        [TestCase(6, 8, -1)]
        [TestCase(10, 4, 1)]
        [TestCase(5, 5, 0)]
        [TestCase(2, 8, -1)]
        [TestCase(0, 10, -1)]
        [TestCase(10, 0, 1)]
        public void TestCompareTestScores(int score1, int score2, int expected)
        {
            Student peter = new Student("Peter", TestName.Literature, score1);
            Student vova = new Student("Vova", TestName.Economics, score2);

            int actual = peter.CompareTo(vova);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Testing of correct score values
        /// </summary>
        /// <param name="score"></param>
        [TestCase(-2)]
        [TestCase(12)]
        [TestCase(-10)]
        [TestCase(20)]
        public void TestCorrectScoreValues(int score)
        {
            TestDelegate func = delegate
            {
                Student frank = new Student("Peter", TestName.Literature, score);
            };

            Assert.Catch(func);
        }

        /// <summary>
        /// Testing of a binary tree
        /// </summary>
        [TestCase(5, "3; 6; 7; 8; 9; ")]
        [TestCase(2, "3; 6; 7; 9; ")]
        [TestCase(3, "3; 6; 9; ")]
        [TestCase(0, "3; 9; ")]
        [TestCase(4, "3; ")]
        public void TestTreeRemove(int studentIndex, string sortScores)
        {
            Student student = students[studentIndex];
            
            // Node search function by data
            Node<Student> node = tree.Search(student);

            Assert.AreEqual(student, node.Data);

            tree.Root = tree.Remove(tree.Root, student);
            
            string actualScores = null;

            foreach (Student stud in tree.InOrderTraversal())
            {
                actualScores += stud.Score.ToString() + "; ";
            }

            Assert.AreEqual(sortScores, actualScores);
        }

        /// <summary>
        /// Tree Balance Testing
        /// </summary>
        [Test]
        public void TestBalancing()
        {
            Tree<int> tree = new Tree<int>();

            tree.Add(6);
            tree.Add(5);
            tree.Add(4);
            tree.Add(8);
            tree.Add(9);
            tree.Add(10);
            tree.Add(20);

            /*   Before
             *     6
             *   5   8
             * 4       9
             *          10
             *            11
             *            
             */

            /*     After
             *       8
             *    5    10
             *  4  6  9  20
             *
            */

            tree.Balance();

            var node6 = tree.Search(6); 
            var node5 = tree.Search(5); 
            var node4 = tree.Search(4); 
            var node8 = tree.Search(8); 
            var node9 = tree.Search(9); 
            var node10 = tree.Search(10); 
            var node20 = tree.Search(20);

            Assert.IsTrue(node5.Right == node6 && node5.Left == node4 &&
                          node8.Right == node10 && node8.Left == node5 &&
                          node10.Right == node20 && node10.Left == node9 &&
                          node4.Right == null && node4.Left == null &&
                          node6.Right == null && node6.Left == null);
        }

        /// <summary>
        /// Testing of xml serialisation
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            Student peter = new Student("Peter", TestName.Physics, 7);
            Student john = new Student("John", TestName.Geography, 7);
            Student frank = new Student("Frank", TestName.Economics, 8);
            Student robert = new Student("Robert", TestName.Economics, 10);

            Tree<Student> tree = new Tree<Student>();

            tree.Add(peter);
            tree.Add(john);
            tree.Add(frank);
            tree.Add(robert);

            string path = AppDomain.CurrentDomain.BaseDirectory + "/binaryTree.xml";

            TreeSerializer.Serialize(tree, path);

            Tree<Student> treeDeser = TreeSerializer.Deserialize(path);

            Assert.AreEqual(tree.Count, treeDeser.Count);
        }
    }
}
