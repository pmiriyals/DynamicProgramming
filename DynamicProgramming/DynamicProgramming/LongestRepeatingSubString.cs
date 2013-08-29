using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class LongestRepeatingSubString
    {
        static void LongestRepeatingSubStr(string a)
        {
            int[,] lrs = new int[a.Length + 1, a.Length + 1];
            int max = -1, mi = 0, mj = 0;

            for (int i = 0; i < lrs.GetLength(0); i++)
            {
                for (int j = i + 1; j < lrs.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                        lrs[i, j] = 0;
                    else
                    {
                        if (a[i - 1] == a[j - 1])
                        {
                            lrs[i, j] = lrs[i - 1, j - 1] + 1;
                            if (max < lrs[i, j])
                            {
                                max = lrs[i, j];
                                mi = i - 1;
                                mj = j - 1;
                            }
                        }
                        else
                            lrs[i, j] = 0;
                    }
                }
            }

            if (mi > 0 && mj > 0 && (mi - max + 1 >= 0))
                Console.WriteLine("Longest Repeating Substring = {0} ", a.Substring(mi - max + 1, max));
            else
                Console.WriteLine("No LRS");
            //printMatrix(lrs);
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
            string str = "do not ask what your country has done for you but ask what you have done for your country";
            LongestRepeatingSubStr(str);
        }
    }
}
