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

           //Trees and Graph Algorithms
           BinarySearchTree.Test(10);
           GraphSearch.Test();

           //Sorting Algorithms
           int[] input = Sort.Generate(10, 1000);
           int[] bubbleSort = Sort.BubbleSort(input);
           int[] selectionSort = Sort.SelectionSort(input);
           int[] mergeSort = Sort.MergeSort(input);
           

        }

    }
}
