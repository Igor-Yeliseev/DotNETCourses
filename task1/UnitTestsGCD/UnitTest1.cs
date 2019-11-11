using System;
using GreatestCommonDivisor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsGCD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEuclideanGCV()
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
    }
}
