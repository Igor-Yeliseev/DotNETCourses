using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinaryTreeLibrary;

namespace NUnitTests
{
    [TestFixture]
    public class UnitTest
    {
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
        [Test]
        public void TestTree()
        {


        }
    }
}
