using System;
using Xunit;
using Codility;

namespace Codility_UnitTests
{
    public class CodilityTestCollection
    {
        private CodilitySolutions _codility;

        public CodilityTestCollection()
        {
            _codility = new CodilitySolutions();
        }

        [Theory]
        [InlineData(1041, 5)]
        [InlineData(15, 0)]
        [InlineData(32, 0)]
        public void BinaryGapTest(int input, int expected)
        {
            Assert.Equal(_codility.BinaryGap_solution(input), expected);
        }

        [Theory]
        [InlineData(new int[]{1, 3, 6, 4, 1, 2}, 5)]
        [InlineData(new int[]{1, 2, 3}, 4)]
        [InlineData(new int[]{-1, -3}, 1)]
        [InlineData(new int[]{2}, 1)]
        public void MissingInteger(int[] input, int expected)
        {
            Assert.Equal(_codility.MissingInteger_solution(input), expected);
        }
    }
}
