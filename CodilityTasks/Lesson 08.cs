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

        /// <summary>
        /// A non-empty array A consisting of N integers is given.
        /// The leader of this array is the value that occurs in more than half of the elements of A.
        /// An equi leader is an index S such that 0 ≤ S&lt;N − 1 
        /// and two sequences A[0], A[1], ..., A[S] and A[S + 1], A[S + 2], ..., A[N − 1] have leaders of the same value.
        /// <example>
        /// For example, given array A such that:
        /// <list type="table">
        /// <item>A[0] = 4</item>
        /// <item>A[1] = 3</item>
        /// <item>A[2] = 4</item>
        /// <item>A[3] = 4</item>
        /// <item>A[4] = 4</item>
        /// <item>A[5] = 2</item></list>
        /// we can find two equi leaders:
        /// <list type="bullet">
        /// <item>0, because sequences: (4) and (3, 4, 4, 4, 2) have the same leader, whose value is 4.</item>
        /// <item>2, because sequences: (4, 3, 4) and(4, 4, 2) have the same leader, whose value is 4.</item>
        /// </list>
        /// the function should return 2, as explained above.
        /// </example>
        /// The goal is to count the number of equi leaders.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..100, 000];</item>
        /// <item>each element of array A is an integer within the range[−1, 000, 000, 000..1, 000, 000, 000].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int EquiLeader(int[] A)
        {
            int sameLeadersCount = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                var a1 = EquiLeaderLocal(SubArray(A, 0, i + 1));
                var a2 = EquiLeaderLocal(SubArray(A, i + 1, A.Length - i + 1));
                if (a1 == a2 && a1 > 0)
                {
                    sameLeadersCount++;
                }
            }

            return sameLeadersCount;
        }

        int[] SubArray(int[] array, int offset, int length)
        {
            return array.Skip(offset)
                        .Take(length)
                        .ToArray();
        }

        int EquiLeaderLocal(int[] A)
        {
            Stack<int> stack = new Stack<int>();
            int count = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (stack.Any())
                {
                    if (stack.Peek() == A[i])
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                        if (count == 0)
                        {
                            stack.Pop();
                            stack.Push(A[i]);
                            count = 1;
                        }
                    }
                }
                else
                {
                    stack.Push(A[i]);
                    count = 1;
                }
            }

            if (stack.Any())
            {
                int totalCount = 0;
                foreach (int c in A)
                {
                    if (c == stack.Peek())
                    {
                        totalCount++;
                    }
                }
                return totalCount > A.Length / 2 ? stack.Peek() : 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
