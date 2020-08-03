using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
        /// <summary>
        /// A non-empty array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road. Array A contains only 0s and/or 1s:
        /// <list type="bullet">
        /// <item>0 represents a car traveling east,</item>
        /// <item>1 represents a car traveling west.</item>
        /// </list>
        /// The goal is to count passing cars.We say that a pair of cars (P, Q), where 0 ≤ P &lt; Q &lt; N, is passing when P is traveling to the east and Q is traveling to the west.
        /// <example>For example, consider array A such that:
        /// <list type="table">
        ///  <item>A[0] = 0</item>
        ///  <item>A[1] = 1</item>
        ///  <item>A[2] = 0</item>
        ///  <item>A[3] = 1</item>
        ///  <item>A[4] = 1</item></list>
        /// We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).
        /// The function should return 5.
        /// </example>
        /// Write a function that, given a non-empty array A of N integers, returns the number of pairs of passing cars.
        /// The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.
        /// 
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..100, 000];</item>
        /// <item>each element of array A is an integer that can have one of the following values: 0, 1.</item>
        /// </list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int PassingCars(int[] A)
        {
            int[] prefixSums = new int[A.Length];
            long passingCars = 0;

            prefixSums[A.Length - 1] = A[A.Length - 1];
            for (int i = A.Length - 2; i >= 0; i--)
            {
                prefixSums[i] = A[i] + prefixSums[i + 1];
                if (A[i] == 0)
                {
                    passingCars += prefixSums[i + 1];
                }
            }

            return passingCars <= 1000000000 ? (int)passingCars : -1;
        }

        /// <summary>
        /// A non-empty array A consisting of N integers is given. A pair of integers (P, Q), such that 0 ≤ P &lt; Q &lt; N, is called a slice of array A (notice that the slice contains at least two elements). The average of a slice (P, Q) is the sum of A[P] + A[P + 1] + ... + A[Q] divided by the length of the slice. To be precise, the average equals (A[P] + A[P + 1] + ... + A[Q]) / (Q − P + 1).
        /// <example>For example, array A such that:
        /// <list type="table">
        /// <item>A[0] = 4</item>
        /// <item>A[1] = 2</item>
        /// <item>A[2] = 2</item>
        /// <item>A[3] = 5</item>
        /// <item>A[4] = 1</item>
        /// <item>A[5] = 5</item>
        /// <item>A[6] = 8</item></list>
        /// contains the following example slices:
        /// <list type="number">
        /// <item>slice(1, 2), whose average is (2 + 2) / 2 = 2;</item>
        /// <item>slice(3, 4), whose average is (5 + 1) / 2 = 3;</item>
        /// <item>slice(1, 4), whose average is (2 + 2 + 5 + 1) / 4 = 2.5.</item>
        /// </list>
        /// </example>
        /// The goal is to find the starting position of a slice whose average is minimal. Write a function that, given a non-empty array A consisting of N integers, returns the starting position of the slice with the minimal average. If there is more than one slice with a minimal average, you should return the smallest starting position of such a slice.
        /// <example>For example, given array A such that:
        /// <list type="table">
        /// <item>A[0] = 4</item>
        /// <item>A[1] = 2</item>
        /// <item>A[2] = 2</item>
        /// <item>A[3] = 5</item>
        /// <item>A[4] = 1</item>
        /// <item>A[5] = 5</item>
        /// <item>A[6] = 8</item></list>
        /// the function should return 1, as explained above.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[2..100, 000];</item>
        /// <item>each element of array A is an integer within the range[−10, 000..10, 000].</item></list>
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MinAvgTwoSlice(int[] A)
        {
            int[] prefixSum = new int[A.Length + 1];
            double minAvg = int.MaxValue;
            int minStartPos = 0;

            //calculate prefux Sums
            for (int i = 0; i < A.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + A[i];
            }

            //The trick here is that only average of slices by 2 and 3 needs to be checked. 
            //Explanations and mathematical proofs can be found by task title "MinAvgTwoSlice"
            for (int i = 2; i < prefixSum.Length; i++)
            {
                double avg2 = (double)(prefixSum[i] - prefixSum[i - 2]) / 2;
                if (minAvg > avg2)
                {
                    minAvg = avg2;
                    minStartPos = i - 1;
                }

                if (i >= 3)
                {
                    double avg3 = (double)(prefixSum[i] - prefixSum[i - 3]) / 3;
                    if (minAvg > avg3)
                    {
                        minAvg = avg3;
                        minStartPos = i - 2;
                    }
                }
            }

            return minStartPos - 1;
        }

        /// <summary>
        /// A DNA sequence can be represented as a string consisting of the letters A, C, G and T, which correspond to the types of successive nucleotides in the sequence. Each nucleotide has an impact factor, which is an integer. Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively. You are going to answer several queries of the form: What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence?
        /// The DNA sequence is given as a non-empty string S = S[0]S[1]...S[N - 1] consisting of N characters.There are M queries, which are given in non-empty arrays P and Q, each consisting of M integers.The K-th query(0 ≤ K &lt; M) requires you to find the minimal impact factor of nucleotides contained in the DNA sequence between positions P[K] and Q[K] (inclusive).
        /// <example>For example, consider string S = CAGCCTA and arrays P, Q such that:
        /// <list type="table">
        /// <item>P[0] = 2    Q[0] = 4</item>
        /// <item>P[1] = 5    Q[1] = 5</item>
        /// <item>P[2] = 0    Q[2] = 6</item></list>
        /// The answers to these M = 3 queries are as follows:
        /// <list type="bullet">
        /// <item>The part of the DNA between positions 2 and 4 contains nucleotides G and C(twice), whose impact factors are 3 and 2 respectively, so the answer is 2.</item>
        /// <item>The part between positions 5 and 5 contains a single nucleotide T, whose impact factor is 4, so the answer is 4.</item>
        /// <item>The part between positions 0 and 6 (the whole string) contains all nucleotides, in particular nucleotide A whose impact factor is 1, so the answer is 1.</item>
        /// </list>
        /// </example>
        /// Write a function that, given a non-empty string S consisting of N characters and two non-empty arrays P and Q consisting of M integers, returns an array consisting of M integers specifying the consecutive answers to all queries.
        /// Result array should be returned as an array of integers.
        ///
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>N is an integer within the range[1..100, 000];</item>
        /// <item>M is an integer within the range[1..50, 000];</item>
        /// <item>each element of arrays P, Q is an integer within the range[0..N − 1];</item>
        /// <item>P[K] ≤ Q[K], where 0 ≤ K &lt; M;</item>
        /// <item>string S consists only of upper-case English letters A, C, G, T.</item></list>
        /// </summary>
        /// <param name="S"></param>
        /// <param name="P"></param>
        /// <param name="Q"></param>
        /// <returns></returns>
        public int[] GenomicRangeQuery(String S, int[] P, int[] Q)
        {
            int[] ret = new int[P.Length];
            int[,] prefixSums = new int[3, S.Length + 1];

            //calculating prefix sums
            for (int i = 0; i < S.Length; i++)
            {
                int a = 0, c = 0, g = 0;
                switch (S[i])
                {
                    case 'A': a = 1; break;
                    case 'C': c = 1; break;
                    case 'G': g = 1; break;
                }

                prefixSums[0, i + 1] = prefixSums[0, i] + a;
                prefixSums[1, i + 1] = prefixSums[1, i] + c;
                prefixSums[2, i + 1] = prefixSums[2, i] + g;
            }

            for (int i = 0; i < P.Length; i++)
            {
                int rangeStart = P[i];
                int rangeEnd = Q[i] + 1;

                if ((prefixSums[0, rangeEnd] - prefixSums[0, rangeStart]) > 0) //at least one A nucleotid found
                {
                    ret[i] = 1; //return A nucleotid index
                }
                else if ((prefixSums[1, rangeEnd] - prefixSums[1, rangeStart]) > 0) //at least one C nucleotid found
                {
                    ret[i] = 2; //return C nucleotid index
                }
                else if ((prefixSums[2, rangeEnd] - prefixSums[2, rangeStart]) > 0) //at least on G nucleotid found
                {
                    ret[i] = 3; //return G nucleotid index
                }
                else
                {
                    ret[i] = 4; //return T nucleotid index
                }
            }

            return ret;
        }

        /// <summary>
        /// Write a function that, given three integers A, B and K, 
        /// returns the number of integers within the range [A..B] 
        /// that are divisible by K, i.e.:
        /// <code>{ i : A ≤ i ≤ B, i mod K = 0 }</code>
        /// <example>
        /// For example, for A = 6, B = 11 and K = 2, your function should return 3, 
        /// because there are three numbers divisible by 2 within the range[6..11], 
        /// namely 6, 8 and 10.
        /// </example>
        /// Write an efficient algorithm for the following assumptions:
        /// <list type="bullet">
        /// <item>A and B are integers within the range[0..2, 000, 000, 000];</item>
        /// <item>K is an integer within the range[1..2, 000, 000, 000];</item>
        /// <item>A ≤ B.</item></list>
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public int CountDiv(int A, int B, int K)
        {
            int res = B / K - A / K;

            if ((A % K) == 0)
            {
                res++;
            }

            return res;
        }
    }
}
