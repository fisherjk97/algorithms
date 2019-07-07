using System;
using System.Diagnostics;
/*Examples come from "Cracking the Coding Interview - Gayle Laakmann McDowell */


namespace Algorithms.Sorting
{
    public static class Sort
    {
        /// <summary>
        /// Bubble Sort:
        /// Start at the beginning of the array and swap the first two elements if the first > second.
        /// Then go to the next pair and so on, continuously making sweeps of the array until it is sorted.
        /// In doing so the smaller items slowly "bubble" up to the beginning of the list.
        /// Runtime: O(n^2)
        /// Average and Worse Case: O(1)
        /// </summary>
        /// <param name="input"></param>
        public static int[] BubbleSort(int[] input){
            Console.WriteLine("Bubble Sort");
            int temp; 
            Console.Write("Unsorted: ");
            Helper.Print(input);

            for(int i = 0; i < input.Length - 1; i++){
                for(int j = 0; j < input.Length - 1; j++){
                        if(input[j] > input[j+1]){
                            temp = input[j+1];
                            input[j+1] = input[j];
                            input[j] = temp;
                        }
                }
                Helper.Print(input);
            }
            
            Console.Write("Sorted:   ");
            Helper.Print(input);

            //assign to new array
           

            return input;
        }

        /// <summary>
        /// Selection Sort:
        /// Find the smallest element using a linear scan and move it to the front (swapping it with the front element).
        /// Then find the second smallest and move it again doing a linear scan.
        /// Continue doing this until all the elements are in place
        /// Runtime: O(n^2)
        /// Average and Worse Case: O(1)
        /// </summary>
        /// <param name="input"></param>
        public static int[] SelectionSort(int[] input){
            Console.WriteLine("Selection Sort");
            int temp; 
            int smallest;
            Console.Write("Unsorted: ");
            Helper.Print(input);

            for(int i = 0; i < input.Length - 1; i++){
                smallest = i;
                for(int j = i + 1; j < input.Length; j++){
                        if(input[j] < input[smallest]){
                            smallest = j;
                        }
                }
                temp = input[smallest];
                input[smallest] = input[i];
                input[i] = temp;
                Helper.Print(input);
            }
            
            Console.Write("Sorted:   ");
            Helper.Print(input);
            return input;
        }


                /// <summary>
        /// Insertion Sort:
        /// Runtime: 
        /// Average and Worse Case: 
        /// </summary>
        /// <param name="input"></param>
        public static int[] InsertionSort(int[] input){
            Console.WriteLine("Insertion Sort");
            Console.Write("Unsorted: ");
            Helper.Print(input);

            for(int i = 1; i < input.Length; i++){
                int key = input[i];
                int j = i - 1;

                //move elements of array[0...i - 1] that are greater than key to one positoin ahead of their current position
                while(j >= 0 && input[j] > key){
                    input[j + 1] = input[j];
                    j = j - 1;
                }
                input[j + 1] = key;
                Helper.Print(input);
            }
            
            Console.Write("Sorted:   ");
            Helper.Print(input);
            return input;
        }


        /// <summary>
        /// Merge Sort:
        /// Divides the array in half, sorts each of those halves, and then merges them back together.
        /// Each of those halves has the same sorting algorithm applied to it. Eventually you are merging just to element arrays.
        /// The "merge" part does all the heavy lifting
        /// Runtime: O(n * log(n))
        /// Average and Worse Case: Depends
        /// </summary>
        /// <param name="input"></param>
        public static int[] MergeSort(int[] input){
            Console.WriteLine("Merge Sort");
            Console.Write("Unsorted: ");
            Helper.Print(input);

            int[] helper = new int[input.Length];
            MergeSort(input, helper, 0, input.Length -1);
            
            Console.Write("Sorted:   ");
            Helper.Print(input);
            return input;
        }

        private static int[] MergeSort(int[] array, int[] helper, int low, int high){
            if(low < high){
                int middle = (low + high) / 2;
                MergeSort(array, helper, low, middle);//Sort the left half
                MergeSort(array, helper, middle +1, high);//Sort the right half
                return Merge(array, helper, low, middle, high);
            }
            return array;
        }

