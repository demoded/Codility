using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// An array A consisting of N integers is given. The dominator of array A is the value that occurs in more than half of the elements of A.
        /// <example>
        /// For example, consider array A such that
        /// <list type="table">
        /// <item>A[0] = 3</item>
        /// <item>A[1] = 4</item>
        /// <item>A[2] = 3</item>
        /// <item>A[3] = 2</item>
        /// <item>A[4] = 3</item>
        /// <item>A[5] = -1</item>
        /// <item>A[6] = 3</item>
        /// <item>A[7] = 3</item>
        /// </list>
        /// </example>
        /// The dominator of A is 3 because it occurs in 5 out of 8 elements of A(namely in those with indices 0, 2, 4, 6 and 7) 
        /// and 5 is more than a half of 8.
        /// Write a function that, given an array A consisting of N integers, 
        /// returns index of any element of array A in which the dominator of A occurs.
        /// The function should return −1 if array A does not have a dominator.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..100, 000];</item>
        /// <item>each element of array A is an integer within the range[−2, 147, 483, 648..2, 147, 483, 647].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int Dominator(int[] A)
        {
            return Array.IndexOf(A, A.GroupBy(i => i).Where(i => i.Count() > A.Length / 2).FirstOrDefault()?.Key);

            //Dictionary<int, int> hash = new Dictionary<int, int>();

            //if (A.Length == 0)
            //{
            //    return -1;
            //}

            //if (A.Length == 1)
            //{
            //    return 0;
            //}

            //hash.Add(A[0], 1);
            //int cur = 0;

            //for (int i = 1; i < A.Length; i++)
            //{
            //    if (hash.TryGetValue(A[i], out cur))
            //    {
            //        cur++;
            //        if (cur > A.Length / 2)
            //        {
            //            return Array.FindIndex(A, f => f == A[i]);
            //        }
            //        hash[A[i]] = cur;
            //    }
            //    else
            //    {
            //        hash.Add(A[i], 1);
            //    }
            //}

            //return -1;
        }
    }
}
