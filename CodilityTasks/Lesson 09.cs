using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// An array A consisting of N integers is given. It contains daily prices of a stock share for a period of N consecutive days. 
        /// If a single share was bought on day P and sold on day Q, where 0 ≤ P ≤ Q &lt; N, 
        /// then the profit of such transaction is equal to A[Q] − A[P], provided that A[Q] ≥ A[P]. 
        /// Otherwise, the transaction brings loss of A[P] − A[Q].
        /// <example>
        /// For example, consider the following array A consisting of six elements such that:
        /// <list type="table">
        /// <item>A[0] = 23171</item>
        /// <item>A[1] = 21011</item>
        /// <item>A[2] = 21123</item>
        /// <item>A[3] = 21366</item>
        /// <item>A[4] = 21013</item>
        /// <item>A[5] = 21367</item>
        /// </list>
        /// </example>
        /// If a share was bought on day 0 and sold on day 2, a loss of 2048 would occur because A[2] − A[0] = 21123 − 23171 = −2048. 
        /// If a share was bought on day 4 and sold on day 5, a profit of 354 would occur because A[5] − A[4] = 21367 − 21013 = 354. 
        /// Maximum possible profit was 356. It would occur if a share was bought on day 1 and sold on day 5.
        /// Write a function, that, given an array A consisting of N integers containing daily prices of a stock share for a period of N consecutive days, returns the maximum possible profit from one transaction during this period.
        /// The function should return 0 if it was impossible to gain any profit.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..400, 000];</item>
        /// <item>each element of array A is an integer within the range[0..200, 000].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MaxProfit(int[] A)
        {
            int minValue = 0;
            int maxProfit = 0;

            if (A.Length == 0)
            {
                return 0;
            }
            else
            {
                minValue = A[0];
            }

            for (int i = 0; i < A.Length; i++)
            {
                minValue = Math.Min(minValue, A[i]);
                maxProfit = Math.Max(maxProfit, A[i] - minValue);
            }

            return Math.Max(maxProfit, 0);
        }

        /// <summary>
        /// A non-empty array A consisting of N integers is given. 
        /// A pair of integers (P, Q), such that 0 ≤ P ≤ Q &lt; N, is called a slice of array A. 
        /// The sum of a slice (P, Q) is the total of A[P] + A[P+1] + ... + A[Q].
        /// Write a function: that, given an array A consisting of N integers, returns the maximum sum of any slice of A.
        /// <example>For example, given array A such that:
        /// <list type="table">
        /// <item>A[0] = 3</item>
        /// <item>A[1] = 2</item>
        /// <item>A[2] = -6</item>
        /// <item>A[3] = 4</item>
        /// <item>A[4] = 0</item>
        /// </list>
        /// the function should return 5 because:
        /// <list type="bullet">
        /// <item>(3, 4) is a slice of A that has sum 4,</item>
        /// <item>(2, 2) is a slice of A that has sum −6,</item>
        /// <item>(0, 1) is a slice of A that has sum 5,</item>
        /// <item>no other slice of A has sum greater than(0, 1).</item>
        /// </list>
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..1000000];</item>
        /// <item>each element of array A is an integer within the range[−1000000..1000000];</item>
        /// <item>the result will be an integer within the range[−2, 147, 483, 648..2, 147, 483, 647].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MaxSliceSum(int[] A)
        {
            int maxsum = -1000000;
            int currsum = -1000000;

            for (int i = 0; i < A.Length; i++)
            {
                currsum = Math.Max(A[i], currsum + A[i]);
                maxsum = Math.Max(maxsum, currsum);
            }

            return maxsum;
        }
    }
}
