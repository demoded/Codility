using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
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
