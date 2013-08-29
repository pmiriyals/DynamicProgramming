using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class LongestCommonSubSequence
    {
        static void LongestCommSubSeq(string a, string b)
        {
            int[,] lcs = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i < lcs.GetLength(0); i++)
            {
                for (int j = 0; j < lcs.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                        lcs[i, j] = 0;
                    else
                    {
                        if (a[i - 1] == b[j - 1])
                            lcs[i, j] = lcs[i - 1, j - 1] + 1;
                        else
                            lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                    }
                }
            }
            printMatrix(lcs);
            printLCSeq(lcs, a);
        }

        static void printLCSeq(int[,] mat, string a)
        {
            int m = mat.GetLength(0) - 1;
            int n = mat.GetLength(1) - 1;
            string str = "";
            while (m > 0 && n > 0)
            {
                if (mat[m, n] == mat[m, n - 1])
                {
                    n--;
                    continue;
                }
                else if (mat[m, n] == mat[m - 1, n])
                {
                    m--;
                    continue;
                }
                else if (mat[m, n] > 0)
                {
                    str = a[m - 1] + str;
                    m--;
                    n--;
                }
                else
                    break;
            }
            if (str.Length > 0)
                Console.WriteLine("Longest Common Subsequence = {0}", str);
            else
                Console.WriteLine("No LCS");
        }

        static void printMatrix(int[,] mat)
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

        public static void driver()
        {
            string a = "ABCDGH";
            string b = "AEDFHR";
            LongestCommSubSeq(a, b);
        }
    }
}
