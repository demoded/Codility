using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    public partial class CodilitySolutions
    {
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
    }
}
