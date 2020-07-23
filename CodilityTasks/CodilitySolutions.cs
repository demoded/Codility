using System;
using System.Collections.Generic;
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
            long[] discEnd   = new long[length];
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
                if (openCount > 0 && (paircount + openCount) > pairLimit)
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
            int[] prefixSum = new int[A.Length+1];
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
                double avg2 = (double)(prefixSum[i] - prefixSum[i-2]) / 2;
                if (minAvg > avg2)
                {
                    minAvg = avg2;
                    minStartPos = i-1;
                }

                if (i >= 3)
                {
                    double avg3 = (double)(prefixSum[i] - prefixSum[i-3]) / 3;
                    if (minAvg > avg3)
                    {
                        minAvg = avg3;
                        minStartPos = i-2;
                    }
                }
            }

            return minStartPos-1;
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
                int rangeEnd = Q[i]+1;

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
