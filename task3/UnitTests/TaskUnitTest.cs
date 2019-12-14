using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskClassLibrary;
using FiguresClassLibrary;

namespace UnitTests
{
    [TestClass]
    public class TaskUnitTest
    {
        /// <summary>
        /// Check triangle figure
        /// </summary>
        [TestMethod]
        public void CheckTriangle()
        {
            float expectedArea = 10.82532f;//(float)Math.Sqrt(3) * 5 * 5 / 4;

            TrianglePaper triangle = new TrianglePaper(5, 5, 5);

            float actualArea = triangle.GetArea();

            Assert.AreEqual(expectedArea, actualArea, 0.00001f);

            //Assert.AreEqual(9, triangle.GetPerimeter());

        }


        /// <summary>
        /// Check the box collection
        /// </summary>
        [TestMethod]
        public void BoxFeatures()
        {
            Action func = delegate
            {
                Box girlBox = new Box();

                girlBox.Add(new Rectangle(20, 20));
                girlBox.Add(null);
            };

            Assert.ThrowsException<ArgumentNullException>(func);


            Action func2 = delegate
            {
                Box girlBox = new Box();

                for (int i = 0; i < 21; i++)
                {
                    girlBox.Add(new Rectangle(i+1, i+1));
                }  
            };

            Assert.ThrowsException<Exception>(func2);
        }

        /// <summary>
        /// Check figures for painting
        /// </summary>
        [TestMethod]
        public void PaintFigures()
        {
            TrianglePaper triangle = new TrianglePaper(1, 1, 1);
            // Create a painter
            Painter painter = new Painter();

            painter.Colorize(triangle, Сoloring.Black);
            
            Assert.AreEqual(triangle.Сolor, Сoloring.Black);

        }
    }
}
