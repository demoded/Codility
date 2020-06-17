﻿using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace Codility
{
    /// <summary>
    /// Collection of Codility lessons
    /// </summary>
    public class CodilitySolutions
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
            int[] B = new int[X+1];
            
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
        /// A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.
        /// Any integer P, such that 0 &lt; P&lt;N, splits this tape into two non-empty parts: 
        /// A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].
        /// The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
        /// In other words, it is the absolute difference between the sum of the first part and the sum of the second part.
        /// <example>
        /// For example, consider array A such that:
        /// <code><list type="table">
        /// <item> A[0] = 3</item>
        /// <item> A[1] = 1</item>
        /// <item> A[2] = 2</item>
        /// <item> A[3] = 4</item>
        /// <item> A[4] = 3</item>
        /// </list></code>
        /// We can split this tape in four places:
        /// <code><list type="table">
        /// <item>P = 1, difference = | 3 − 10| = 7</item>
        /// <item>P = 2, difference = | 4 − 9| = 5</item>
        /// <item>P = 3, difference = | 6 − 7| = 1</item>
        /// <item>P = 4, difference = | 10 − 3| = 7</item>
        /// </list></code>
        /// the function should return 1, as explained above.
        /// </example>
        /// Write a function:
        /// <code>class Solution { public int solution(int[] A); }</code>
        /// that, given a non-empty array A of N integers, returns the minimal difference that can be achieved.
        /// Write an efficient algorithm for the following assumptions:
        /// N is an integer within the range[2..100, 000];
        /// each element of array A is an integer within the range[−1, 000..1, 000].
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int TapeEquilibrium_solution(int[] A)
        {
            int leftSum=0, 
                rightSum=0, 
                bestBalance=-1;

            //Array scan 1: calculate array total sum
            for (int i = 0; i < A.Length; i++)
            {
                rightSum += A[i];
            }

            //Array scan 2: calculate equilibrium
            for (int i = 0; i < A.Length-1; i++)
            {
                leftSum += A[i];
                rightSum -= A[i];
                if (bestBalance == -1)
                {
                    bestBalance = Math.Abs(leftSum - rightSum);
                }
                    
                if (Math.Abs(leftSum - rightSum) < bestBalance)
                {
                    bestBalance = Math.Abs(leftSum - rightSum);
                }
            }

            return bestBalance;
        }

        /// <summary>
        /// An array A consisting of N different integers is given. 
        /// The array contains integers in the range[1..(N + 1)], which means that exactly one element is missing.
        /// Your goal is to find that missing element.
        /// Write a function: that, given an array A, returns the value of the missing element.
        /// <example>
        /// For example, given array A { 2, 3, 1, 5}
        /// the function should return 4, as it is the missing element.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// N is an integer within the range[0..100, 000];
        /// the elements of A are all distinct;
        /// each element of array A is an integer within the range[1..(N + 1)]. 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PermMissingElem_solution(int[] A)
        {
            int expected = 1;
            if (A.Length > 0)
            {
                Array.Sort(A);
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] != expected)
                    {
                        return expected;
                    }
                    expected++;
                }
            }

            return expected;
        }

        /// <summary>
        /// A small frog wants to get to the other side of the road.
        /// The frog is currently located at position X and wants to get to a position greater than or equal to Y.
        /// The small frog always jumps a fixed distance, D.
        /// Count the minimal number of jumps that the small frog must perform to reach its target.
        ///
        /// Write a function: that, given three integers X, Y and D, 
        /// returns the minimal number of jumps from position X to a position equal to or greater than Y.
        ///
        /// <example>
        /// For example, given:
        ///<code><list type="table">
        /// <item>X = 10</item>
        /// <item>Y = 85</item>
        /// <item>D = 30</item>
        ///</list></code>
        /// the function should return 3, because the frog will be positioned as follows:
        ///<list type="">
        ///<item>after the first jump, at position 10 + 30 = 40</item>
        ///<item>after the second jump, at position 10 + 30 + 30 = 70</item>
        ///<item>after the third jump, at position 10 + 30 + 30 + 30 = 100</item>
        ///</list>
        ///</example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="table">
        ///<item>X, Y and D are integers within the range[1..1, 000, 000, 000];</item>
        ///<item>X ≤ Y.</item>
        /// </list>
        /// </summary>
        /// <param name="X">currently located at position</param>
        /// <param name="Y">goal position</param>
        /// <param name="D">jump distance</param>
        /// <returns></returns>
        public int FrogJump_solution(int X, int Y, int D)
        {
            double jumps = (double)(Y - X) / D;
            return (int)Math.Ceiling(jumps);
        }

        /// <summary>
        /// A non-empty array A consisting of N integers is given.
        /// The array contains an odd number of elements,
        /// and each element of the array can be paired with another element that has the same value,
        /// except for one element that is left unpaired.
        /// <example>
        /// For example, in array A such that { 9, 3, 9, 3, 9, 7, 9 }
        /// <list type="table">
        /// <item>the elements at indexes 0 and 2 have value 9,</item>
        /// <item>the elements at indexes 1 and 3 have value 3,</item>
        /// <item>the elements at indexes 4 and 6 have value 9,</item>
        /// <item>the element at index 5 has value 7 and is unpaired.</item>
        /// </list>
        /// </example>
        /// Write a function: that, given an array A consisting of N integers fulfilling the above conditions, returns the value of the unpaired element.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="table">
        /// N is an odd integer within the range [1..1,000,000];
        /// <item>each element of array A is an integer within the range[1..1, 000, 000, 000];</item>
        /// <item>all but one of the values in A occur an even number of times.</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int OddOccurrencesInArray_solution(int[] A)
        {
            if (A.Length == 0)
            {
                return 0;
            }

            Array.Sort(A);

            for (int i = 0; i <= A.Length; i += 2)
            {
                if (i == A.Length-1)
                {
                    return A[i];
                }
                else
                {
                    if (A[i] != A[i + 1])
                    {
                        return A[i];
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// An array A consisting of N integers is given.
        /// Rotation of the array means that each element is shifted right by one index, 
        /// and the last element of the array is moved to the first place.
        /// The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.
        /// Write a function that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.
        ///<example>
        /// For example:
        /// <list type="table">
        /// <item>A = [3, 8, 9, 7, 6]</item>
        /// <item>K = 3</item>
        /// <item>the function should return [9, 7, 6, 3, 8]. </item>
        /// <item>Three rotations were made:</item>
        /// <item>[3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]</item>
        /// <item>[6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]</item>
        /// <item>[7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]</item>
        ///</list>
        ///<list type="table">
        /// A = [0, 0, 0]
        /// K = 1
        /// return [0, 0, 0]
        ///</list>
        ///<list type="table">
        /// A = [1, 2, 3, 4]
        /// K = 4
        /// return [1, 2, 3, 4]
        /// </list>
        ///</example> 
        ///Assume that:
        ///<list type="table">
        ///<item>N and K are integers within the range [0..100];</item>
        ///<item>each element of array A is an integer within the range[−1, 000..1, 000].</item>
        ///<item>In your solution, focus on correctness.The performance of your solution will not be the focus of the assessment.</item>
        ///</list>
        /// </summary>
        /// <param name="A">source array</param>
        /// <param name="K">number of steps to rotate</param>
        /// <returns></returns>
        public int[] CyclicRotation_solution(int[] A, int K)
        {
            int[] result = new int[A.Length];

            if (A.Length == 0)
            {
                return A;
            }

            //find array splitting position
            int start = K % A.Length;

            if (start > 0)
            {
                //take last K elements and copy them to the beginning of result
                Array.Copy(A, A.Length - start, result, 0, start);
                //take first elements before Kth position and copy
                Array.Copy(A, 0, result, start, A.Length - start);
            }
            else
            {
                //in case of shifting to the length of A, just return A
                return A;
            }

            return result;
        }

        /// <summary>
        /// A binary gap within a positive integer N is any maximal sequence of consecutive zeros 
        /// that is surrounded by ones at both ends in the binary representation of N.
        ///<example>For example:<list type="table">
        ///<item>number 1040 has binary representation 10000010001 and so its longest binary gap is of length 5</item>
        ///<item>number 9 has binary representation 1001 and contains a binary gap of length 2</item>
        ///<item>number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3</item>
        ///<item>number 20 has binary representation 10100 and contains one binary gap of length 1</item>
        ///<item>number 15 has binary representation 1111 and has no binary gaps</item>
        ///<item>number 32 has binary representation 100000 and has no binary gaps</item>
        ///</list></example>
        /// Write a function that, given a positive integer N, returns the length of its longest binary gap.
        /// The function should return 0 if N doesn't contain a binary gap.
        /// Write an efficient algorithm for the following assumptions:
        /// N is an integer within the range[1..2, 147, 483, 647].
        ///</summary>
        ///<param name="N"></param>
        ///<returns></returns>
        public int BinaryGap_solution(int N)
        {
            var binaryString = Convert.ToString(N, 2).Trim('0');
            var zeroGroups = binaryString.Split('1');
            var longest = zeroGroups.OrderByDescending(s => s.Length).FirstOrDefault();

            return longest.Length;
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
