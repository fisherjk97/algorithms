//#define DEBUG

using System;
using System.Diagnostics;

using Algorithms.Trees;
using Algorithms.Graphs;
using Algorithms.Sorting;
using Algorithms.Searching;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

           //Trees and Graph Algorithms
           BinarySearchTree.Test(10);
           GraphSearch.Test();

           //Test data
           int[] data = Helper.Generate(10, 1000);
           int[] heapData = new int[] {12, 11, 13, 5, 6, 7};

           //Sorting Algorithms
           int[] bubbleSort = Sort.BubbleSort(data);
           int[] selectionSort = Sort.SelectionSort(data);
           int[] insertionSort = Sort.InsertionSort(data);
           int[] mergeSort = Sort.MergeSort(data);
           int[] quickSort = Sort.QuickSort(data, 0, data.Length /2);
           int[] heapSort = Sort.HeapSort(heapData);

            //Searching Algorithms
           int value = mergeSort[mergeSort.Length / 2];
           int binarySearch = Search.BinarySearch(mergeSort, value);
           int binarySearchRecursive = Search.BinarySearchRecursive(mergeSort, value, 0, mergeSort.Length - 1);

           int[,] dGraph =  {
                         { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                         { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                         { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                         { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                         { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                         { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                         { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                         { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                         { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };
 
            GraphTraversal.Dijkstra(dGraph, 0, 9);


            int[, ] pGraph = new int[, ] { { 0, 2, 0, 6, 0 }, 
                                      { 2, 0, 3, 8, 5 }, 
                                      { 0, 3, 0, 0, 7 }, 
                                      { 6, 8, 0, 0, 9 }, 
                                      { 0, 5, 7, 9, 0 } };

            GraphTraversal.PrimMST(pGraph, 5);

        }

    }
}
