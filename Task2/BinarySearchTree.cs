using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T>
    {
        public int Length { get; set; }
        public IComparer<T> Comparer { get; private set; }
        private Node _root;
        public BinarySearchTree() : this(null) { }

        public BinarySearchTree(IComparer<T> comparer)
        {
            IComparer<T> newComparer = comparer;

            if(newComparer == null)
                if (typeof(T).GetInterface("IComparable`1") == null || (typeof(T).GetInterface("IComparable") == null))
                    throw new ArgumentException();
                else
                {
                    newComparer = Comparer<T>.Default;
                }

            Comparer = newComparer;
        }

        public void Insert(T element)
        {
            Node node = new Node(element);
                     
            AddNode(node, _root);    

        }

        private void AddNode(Node node, Node root)
        {

            if (root == null)
            {
                _root = node;
                return;
            }


            while (root != null)
            {
                int cmp = Comparer.Compare(node.Value, root.Value);

                if (cmp > 0)
                {
                    if (root.Right == null)
                    {
                        root.Right = node;
                        return;
                    }

                    root = root.Right;
                }
                else if (cmp < 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = node;
                        return;
                    }
                    root = root.Left;
                }

            }
        }


        private class Node
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T value, Node left = null, Node right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }
    }
}
