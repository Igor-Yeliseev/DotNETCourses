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


        [TestMethod]
        public void Test4EuclideanGCV()
        {
            // arrange
            int expected = 6;

            // act
            int a = 78;
            int b = 294;
            int c = 570;
            int answer = GCV.EuclideanGCV(a, b, c);

            // assert
            Assert.AreEqual(expected, answer);
        }


        [TestMethod]
        public void Test5EuclideanGCV()
        {
            // arrange
            int expected = 6;

            // act
            int a = 78;
            int b = 294;
            int c = 570;
            int d = 612;
            int answer = GCV.EuclideanGCV(a, b, c, d);

            // assert
            Assert.AreEqual(expected, answer);
        }


        [TestMethod]
        public void Test6EuclideanGCV()
        {
            // arrange
            int expected = 23;

            // act
            int a = 161;
            int b = 253;
            int c = 230;
            int d = 529;
            int e = 437;
            int answer = GCV.EuclideanGCV(a, b, c, d, e);

            // assert
            Assert.AreEqual(expected, answer);
        }
    }
}
