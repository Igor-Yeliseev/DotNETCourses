using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    public class Tree<T>
        where T : IComparable
    {
        /// <summary>
        /// Tree root element
        /// </summary>
        public Node<T> Root { get; private set; }

        /// <summary>
        /// The number of tree elements
        /// </summary>
        public int Count { get; private set; }

        public void Add(T data)
        {
            if(Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
        }
    }
}
