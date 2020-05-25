using System;
using System.Linq;

namespace Codility
{
    public class CodilitySolutions
    {
        public int BinaryGap_solution(int N)
        {
            var binaryString = Convert.ToString(N, 2).Trim('0');
            var zeroGroups = binaryString.Split('1');
            var longest = zeroGroups.OrderByDescending(s => s.Length).FirstOrDefault();

            return longest.Length;
        }

        public int MissingInteger_solution(int[] A)
        {
            Array.Sort(A);
            var B = Enumerable.Range(1, 100001);
            var C = B.Except(A);

            return C.FirstOrDefault();
        }
    }
}
