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
            Tree<Student> tree1 = new Tree<Student>();

            Student peter = new Student("Peter", TestName.Literature, 6);
            Student vova = new Student("Vova", TestName.Literature, 8);
            Student sasha = new Student("Sasha", TestName.Physics, 7);
            Student igor = new Student("Igor", TestName.Programming, 9);
            Student frank = new Student("Frank", TestName.Programming, 3);
            Student sergey = new Student("Sergey", TestName.Programming, 5);
            Student jane = new Student("Jane", TestName.Programming, 1);
            Student marie = new Student("Marie", TestName.Programming, 2);

            //tree.Add(peter);
            //tree.Add(vova);
            //tree.Add(sasha);
            //tree.Add(igor);

            Tree<int> tree = new Tree<int>();

            tree.Add(6);
            tree.Add(8);
            tree.Add(7);
            tree.Add(9);
            tree.Add(3);
            tree.Add(5);
            tree.Add(1);
            tree.Add(2);

            tree.Root = tree.Remove(tree.Root, 8);

            Console.WriteLine("Peter scrore = " + peter.Score);
            Console.ReadKey();

            TreeSerializer.Serialize(tree1, "binaryTree.xml");

            Console.WriteLine("Бинарное дерево успешно сериализованно");
            Console.ReadKey();
        }
    }
}
