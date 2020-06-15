using System;
using Xunit;
using Codility;
using System.Linq;

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
        [InlineData(5, new int[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 6)]
        public void FrogRiverOneTest(int X, int[] A, int expected)
        {
            Assert.Equal(expected, _codility.FrogRiverOne_solution(X, A));
        }

        [Theory]
        [InlineData(new int[] { 3, 1, 2, 4, 3 }, 1)]
        [InlineData(new int[] { 1000, 2000 }, 1000)]
        [InlineData(new int[] { 2000, 2000 }, 0)]
        public void TapeEquilibriumTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.TapeEquilibrium_solution(A));
        }

        [Theory]
        [InlineData(new int[] { 2, 3, 1, 5 }, 4)]
        [InlineData(new int[] { }, 1)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] { 1, 3 }, 2)]
        [InlineData(new int[] { 2, 3 }, 1)]
        [InlineData(new int[] { 1, 2 }, 3)]

        public void PermMissingElemTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.PermMissingElem_solution(A));
        }

        [Theory]
        [InlineData(10, 85, 30, 3)]
        public void FrogJmpTest(int X, int Y, int D, int expected)
        {
            Assert.Equal(expected, _codility.FrogJump_solution(X, Y, D));
        }

        [Theory]
        [InlineData(new int[] { 9, 3, 9, 3, 9, 7, 9 }, 7)]
        [InlineData(new int[] { 42 }, 42)]
        [InlineData(new int[] { }, 0)]
        public void OddOccurrencesInArrayTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.OddOccurrencesInArray_solution(A));
        }

        [Theory]
        [InlineData(new int[] { 3, 8, 9, 7, 6, 1, 2 }, 3, new int[] { 6, 1, 2, 3, 8, 9, 7})]
        [InlineData(new int[] { 0, 0, 0 }, 1, new int[] { 0, 0, 0 })]
        [InlineData(new int[] { 1, 2, 3, 4 }, 4, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 1 }, 3, new int[] { 1 })]
        [InlineData(new int[] { }, 1, new int[] { })]
        [InlineData(new int[] { 1, 2, 3 }, 7, new int[] { 3, 1, 2 })]
        public void CyclicRotationTest(int[] A, int K, int[] expected)
        {
            Assert.Equal(expected, _codility.CyclicRotation_solution(A, K));
        }

        [Theory]
        [InlineData(1041, 5)]
        [InlineData(15, 0)]
        [InlineData(32, 0)]
        public void BinaryGapTest(int input, int expected)
        {
            Assert.Equal(expected, _codility.BinaryGap_solution(input));
        }

        [Theory]
        [InlineData(new int[]{1, 3, 6, 4, 1, 2}, 5)]
        [InlineData(new int[]{1, 2, 3}, 4)]
        [InlineData(new int[]{-1, -3}, 1)]
        [InlineData(new int[]{2}, 1)]
        public void MissingInteger(int[] input, int expected)
        {
            Assert.Equal(expected, _codility.MissingInteger_solution(input));
        }
    }
}
