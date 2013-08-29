using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //LongestCommonSubstring.driver();
            //LongestCommonSubSequence.driver();
            //LongestRepeatingSubString.driver();
            //LongestIncreasingSubSeq.driver();
            //LongestPalindromicSubSequence.driver();
            //MaxSumRectangleInMatrix.driver();
            SubSetSum.driver();
            Console.ReadLine();
        }

        public static void printMatrix(int[,] mat)
        {
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0} ", mat[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