        private static int[] Merge(int[] array, int[] helper, int low, int middle, int high){
            /*Copy both halves into a helper array */
            for(int i = low; i <= high; i++){
                helper[i] = array[i];
            }

            int helperLeft = low;
            int helperRight = middle +1;
            int current = low;

            /*Iterate through the helper array. Compare the left and right half, copying back
            the smaller element from the two halves into the original array. */

            while(helperLeft <= middle && helperRight <= high){
                if(helper[helperLeft] <= helper[helperRight]){
                    array[current] = helper[helperLeft];
                    helperLeft++;
                }else {//if the right element is smaller than the left element
                    array[current]  = helper[helperRight];
                    helperRight++;
                }
                current++;
            }


            /*Copy the rest of the left side of the array into the target array */
            int remaining = middle - helperLeft;
            for(int i = 0; i <= remaining; i++){
                array[current+i] = helper[helperLeft + i];
            }

            return array;
        }


        /// <summary>
        /// Quick Sort: We pick a random element and partition the array 
        /// such that all the numbers that are less than the partitioning element 
        /// come before all elements that are greater than it. 
        /// The partitioning element can be performed efficiently through a series of swaps. 
        /// Repeating this partitioning around an element, the array will eventually become sorted.
        /// However, the sorting could be very slow
        /// Runtime: O (n * log(n)) average, O(n^2) worst case. Memory O (log(n))
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static int[] QuickSort(int[] array, int left, int right){
            //Console.WriteLine("Quick Sort");
            //Console.Write("Unsorted: ");
            //Helper.Print(array);
            if(left < right){
                int pivot = Partition(array, left, right);

            if(pivot > 1){//sort the left half
                QuickSort(array, left, pivot - 1);
            }
            if(pivot + 1 < right){//sort the right half
                QuickSort(array, pivot + 1, right);
            }
            }
            //Console.Write("Sorted:   ");
            //Helper.Print(array);
            return array;
        }

        private static int Partition(int[] array, int left, int right){
            int pivot = array[left];//pick a pivot point
            while (true){
                //find the element on left that should be on the right
                while(array[left] < pivot){
                    left++;
                }

                //find the element on the right that should be on the left
                while (array[right] > pivot){
                    right--;
                }

                //swap elements and move left/right indices
                if (left < right){
                    if(array[left] == array[right]){
                        return right;
                    }
                   int temp = array[left];
                   array[left] = array[right];
                   array[right] = temp;

                    
                }else{
                    return right;
                }
            }

          
        }

        /// <summary>
        /// Heap Sort
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] HeapSort(int[] array){
            int n = array.Length;
            Console.WriteLine("Heap Sort");
            Console.Write("Unsorted: ");
            Helper.Print(array);
            //build heap (rearrange array)
            for (int i = n/2 - 1; i >= 0; i--){
                array = Heapify(array, n, i);
            }
            //one by one extract an element from the heap
            for(int i = n-1; i >=0; i--){
                //move current root to the end
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                //call max heapify on the reduced heap
                array = Heapify(array, i, 0);

            }

            Console.Write("Sorted:   ");
            Helper.Print(array);
            return array;
        }

        /// <summary>
        /// To heapify a subtree rooted with node i which is an index in array[]. 
        /// </summary>
        /// <param name="array">array to heapify</param>
        /// <param name="n">size of the heap</param>
        /// <param name="i">node</param>
        /// <returns></returns>
        private static int[] Heapify(int[] array, int n, int i){
                int largest = i;//initialize the largest as root;
                int left = 2 * i + 1;// left
                int right = 2 * i + 2;//right

                //if left child is larger than root

                if(left < n && array[left] > array[largest]){
                    largest = left;
                }

                //if right child is larger than root

                if(right < n && array[right] > array[largest]){
                    largest = right;
                }

                //if largest is not root
                if(largest != i){
                    int swap = array[i];
                    array[i] = array[largest];
                    array[largest] = swap;

                    //recursively heapify the affected sub-tree
                    Heapify(array, n, largest);
                }
                return array;
        }


    }
}