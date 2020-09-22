using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// A positive integer D is a factor of a positive integer N if there exists an integer M such that N = D * M.
        /// <example>
        /// For example, 6 is a factor of 24, because M = 4 satisfies the above condition(24 = 6 * 4).
        /// </example>
        /// Write a function that, given a positive integer N, returns the number of its factors.
        /// <example>
        /// For example, given N = 24, the function should return 8, because 24 has 8 factors, namely 1, 2, 3, 4, 6, 8, 12, 24. There are no other factors of 24.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..2, 147, 483, 647].</item>
        /// </list>
        /// </summary>
        /// <param name="N">ingeger value</param>
        /// <returns>number of N factors</returns>
        public int CountFactors(int N)
        {
            int count = 0;
            long i = 1;

            while (i * i < N)
            {
                if (N % i == 0)
                {
                    count += 2;
                }

                i++;
            }

            if (i * i == N)
            {
                count++;
            }

            return count;
        }
    }
}
