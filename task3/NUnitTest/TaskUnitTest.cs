﻿using FiguresClassLibrary;
using NUnit.Framework;
using System;
using TaskClassLibrary;

namespace NUnitTest
{
    [TestFixture]
    class TaskUnitTest
    {
        /// <summary>
        /// Figures Factory
        /// </summary>
        FiguresFactory figuresFactory = null;
        /// <summary>
        /// Box of figures
        /// </summary>
        Box figuresBox = null;
        float totalArea = 0.0f;
        float totalPerimeter = 0.0f;

        /// <summary>
        /// Initializes figuresFactory and figuresBox
        /// </summary>
        public TaskUnitTest()
        {
            figuresFactory = new FiguresFactory();
            figuresBox = new Box();
            Figure figure = null;
            
            // Create a paper circle
            figure = figuresFactory.GetFigure(Material.Paper, 5);
            figuresBox.Add(figure);
            totalArea += figure.GetArea();
            totalPerimeter += figure.GetPerimeter();

            // Create a film rectangle
            figure = figuresFactory.GetFigure(Material.Film, 2, 5);
            figuresBox.Add(figure);
            totalArea += figure.GetArea();
            totalPerimeter += figure.GetPerimeter();

            // Create a paper triangle
            figure = figuresFactory.GetFigure(Material.Paper, 2, 2, 2);
            figuresBox.Add(figure);
            totalArea += figure.GetArea();
            totalPerimeter += figure.GetPerimeter();

            // Create a film triangle
            figure = figuresFactory.GetFigure(Material.Film, 3, 4, 5);
            figuresBox.Add(figure);
            totalArea += figure.GetArea();
            totalPerimeter += figure.GetPerimeter();

            // Create a film circle
            figure = figuresFactory.GetFigure(Material.Film, 4);
            figuresBox.Add(figure);
            totalArea += figure.GetArea();
            totalPerimeter += figure.GetPerimeter();
        }

        /// <summary>
        /// Check a triangle figure
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <param name="expectedArea"></param>
        [TestCase(5, 4, 3, 6, 12)]
        [TestCase(5, 5, 5, 10.82532f, 15)]
        [TestCase(1.1f, 1.5427f, 1.7f, 0.830246f, 4.3427f)]
        [TestCase(1.5f, 1.0f, 1.8028f, 0.75f, 4.3028f)]
        public void CheckTriangle(float sideA, float sideB, float sideC, float expectArea, float expectPerim)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            
            Assert.AreEqual(expectArea, triangle.GetArea(), 0.00001f);

            Assert.AreEqual(expectPerim, triangle.GetPerimeter(), 0.00001f);
        }

        /// <summary>
        /// Check a rectangle figure
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="expectArea"></param>
        /// <param name="expectPerim"></param>
        [TestCase(5, 4, 20, 18)]
        [TestCase(10, 10, 100, 40)]
        [TestCase(8.4f, 4.7f, 39.48f, 26.2f)]
        [TestCase(2.5f, 3.3f, 8.25f, 11.6f)]
        public void CheckRectangle(float width, float height, float expectArea, float expectPerim)
        {
            Rectangle rectangle = new Rectangle(width, height);

            Assert.AreEqual(expectArea, rectangle.GetArea(), 0.0001f);
        
            Assert.AreEqual(expectPerim, rectangle.GetPerimeter(), 0.0001f);
        }

        /// <summary>
        /// Check a circle figure
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="expectArea"></param>
        /// <param name="expectPerim"></param>
        [TestCase(2, 12.56637f, 12.56637f)]
        [TestCase(6, 113.09733f, 37.69911f)]
        [TestCase(1, 3.14159f, 6.28318f)]
        [TestCase(1.35f, 5.72555f, 8.48230f)]
        public void CheckCircle(float radius, float expectArea, float expectPerim)
        {
            Circle rectangle = new Circle(radius);

            Assert.AreEqual(expectArea, rectangle.GetArea(), 0.0001f);

            Assert.AreEqual(expectPerim, rectangle.GetPerimeter(), 0.0001f);
        }

        /// <summary>
        /// Check the box collection for exception
        /// </summary>
        [Test]
        public void CheckBox()
        {
            TestDelegate func = delegate
            {
                Box box = new Box();
                box.Add(new RectanglePaper(20, 20));
                box.Add(new RectanglePaper(20, 20));
                //box.Add(null);
            };
            Assert.Catch(func);

            TestDelegate func2 = delegate
            {
                Box box = new Box();

                // More than 20 figures
                for (int i = 0; i < 21; i++)
                {
                    box.Add(new RectanglePaper(i + 1, i + 1));
                }
            };
            Assert.Catch(func2);
            
        }

        /// <summary>
        /// Check functions of the box collection 
        /// </summary>
        [Test]
        public void CheckBoxFunctions()
        {
            Assert.AreEqual(5, figuresBox.Count);

            Assert.AreEqual(totalArea, figuresBox.GetTotalArea());

            Assert.AreEqual(totalPerimeter, figuresBox.GetTotalPerimeter());

            // Get all circles
            Assert.AreEqual(2, figuresBox.FindCircles().Count);

            // Get all film figures
            Assert.AreEqual(3, figuresBox.FildFilmFigures().Count);
        }

        /// <summary>
        /// Check a figures factory
        /// </summary>
        [Test]
        public void CheckFiguresFactory()
        {
            Figure circle = null;
            Figure rectangle = null;
            Figure triangle = null;

            // Create factory
            FiguresFactory factory = new FiguresFactory();
            
            // Film Circle
            circle = factory.GetFigure(Material.Film, 3);
            Figure expCircleF = new CircleFilm(3);
            Assert.AreEqual(expCircleF, circle);

            // Paper Circle
            circle = factory.GetFigure(Material.Paper, 3);
            Figure expCircleP = new CirclePaper(3);
            Assert.AreEqual(expCircleP, circle);

            // Film Rectangle
            rectangle = factory.GetFigure(Material.Film, 2, 2);
            Figure expRectangleF = new RectangleFilm(2, 2);
            Assert.AreEqual(expRectangleF, rectangle);

            // Paper Rectangle
            rectangle = factory.GetFigure(Material.Paper, 2, 2);
            Figure expRectangleP = new RectanglePaper(2, 2);
            Assert.AreEqual(expRectangleP, rectangle);

            // Film Triangle
            triangle = factory.GetFigure(Material.Film, 2, 2, 2);
            Figure expTriangleF = new TriangleFilm(2, 2, 2);
            Assert.AreEqual(expTriangleF, triangle);

            // Paper Triangle
            triangle = factory.GetFigure(Material.Paper, 3, 4, 5);
            Figure expTriangleP = new TrianglePaper(3, 4, 5);
            Assert.AreEqual(expTriangleP, triangle);

        }
        
        /// <summary>
        /// Check figures for painting
        /// </summary>
        [Test]
        public void PaintFigures()
        {
            TrianglePaper triangle = new TrianglePaper(1, 1, 1);
            // Create a painter
            Painter painter = new Painter();

            painter.Colorize(triangle, Сoloring.Black);

            Assert.AreEqual(triangle.Сolor, Сoloring.Black);

        }

        /// <summary>
        /// Check cutting out figures from other figures
        /// </summary>
        [Test]
        public void CheckCuttingFigures()
        {
            Figure figure = figuresBox.Extract(2);

            Assert.IsTrue(figure is TrianglePaper);
        }
    }
}
