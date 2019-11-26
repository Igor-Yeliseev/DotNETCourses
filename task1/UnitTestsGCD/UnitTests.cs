using System;
using GreatestCommonDivisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsGCD
{
    [TestClass]
    public class UnitTests
    {
        /// <summary>
        /// GCD test for 2 numbers
        /// </summary>
        [TestMethod]
        public void Test1_EuclideanGCD()
        {
            // arrange
            int expected = 21;

            // act
            int a = 1071;
            int b = 462;
            int answer = GCD.EuclideanGCD(a, b);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test2_EuclideanGCD()
        {
            // arrange
            int expected = 17;

            // act
            int a = 527;
            int b = 748;
            int answer = GCD.EuclideanGCD(a, b);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test3_EuclideanGCD()
        {
            // arrange
            int expected = 44;

            // act
            int a = 44;
            int b = 44;
            long time;
            int answer = GCD.EuclideanGCD(a, b, out time);

            // assert
            Assert.AreEqual(expected, answer);
        }


        [TestMethod]
        public void Test4_EuclideanGCD()
        {
            // arrange
            int expected = 6;

            // act
            int a = 78;
            int b = 294;
            int c = 570;
            int answer = GCD.EuclideanGCD(a, b, c);

            // assert
            Assert.AreEqual(expected, answer);
        }


        [TestMethod]
        public void Test5_EuclideanGCD()
        {
            // arrange
            int expected = 6;

            // act
            int a = 78;
            int b = 294;
            int c = 570;
            int d = 612;
            int answer = GCD.EuclideanGCD(a, b, c, d);

            // assert
            Assert.AreEqual(expected, answer);
        }


        [TestMethod]
        public void Test6_EuclideanGCD()
        {
            // arrange
            int expected = 23;

            // act
            int a = 161;
            int b = 253;
            int c = 230;
            int d = 529;
            int e = 437;
            int answer = GCD.EuclideanGCD(a, b, c, d, e);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test1_SteinGCD()
        {
            // arrange
            int expected = 23;

            // act
            int a = 161;
            int b = 253;
            long time;
            int answer = GCD.SteinGCD(a, b, out time);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test2_SteinGCD()
        {
            // arrange
            int expected = 23;

            // act
            int a = 161;
            int b = 253;
            long time;
            int answer = GCD.SteinGCD(a, b, out time);

            // assert
            Assert.AreEqual(expected, answer);
        }

        [TestMethod]
        public void Test3_SteinGCD()
        {
            // arrange
            int expected = 22826;

            // act
            int a = 26295552;
            int b = 13124950;
            long time;
            int answer = GCD.SteinGCD(a, b, out time);

            // assert
            Assert.AreEqual(expected, answer);
        }
    }
}
