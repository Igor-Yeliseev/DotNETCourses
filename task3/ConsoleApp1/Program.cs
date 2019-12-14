using FiguresClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskClassLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            float expectedArea = 26.2f;

            TrianglePaper triangle = new TrianglePaper(1.1f, 1.5427f, 1.7f);
            RectangleFilm rectangle = new RectangleFilm(8.4f, 4.7f);
            float actualArea = rectangle.GetPerimeter();

            FiguresFactory figuresFactory = new FiguresFactory();

            Box figuresBox = new Box();
            Figure figure = figuresFactory.GetFigure(Material.Film, 2, 5);
            figuresBox.Add(figure);

            figure = figuresBox.Extract(0);
            

            Figure miniTriangle = new TrianglePaper(figure, 1, 1, 1);

            //Console.WriteLine("area = " + actualArea + "\nexpected = " + expectedArea);
            Console.WriteLine(figure.ToString());

            Console.ReadKey();

        }
    }
}
