using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
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
            int leftSum = 0,
                rightSum = 0,
                bestBalance = -1;

            //Array scan 1: calculate array total sum
            for (int i = 0; i < A.Length; i++)
            {
                rightSum += A[i];
            }

            //Array scan 2: calculate equilibrium
            for (int i = 0; i < A.Length - 1; i++)
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

    }
}
