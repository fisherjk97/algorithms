using System;
using System.Diagnostics;

using Algorithms.Trees;
using Algorithms.Graphs;
using Algorithms.Sorting;
namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

           BinarySearchTree.Test(10);
           
           GraphSearch.Test();

           int[] input = BubbleSort.Generate(50, 1000);

           BubbleSort.Sort(input);
        }

    }
}
