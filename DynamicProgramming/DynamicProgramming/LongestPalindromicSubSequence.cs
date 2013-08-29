using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class LongestPalindromicSubSequence
    {
        //lps[i, j] is the length of longest palindromic ss between a[i to j]
        //lps[i, j] = lps[i+1, j-1] + 1, iff a[i-1] == a[j-1]
        //lps[i, j] = Math.Max(lps[i+1, j], lps[i, j-1]), otherwise
        
        static void LongestPalindromicSS(string a)
        {
            int[,] lps = new int[a.Length, a.Length];

            for (int i = 0; i < a.Length; i++)
                lps[i, i] = 1;

            for (int cl = 2; cl <= a.Length; cl++)  //cl is the length of the plaindromic sub seq
            {
                for (int i = 0; i < (a.Length - cl + 1); i++)
                {
                    int j = i + cl - 1;

                    if (a[i] == a[j] && cl == 2)
                        lps[i, j] = 2;
                    else if (a[i] == a[j])
                        lps[i, j] = lps[i + 1, j - 1] + 2;
                    else
                        lps[i, j] = Math.Max(lps[i, j - 1], lps[i + 1, j]);
                }
            }

            int m = 0;
            int n = a.Length - 1;
            string s = "";
            //if final number is odd then palindromic seq is odd
            bool isodd = lps[m, n] % 2 > 0 ? true : false;
            while (m < a.Length && n >= 0 && lps[m, n] > 1)
            {
                if(lps[m, n] == lps[m+1, n])
                    m++;
                else if (lps[m, n] == lps[m, n - 1])
                    n--;
                else
                {
                    if (lps[m, n] != lps[m + 1, n - 1])
                        s = a[m] + s;
                    m++; n--;
                }
            }
            string temp = "";
            int l = s.Length-1;
            while (l >= 0)
                temp += s[l--];

            if (isodd)
                s =  temp + a[m] + s;
            else
                s = temp + s;

            Console.WriteLine("Length of longest palindromic subsequence = {0}\nLongest Palindromic Sub Seq = {1}", lps[0, a.Length - 1], s);
            Program.printMatrix(lps);
        }

        public static void driver()
        {
            string a = "amlnanndaam";
            LongestPalindromicSS(a);
        }
    }
}
