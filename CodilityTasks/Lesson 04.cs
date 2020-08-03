using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// A permutation is a sequence containing each element from 1 to N once, and only once.
        /// <example>For example, array A such that:
        /// <list type="table">   
        /// <item>A[0] = 4</item>
        /// <item>A[1] = 1</item>
        /// <item>A[2] = 3</item>
        /// <item>A[3] = 2</item></list>
        /// is a permutation, 
        /// but array A such that:
        /// <list type="table">
        /// <item>A[0] = 4</item>
        /// <item>A[1] = 1</item>
        /// <item>A[2] = 3</item></list>
        /// is not a permutation, because value 2 is missing.
        ///</example>
        /// The goal is to check whether array A is a permutation. 
        /// Write a function that, given an array A, returns 1 if array A is a permutation and 0 if it is not.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PermCheck(int[] A)
        {
            Array.Sort(A);
            int expected = A[0];

            if (expected != 1) return 0;

            foreach (int i in A)
            {
                if (i == expected)
                {
                    expected++;
                    continue;
                }
                else
                {
                    return 0;
                }
            }

            return 1;
        }
        /// <summary>
        /// You are given N counters, initially set to 0, and you have two possible operations on them:
        /// <list type="bullet">
        /// <item>increase(X) − counter X is increased by 1,</item>
        /// <item>max counter − all counters are set to the maximum value of any counter.</item></list>
        /// A non-empty array A of M integers is given. This array represents consecutive operations:
        /// <code><list type="table">
        /// <item>if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),</item>
        /// <item>if A[K] = N + 1 then operation K is max counter.</item>
        /// </list></code>
        /// <example>For example, given integer N = 5 and array A such that:
        /// <code>
        ///     A[0] = 3
        ///     A[1] = 4
        ///     A[2] = 4
        ///     A[3] = 6
        ///     A[4] = 1
        ///     A[5] = 4
        ///     A[6] = 4
        /// </code>
        /// the values of the counters after each consecutive operation will be:
        /// <code>
        ///     (0, 0, 1, 0, 0)
        ///     (0, 0, 1, 1, 0)
        ///     (0, 0, 1, 2, 0)
        ///     (2, 2, 2, 2, 2)
        ///     (3, 2, 2, 2, 2)
        ///     (3, 2, 2, 3, 2)
        ///     (3, 2, 2, 4, 2)
        /// </code>
        /// the function should return [3, 2, 2, 4, 2], as explained above.
        /// </example> 
        /// The goal is to calculate the value of every counter after all operations.
        /// Write a function that, given an integer N and a non-empty array A consisting of M integers, 
        /// returns a sequence of integers representing the values of the counters.
        /// 
        /// Write an efficient algorithm for the following assumptions:
        /// N and M are integers within the range [1..100,000];
        /// each element of array A is an integer within the range [1..N + 1].
        /// </summary>
        /// <param name="N"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] MaxCounters(int N, int[] A)
        {
            int[] ret = new int[N];
            int runningMax = 0;
            int updatedMax = 0;

            foreach (int i in A)
            {
                if (i <= N)
                {
                    if (ret[i - 1] < updatedMax)
                    {
                        ret[i - 1] = updatedMax;
                    }

                    ret[i - 1]++;

                    if (runningMax < ret[i - 1])
                    {
                        runningMax = ret[i - 1];
                    }
                }
                else if (i == N + 1)
                {
                    updatedMax = runningMax;
                }
            }

            for (int i = 0; i < ret.Length; i++)
            {
                if (ret[i] < updatedMax)
                {
                    ret[i] = updatedMax;
                }
            }

            return ret;
        }

        /// <summary>
        /// A small frog wants to get to the other side of a river.
        /// The frog is initially located on one bank of the river(position 0) 
        /// and wants to get to the opposite bank(position X+1). 
        /// Leaves fall from a tree onto the surface of the river.
        /// You are given an array A consisting of N integers representing the falling leaves.
        /// A[K] represents the position where one leaf falls at time K, measured in seconds.
        /// The goal is to find the earliest time when the frog can jump to the other side of the river.
        /// The frog can cross only when leaves appear at every position across the river from 1 to X 
        /// (that is, we want to find the earliest moment when all the positions from 1 to X are covered by leaves).
        /// You may assume that the speed of the current in the river is negligibly small, 
        /// i.e.the leaves do not change their positions once they fall in the river.
        /// <example>For example, you are given integer X = 5 and array A such that:<list type="table">
        /// <item>A[0] = 1</item>
        /// <item>A[1] = 3</item>
        /// <item>A[2] = 1</item>
        /// <item>A[3] = 4</item>
        /// <item>A[4] = 2</item>
        /// <item>A[5] = 3</item>
        /// <item>A[6] = 5</item>
        /// <item>A[7] = 4</item></list>
        /// In second 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position across the river.
        /// The function should return 6, as explained above.
        /// </example>
        /// Write a function: <code>class Solution { public int solution(int X, int[] A); }</code>
        /// that, given a non-empty array A consisting of N integers and integer X, 
        /// returns the earliest time when the frog can jump to the other side of the river.
        /// If the frog is never able to jump to the other side of the river, the function should return −1.
        /// 
        /// Write an efficient algorithm for the following assumptions:<list type="table">
        /// <item>N and X are integers within the range[1..100, 000];</item>
        /// <item>each element of array A is an integer within the range[1..X].</item></list>
        /// </summary>
        /// <param name="X"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public int FrogRiverOne_solution(int X, int[] A)
        {
            int[] B = new int[X + 1];

            Array.Fill(B, 0);
            int leafCounter = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int leaf = A[i];
                if (B[leaf] == 0)
                {
                    B[leaf] = 1;
                    leafCounter++;
                    if (leafCounter == X)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Write a function that, given an array A of N integers, 
        /// returns the smallest positive integer(greater than 0) that does not occur in A.
        ///<example>For example: <list type="table">
        ///<item>Given A = [1, 3, 6, 4, 1, 2], the function should return 5.</item>
        ///<item>Given A = [1, 2, 3], the function should return 4.</item>
        ///<item>Given A = [−1, −3], the function should return 1.</item>
        ///</list></example>
        ///Write an efficient algorithm for the following assumptions:
        ///<list type="table">
        ///<item>N is an integer within the range[1..100, 000];</item>
        ///<item>each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].</item>
        ///</list>
        ///</summary>
        ///<param name="A"></param>
        ///<returns></returns>
        public int MissingInteger_solution(int[] A)
        {
            Array.Sort(A);
            var B = Enumerable.Range(1, 100001);
            var C = B.Except(A);

            return C.FirstOrDefault();
        }
    }
}
