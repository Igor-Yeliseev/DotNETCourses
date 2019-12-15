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
            Figure figure = figuresFactory.GetFigure(Material.Paper, 2, 5);
            //figuresBox.Add(figure);
            figuresBox.Add(figuresFactory.GetFigure(Material.Paper, 5));
            figuresBox.Add(figuresFactory.GetFigure(Material.Film, 3, 3));
            

            TrianglePaper miniTriangle = new TrianglePaper(0.5f, 0.5f, 0.5f);
            miniTriangle.Сolor = Сoloring.Green;

            //figuresBox.WriteToXml("D:/myAllFigures2.xml");

            Box box = Box.ReadFromXml("D:/myAllFigures.xml");
            //Box box = Box.StreamReadFromXml("D:/strWriteAllFigures.xml");
            Console.WriteLine("count = " + box.GetCount());

            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine(box.ShowFigure(i).ToString());
            }

            //Console.WriteLine("area = " + actualArea + "\nexpected = " + expectedArea);
            //Console.WriteLine(miniTriangle.Сolor.ToString());

            Console.ReadKey();

        }
    }
}
