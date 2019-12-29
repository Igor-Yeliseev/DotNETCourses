using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// A class representing a tree node
    /// </summary>
    /// <typeparam name="T"> Data</typeparam>
    [Serializable]
    public class Node<T> : IComparable
        where T : IComparable
    {

        /// <summary>
        /// Node data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Left node
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Right node
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class
        /// </summary>
        public Node()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Node class
        /// </summary>
        /// <param name="data"> Node data</param>
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the Node class
        /// </summary>
        /// <param name="data"> Node data</param>
        /// <param name="left"> Left node</param>
        /// <param name="right"> Right node</param>
        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Add a new element to node
        /// </summary>
        /// <param name="data"> Node data</param>
        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if(Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj"> An object to compare with this instance.</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if(obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new InvalidCastException("Unable to cast types");
            }
        }
        
    }
}
