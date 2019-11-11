using System;
using GreatestCommonDivisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsGCD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1EuclideanGCV()
        {
            // arrange
            int expected = 21;

            // act
            int a = 1071;
            int b = 462;
            int answer = GCV.EuclideanGCV(a, b);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test2EuclideanGCV()
        {
            // arrange
            int expected = 17;

            // act
            int a = 527;
            int b = 748;
            int answer = GCV.EuclideanGCV(a, b);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test3EuclideanGCV()
        {
            // arrange
            int expected = 44;

            // act
            int a = 44;
            int b = 44;
            int answer = GCV.EuclideanGCV(a, b);

            // assert
            Assert.AreEqual(expected, answer);
        }





    }
}
