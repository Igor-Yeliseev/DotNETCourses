using FiguresClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            float expectedArea = 26.2f;

            TrianglePaper triangle = new TrianglePaper(1.1f, 1.5427f, 1.7f);


            Rectangle rectangle = new Rectangle(8.4f, 4.7f);

            float actualArea = rectangle.GetPerimeter();

            Console.WriteLine("area = " + actualArea + "\nexpected = " + expectedArea);

            Console.ReadKey();

        }
    }
}
