
#define TESTING
using System;
using System.Diagnostics;

namespace Algorithms
{
    public static class Helper
    {
        /// <summary>
        /// Print a 1-D array
        /// </summary>
        /// <param name="input">array to print</param>
         public static void Print(int[] input){
            #if TESTING 
            for (int i = 0; i < input.Length; i++)
            {
                if(i < input.Length - 1){
                    Console.Write(input[i] + ", ");
                }else{
                    Console.Write(input[i]);
                }
            }
            Console.WriteLine();
            #endif
        }

        /// <summary>
        /// Generate an array with random values
        /// </summary>
        /// <param name="size">size of the array to generate</param>
        /// <param name="maxValue">maximum value the array will hold</param>
        /// <returns></returns>

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