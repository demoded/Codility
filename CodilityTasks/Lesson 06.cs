using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// An array A consisting of N integers is given. A triplet (P, Q, R) is triangular if 0 ≤ P &lt; Q &lt; R &lt; N and:
        /// <list type="bullet">
        /// <item>A[P] + A[Q] > A[R],</item>
        /// <item>A[Q] + A[R] > A[P],</item>
        /// <item>A[R] + A[P] > A[Q].</item>
        /// </list>
        /// <example>
        /// For example, consider array A such that:
        /// <list type="table">
        /// <item>A[0] = 10</item>
        /// <item>A[1] = 2</item>
        /// <item>A[2] = 5</item>
        /// <item>A[3] = 1</item>
        /// <item>A[4] = 8</item>
        /// <item>A[5] = 20</item>
        /// </list>
        /// Triplet(0, 2, 4) is triangular. The function should return 1.
        /// </example>
        /// <example>
        /// <list type="table">
        /// <item>A[0] = 10</item>
        /// <item>A[1] = 50</item>
        /// <item>A[2] = 5</item>
        /// <item>A[3] = 1</item>
        /// </list>
        /// the function should return 0.
        /// </example>
        /// Write a function that, given an array A consisting of N integers, returns 1 if there exists a triangular triplet for this array and returns 0 otherwise.
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..100, 000];</item>
        /// <item>each element of array A is an integer within the range[−2, 147, 483, 648..2, 147, 483, 647].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int Triangle(int[] A)
        {
            // the trick(explanation):
            // Task condition "0 ≤ P < Q < R < N" only means that P,Q,R couldn't be the same indexes.
            // It doesn't mean that order of PQR in original array is imprtant. Thus, it's possible po sort array in order to simplify validation and use only 1 loop.
            // The task related to finding triangles in array of triange edges (edge lenghts). And the order of edges doesn't really matter.
            if (A.Length >= 3)
            {
                Array.Sort(A);

                for (int i = 0; i < A.Length - 2; i++)
                {
                    if ((long)A[i] + (long)A[i + 1] > (long)A[i + 2])
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// We draw N discs on a plane. The discs are numbered from 0 to N − 1. An array A of N non-negative integers, specifying the radiuses of the discs, is given. The J-th disc is drawn with its center at (J, 0) and radius A[J].
        /// We say that the J-th disc and K-th disc intersect if J ≠ K and the J-th and K-th discs have at least one common point(assuming that the discs contain their borders).
        ///
        /// The figure below shows discs drawn for N = 6 and A as follows:
        /// <example>
        /// <list type="table">
        /// <item>A[0] = 1</item>
        /// <item>A[1] = 5</item>
        /// <item>A[2] = 2</item>
        /// <item>A[3] = 1</item>
        /// <item>A[4] = 4</item>
        /// <item>A[5] = 0</item>
        /// </list>
        /// https://codility-frontend-prod.s3.amazonaws.com/media/task_static/number_of_disc_intersections/static/images/auto/0eed8918b13a735f4e396c9a87182a38.png
        /// There are eleven (unordered) pairs of discs that intersect, namely:
        /// <list type="bullet">
        /// <item>discs 1 and 4 intersect, and both intersect with all the other discs;</item>
        /// <item>disc 2 also intersects with discs 0 and 3.</item>
        /// </list>
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..100, 000];</item>
        /// <item>each element of array A is an integer within the range[0..2, 147, 483, 647].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int NumberOfDiscIntersections(int[] A)
        {
            const int pairLimit = 10000000;
            int length = A.Length;
            int paircount = 0;
            int openCount = 0;
            long[] discStart = new long[length];
            long[] discEnd = new long[length];
            int startPos = 0;
            int endPos = 0;

            //first transform given array of disc radiuses to two arrays of start and end positions
            for (long i = 0; i < A.Length; i++)
            {
                discStart[i] = i - A[i];
                discEnd[i] = i + A[i];
            }

            Array.Sort(discStart);
            Array.Sort(discEnd);

            //while looking through start positions array
            while (startPos < length)
            {
                //check if one of discs closed
                while (discStart[startPos] > discEnd[endPos])
                {
                    openCount--;
                    endPos++;
                }

                //sum current paircount and number of open discs
                //task condition to limit paircount less than 10 000 000
                if ((paircount + openCount) > pairLimit)
                {
                    paircount = -1;
                    break;
                }
                else
                {
                    paircount += openCount;
                }

                openCount++;
                startPos++;
            }

            return paircount;
        }
        /// <summary>
        /// Lesson 6.2 MaxProductOfThree
        /// A non-empty array A consisting of N integers is given. The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P &lt; Q &lt; R &lt; N).
        /// <example>For example, array A such that:
        /// <list type="table">
        /// <item>A[0] = -3</item>
        /// <item>A[1] = 1</item>
        /// <item>A[2] = 2</item>
        /// <item>A[3] = -2</item>
        /// <item>A[4] = 5</item>
        /// <item>A[5] = 6</item>
        /// </list>
        /// contains the following example triplets:
        /// <list type="bullet">
        /// <item>(0, 1, 2), product is −3 * 1 * 2 = −6</item>
        /// <item>(1, 2, 4), product is 1 * 2 * 5 = 10</item>
        /// <item>(2, 4, 5), product is 2 * 5 * 6 = 60</item>
        /// </list>
        /// The function should return 60, as the product of triplet (2, 4, 5) is maximal.
        /// </example>
        /// <list type="bullet">
        /// <item>N is an integer within the range [3..100,000];</item>
        /// <item>each element of array A is an integer within the range[−1, 000..1, 000].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MaxProductOfThree(int[] A)
        {
            if (A.Length >= 3)
            {
                Array.Sort(A);

                int prod1 = A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3]; //combination of the last 3 numbers
                int prod2 = A[0] * A[1] * A[A.Length - 1]; //in case there are negative numbers take 2 smallest negative numbers and 1 largest positive

                return prod1 > prod2 ? prod1 : prod2;
            }

            return 0;
        }

        /// <summary>
        /// Lesson 6.1 Disitnct (tiny cute one line solution) :)
        /// Write a function that, given an array A consisting of N integers, returns the number of distinct values in array A.
        /// <example>
        /// For example, given array A consisting of six elements such that:
        /// <list type="table">
        /// <item>A[0] = 2</item>
        /// <item>A[1] = 1</item>
        /// <item>A[2] = 1</item>
        /// <item>A[3] = 2</item>
        /// <item>A[4] = 3</item>
        /// <item>A[5] = 1</item></list>
        /// the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[0..100, 000];</item>
        /// <item>each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int Distinct(int[] A)
        {
            return A.ToList().Distinct().Count();
        }
    }
}
