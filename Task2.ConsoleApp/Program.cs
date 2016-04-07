using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleApp
{
    class Program
    {
        public class InverseComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
               return y.CompareTo(x);
            }
        }

        

        static void Main(string[] args)
        {
          
            IntTreeDemo();
        }

        public static void IntTreeDemo()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            BinarySearchTree<int> inverseTree = new BinarySearchTree<int>(new InverseComparer());
            int[] array = { 20, 10, 15, 14, 16, 30, 17, 35 };

            foreach (int num in array)
            {
                tree.Insert(num);
                inverseTree.Insert(num);
            }

            foreach (var num in tree.PreOrderTraversal())
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            foreach (var num in inverseTree.PreOrderTraversal())
            {
                Console.Write(num + " ");
            }
        }
    }
}
