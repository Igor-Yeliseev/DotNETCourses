using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskClassLibrary;
using FiguresClassLibrary;

namespace UnitTests
{
    [TestClass]
    public class TaskUnitTest
    {
        [TestMethod]
        public void TestMethod1()
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

        [TestMethod]
        public void TestMethod2()
        {
            Figure figure = new TrianglePaper(1, 1, 1);
            // Create a painter
            Painter painter = new Painter();

            painter.Colorize(figure, Сoloring.Black);

            TrianglePaper triangle = (TrianglePaper)figure;

            Assert.AreEqual(triangle.Сolor, Сoloring.Black);

        }
    }
}
