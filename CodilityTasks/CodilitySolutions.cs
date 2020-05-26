using System;
using System.Linq;

namespace Codility
{
    public class CodilitySolutions
    {
        public int[] CyclicRotation_solution(int[] A, int K)
        {
            /*
            An array A consisting of N integers is given. 
            Rotation of the array means that each element is shifted right by one index, 
            and the last element of the array is moved to the first place. 
            The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.
            Write a function that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.
            For example:
                A = [3, 8, 9, 7, 6]
                K = 3
                the function should return [9, 7, 6, 3, 8]. 
                Three rotations were made:
                [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
                [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
                [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]
            
                A = [0, 0, 0]
                K = 1
                return [0, 0, 0]

                A = [1, 2, 3, 4]
                K = 4
                return [1, 2, 3, 4]
            
            Assume that:
            N and K are integers within the range [0..100];
            each element of array A is an integer within the range [−1,000..1,000].
            In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.
            */
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

        public int BinaryGap_solution(int N)
        {
            /*
            A binary gap within a positive integer N is any maximal sequence of consecutive zeros
            that is surrounded by ones at both ends in the binary representation of N.
            For example:
                number 1040 has binary representation 10000010001 and so its longest binary gap is of length 5
                number 9 has binary representation 1001 and contains a binary gap of length 2
                number 529 has binary representation 1000010001 and contains two binary gaps: one of length 4 and one of length 3
                number 20 has binary representation 10100 and contains one binary gap of length 1
                number 15 has binary representation 1111 and has no binary gaps
                number 32 has binary representation 100000 and has no binary gaps
            
            Write a function that, given a positive integer N, returns the length of its longest binary gap. 
            The function should return 0 if N doesn't contain a binary gap.
            Write an efficient algorithm for the following assumptions:
            N is an integer within the range [1..2,147,483,647].
            */
            var binaryString = Convert.ToString(N, 2).Trim('0');
            var zeroGroups = binaryString.Split('1');
            var longest = zeroGroups.OrderByDescending(s => s.Length).FirstOrDefault();

            return longest.Length;
        }

        public int MissingInteger_solution(int[] A)
        {
            /*
            Write a function that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.
            For example: 
                Given A = [1, 3, 6, 4, 1, 2], the function should return 5.
                Given A = [1, 2, 3], the function should return 4.
                Given A = [−1, −3], the function should return 1.

            Write an efficient algorithm for the following assumptions:
                N is an integer within the range [1..100,000];
                each element of array A is an integer within the range [−1,000,000..1,000,000].
            */
            Array.Sort(A);
            var B = Enumerable.Range(1, 100001);
            var C = B.Except(A);

            return C.FirstOrDefault();
        }
    }
}
