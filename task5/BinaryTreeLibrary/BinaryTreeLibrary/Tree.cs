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
    [Serializable]
    public class Tree<T>
        where T : IComparable
    {
        /// <summary>
        /// Tree root element
        /// </summary>
        public Node<T> Root { get; set; }

        /// <summary>
        /// The number of tree elements
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Add a new node
        /// </summary>
        /// <param name="data"> Node data</param>
        public void Add(T data)
        {
            if (Root == null)
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
        public List<T> InOrderTraversal()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        /// <summary>
        /// Get a collection of data with infix traversal
        /// </summary>
        /// <param name="node"> The node from which the count is going</param>
        /// <returns></returns>
        private List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();

            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(InOrder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(InOrder(node.Right));
                }
            }

            return list;
        }

        /// <summary>
        /// Remove element
        /// </summary>
        /// <param name="root"> Root node</param>
        /// <param name="data"> Data</param>
        /// <returns> New root element</returns>
        public Node<T> Remove(Node<T> root, T data)
        {
            if (root == null)
                return root;

            if(data.CompareTo(root.Data) == -1)
            {
                root.Left = Remove(root.Left, data);
            }
            else if(data.CompareTo(root.Data) == 1)
            {
                root.Right = Remove(root.Right, data);
            }
            else
            {
                if (root.Left == null)
                {
                    Count--;
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    Count--;
                    return root.Left;
                }

                root.Data = InorderSuccessor(root.Right);
                root.Right = Remove(root.Right, root.Data);
            }

            return root;
        }

        /// <summary>
        /// Remove all nodes
        /// </summary>
        public void RemoveAll()
        {
            List<T> nodes = InOrderTraversal();
            
            foreach (T data in nodes)
            {
                Root = Remove(Root, data);
            }
        }

        private T InorderSuccessor(Node<T> root)
        {
            var minimum = root.Data;

            while (root.Left != null)
            {
                minimum = root.Left.Data;
                root = root.Left;
            }

            return minimum;
        }

        /// <summary>
        /// Search an element by data
        /// </summary>
        /// <param name="data"> Node data</param>
        /// <returns></returns>
        public Node<T> Search(T data)
        {
            return Search(data, out Node<T> parent);
        }

        /// <summary>
        /// Search an element by data
        /// </summary>
        /// <param name="data"> Node data</param>
        /// <param name="parent"> Parent node</param>
        /// <returns></returns>
        public Node<T> Search(T data, out Node<T> parent)
        {
            Node<T> current = Root;
            parent = null;

            while(current != null)
            {
                int result = data.CompareTo(current.Data);
                if (result == 1)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (result == -1)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                    break;
            }

            return current;
        }
        
        /// <summary>
        /// Balance binary tree
        /// </summary>
        public void Balance()
        {
            List<T> allNodes = InOrderTraversal();

            int count = Count;

            // Remove all nodes
            RemoveAll();
            
            BalanceTree(0, count - 1, allNodes);
        }

        /// <summary>
        /// Balance the tree. 
        /// </summary>
        /// <param name="min"> The index of the first element</param>
        /// <param name="max"> The index of the last element</param>
        /// <param name="listNodes"> Nodes list</param>
        private void BalanceTree(int min, int max, List<T> listNodes)
        {
            if (min <= max)
            {
                int middle = (int)Math.Ceiling((double)(min + max) / 2);

                Add(listNodes[middle]);

                BalanceTree(min, middle - 1, listNodes);
                BalanceTree(middle + 1, max, listNodes);
            }
        }
    }
}
