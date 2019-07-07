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

           

        }

    }
}
