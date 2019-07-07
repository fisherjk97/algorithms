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
           int[] input1 = Sort.Generate(10, 1000);
           int[] input2 = Sort.Generate(10, 1000);
           int[] input3 = Sort.Generate(10, 1000);
           int[] input4 = Sort.Generate(10, 1000);

           int[] bubbleSort = Sort.BubbleSort(input1);
           int[] selectionSort = Sort.SelectionSort(input2);
           int[] mergeSort = Sort.MergeSort(input3);
           int[] quickSort = Sort.QuickSort(input4, 0, input4.Length - 1);

        }

    }
}
