using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
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
                if (i == A.Length - 1)
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
    }
}
