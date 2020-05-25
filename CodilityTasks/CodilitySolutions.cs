using System;
using System.Linq;

namespace Codility
{
    public class CodilitySolutions
    {
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
