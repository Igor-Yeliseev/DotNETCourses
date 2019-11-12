using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;

namespace UnitTestsVector
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1_Vector()
        {
            // arrange
            Vector expected = new Vector(0.0f, 2.0f, 4.0f);

            // act
            Vector vector = new Vector(0.0f, 1.0f, 2.0f);
            vector = 2.0f * vector;

            // assert
            Assert.AreEqual(expected, vector);
        }

        [TestMethod]
        public void Test2_Vector()
        {
            // arrange
            Vector expected = new Vector(-1.0f, 4.0f, 3.0f);

            // act
            Vector vector1 = new Vector(1.0f, 1.0f, 1.0f);
            Vector vector2 = new Vector(-2.0f, 3.0f, 2.0f);
            Vector vector3 = vector1 + vector2;

            // assert
            Assert.AreEqual(expected, vector3);
        }

        [TestMethod]
        public void Test3_Vector()
        {
            // arrange
            float expected = 3.0f;

            // act
            Vector vector1 = new Vector(1.0f, 1.0f, 1.0f);
            Vector vector2 = new Vector(-2.0f, 3.0f, 2.0f);
            float dotProduct = vector1 * vector2;

            // assert
            Assert.AreEqual(expected, dotProduct);
        }

    }
}
