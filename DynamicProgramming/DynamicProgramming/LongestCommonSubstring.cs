using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    class LongestCommonSubstring
    {
        static string LongestCommonSubStr(string a, string b)
        {
	        int[, ] lcs = new int[a.Length + 1, b.Length +1];
	        int mi = 0, mj = 0, max = -1;

	        for(int i = 0; i < lcs.GetLength(0); i++)
	        {
		        for(int j = 0; j < lcs.GetLength(1); j++)
		        {
			        if(i == 0 || j == 0)
				        lcs[i, j] = 0;
			        else
			        {
				        if(a[i-1] == b[j-1])
				        {
					        lcs[i, j] = lcs[i-1, j-1] + 1;
					        if(max < lcs[i, j])
					        {
						        max = lcs[i, j];
						        mi = i-1;
						        mj = j-1;
					        }
				        }
				        else
					        lcs[i, j] = 0;				
			        }
		        }
	        }
	        printMatrix(lcs);
            string str = "";
	        if(mi > 0 && mj > 0 && (mi-max+1)>=0)
	        {       
                Console.WriteLine("Longest Common SubStr = {0}", (str = a.Substring(mi-max + 1, max)));
	        }
            return str;
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
            string a = "banana";
            string b = "awanatodayand";
            LongestCommonSubStr(a, b);
        }
    }
}
