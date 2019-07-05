using System;
using System.Diagnostics;

namespace Algorithms.Sorting
{
    public class BubbleSort
    {
        public static void Sort(int[] input){

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
            
            Console.Write("Sorted:");
            Print(input);
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