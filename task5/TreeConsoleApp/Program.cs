using BinaryTreeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<Student> tree = new Tree<Student>();

            Student peter = new Student("Peter", TestName.Literature, 6);
            Student vova = new Student("Vova", TestName.Literature, 8);
            Student sasha = new Student("Sasha", TestName.Literature, 7);
            Student igor = new Student("Igor", TestName.Literature, 9);

            Console.WriteLine("Peter scrore = " + peter.Score);
            Console.ReadKey();


            //tree.Add(peter);
            //tree.Add(vova);
            //tree.Add(sasha);
            //tree.Add(igor);

            
        }
    }
}
