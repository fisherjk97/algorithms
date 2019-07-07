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
            Print(input);

            for(int i = 0; i < input.Length - 1; i++){
                for(int j = 0; j < input.Length - 1; j++){
                        if(input[j] > input[j+1]){
                            temp = input[j+1];
                            input[j+1] = input[j];
                            input[j] = temp;
                            //Print(input);
                        }
                }
            }
            
            Console.Write("Sorted:   ");
            Print(input);
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
            Print(input);

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
            }
            
            Console.Write("Sorted:   ");
            Print(input);
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
            Print(input);

            int[] helper = new int[input.Length];
            MergeSort(input, helper, 0, input.Length -1);
            
            Console.Write("Sorted:   ");
            Print(input);
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
            //Print(array);
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
            //Print(array);
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


        private static int[] Swap(int[] array, int left, int right){
            int temp;
            temp = array[right];
            array[right] = array[left];
            array[left] = temp; 

            return array;
        }


        public static void Print(int[] input){
            for (int i = 0; i < input.Length; i++)
            {
                if(i < input.Length - 1){
                    Console.Write(input[i] + ", ");
                }else{
                    Console.Write(input[i]);
                }
            }
             Console.WriteLine();
        }

        public static int[] Generate(int size, int maxValue){
              int[] a = new int[size];
                Random random = new Random();
                //generate numbers
                for (int i = 0; i < size; i++)
                {
                    a[i] = random.Next(maxValue);
                }

                return a;
        }
    }
}