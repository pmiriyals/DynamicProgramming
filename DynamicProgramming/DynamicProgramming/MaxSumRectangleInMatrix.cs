using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class MaxSumRectangleInMatrix
    {
        static void MaxSumRect(int[,] mat)
        {
            int fl = 0, fr = 0, ft = 0, fb = 0;
            int start, finish;
            int sum, maxSum = -1;
            int m = mat.GetLength(0);
            int n = mat.GetLength(1);
            
            for (int left = 0; left < n; left++)
            {
                int[] temp = new int[m];

                for (int right = left; right < n; right++)
                {
                    for (int i = 0; i < m; i++)
                        temp[i] += mat[i, right];

                    sum = Kadane(temp, out start, out finish);

                    if (maxSum < sum)
                    {
                        maxSum = sum;                        
                        fl = left;
                        fr = right;
                        ft = start;
                        fb = finish;
                    }
                }
            }

            printMat(mat, fl, fr, ft, fb);
        }

        static void printMat(int[,] mat, int l, int r, int t, int b)
        {
            Console.WriteLine("Max Sum Rectrangle in a Matrix: ");
            int sum = 0;
            for (int i = t; i <= b; i++)
            {
                for (int j = l; j <= r; j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                    sum += mat[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nSum = {0}", sum);
        }

        static int Kadane(int[] arr, out int start, out int end)
        {
            int SumTillHere = 0;
            int MaxSum = Int32.MinValue;
            start = 0;
            end = 0;
            int l = 0;
            bool isallneg = true;
            int maxneg = arr[0];
            int negndx = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                SumTillHere += arr[i];

                if (SumTillHere < 0)
                {
                    SumTillHere = 0;
                    l = i + 1;
                    if (isallneg && maxneg < arr[i])
                    {
                        maxneg = arr[i];
                        negndx = i;
                    }
                }
                else
                    isallneg = false;                

                if (MaxSum < SumTillHere)
                {
                    MaxSum = SumTillHere;
                    start = l;
                    end = i;
                }
            }
            if (isallneg)
            {
                start = end = negndx;
                return maxneg;
            }

            return MaxSum;
        }

        public static void driver()
        {
            int[,] mat = { 
                         {1, 2, -4, -1, -20},
                         {-8, -3, 4, 2, 1},
                         {3, 8, 10, 1, 3},
                         {-4, -1, 1, 7, -6}
                         };
            MaxSumRect(mat);
            Console.ReadLine();
        }
    }
}
