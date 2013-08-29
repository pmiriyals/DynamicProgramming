using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class LongestIncreasingSubSeq
    {
        static void LISS(int[] arr)
        {
            int[] lis = new int[arr.Length];
            for (int i = 0; i < lis.Length; i++)
                lis[i] = 1;

            int max = -1;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && lis[i] < (lis[j] + 1))
                    {
                        lis[i] = lis[j] + 1;
                        if (max < lis[i])
                        {
                            Console.WriteLine("i = {0} & j = {1} & arr[i] = {2}", i, j, arr[i]);
                            max = lis[i];
                        }
                    }
                }
            }

            Console.WriteLine("LISS = {0} ", max);
        }

        public static void driver()
        {
            int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60, 80 };
            LISS(arr);
        }
    }
}
