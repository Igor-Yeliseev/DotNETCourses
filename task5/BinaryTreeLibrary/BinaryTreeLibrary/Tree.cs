using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// A class representing a binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        /// <summary>
        /// Add a new node
        /// </summary>
        /// <param name="data"> Node data</param>
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

        /// <summary>
        /// Get a collection of data with infix traversal
        /// </summary>
        /// <returns></returns>
        public List<T> InfixOrder()
        {
            if(Root == null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        private List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if(node.Left != null)
                {
                    list.AddRange(InOrder(node.Left));
                }

                list.Add(node.Data);

                if(node.Right != null)
                {
                    list.AddRange(InOrder(node.Right));
                }
            }

            return list;
        }
    }
}
