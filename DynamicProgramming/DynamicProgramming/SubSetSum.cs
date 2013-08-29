using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class SubSetSum
    {
        static bool HasSubSetSum(int[] arr, int sum)
        {
            bool[,] subset = new bool[sum + 1, arr.Length + 1];
                        
            for (int i = 0; i <= arr.Length; i++)
                subset[0, i] = true;

            for (int i = 1; i <= sum; i++)
                subset[i, 0] = false;

            for (int i = 1; i <= sum; i++)
            {
                for (int j = 1; j <= arr.Length; j++)
                {
                    subset[i, j] = subset[i, j - 1];
                    if (i >= arr[j - 1])
                        subset[i, j] = subset[i, j] || subset[i - arr[j - 1], j];
                }
            }
            return subset[sum, arr.Length];
        }

        public static void driver()
        {
            int[] arr = { 3, 34, 4, 12, 5, 2 };
            Console.WriteLine("Has SubSetSum = {0}", HasSubSetSum(arr, 10));            
        }
    }
}
