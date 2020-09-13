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
        [InlineData(new int[] { 3, 4, 3, 2, 3, -1, 3, 3 }, 4)]
        [InlineData(new int[] { 4, 3, 4, 4, 4, 2 }, 2)]
        [InlineData(new int[] { 4, 4, 2, 5, 3, 4, 4, 4 }, 3)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, 0)]
        public void EquiLeaderTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.EquiLeader(A));
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 3, 2, 3, -1, 3, 3 }, 0)]
        [InlineData(new int[] { 3, 4, 3, 2, 3, -1, 3, 5 }, -1)]
        [InlineData(new int[] { 3 }, 0)]
        [InlineData(new int[] { }, -1)]
        public void DominatorTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.Dominator(A));
        }

        [Theory]
        [InlineData(new int[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 }, 7)]
        public void StoneWallTest(int[] H, int expected)
        {
            Assert.Equal(expected, _codility.StoneWall(H));
        }

        [Theory]
        [InlineData("(()(())())", 1)]
        [InlineData("())", 0)]
        [InlineData(")(", 0)]
        public void NestingTest(String S, int expected)
        {
            Assert.Equal(expected, _codility.Nesting(S));
        }

        [Theory]
        [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 0, 0, 0 }, 2)]
        [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 0, 0, 0, 1 }, 5)]
        [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 1, 0, 1, 0, 1 },  3)]
        [InlineData(new int[] { 4, 3, 2, 0, 5 }, new int[] { 0, 1, 0, 0, 0 },  2)]
        [InlineData(new int[] { 4, 3, 2, 1, 5 }, new int[] { 0, 1, 1, 0, 0 },  2)]
        [InlineData(new int[] { 4, 3, 2, 5, 6 }, new int[] { 1, 0, 1, 0, 1 },  2)]
        [InlineData(new int[] { 7, 4, 3, 2, 5, 6 }, new int[] { 0, 1, 1, 1, 0, 1 },  3)]
        [InlineData(new int[] { 3, 4, 2, 1, 5 }, new int[] { 1, 0, 0, 0, 0 },  4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 1, 1, 1, 0 }, 1)]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 1 }, 2)]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 0 }, 2)]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 }, 1)]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 0 }, 2)]
        [InlineData(new int[] { 1, 0 }, new int[] { 0, 1 }, 2)]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 }, 1)]
        [InlineData(new int[] { 1, 0 }, new int[] { 1, 1 }, 2)]
        [InlineData(new int[] { 0 }, new int[] { 0 }, 1)]
        [InlineData(new int[] { 0 }, new int[] { 1 }, 1)]
        [InlineData(new int[] { 1 }, new int[] { 1 }, 1)]
        public void FishTest(int[] A, int[] B, int expected)
        {
            Assert.Equal(expected, _codility.Fish(A, B));
        }

        [Theory]
        [InlineData("{[()()]}", 1)]
        [InlineData(")(", 0)]
        [InlineData("([)()]", 0)]
        [InlineData("[()}", 0)]
        [InlineData("(((", 0)]
        [InlineData("())(()", 0)]
        public void BracketsTest(String S, int expected)
        {
            Assert.Equal(expected, _codility.Brackets(S));
        }

        [Theory]
        [InlineData(new int[] { 10, 2, 5, 1, 8, 20 }, 1)]
        public void TriangleTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.Triangle(A));
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2, 1, 4, 0 }, 11)]
        [InlineData(new int[] { 1, 1, 1 }, 3)]
        [InlineData(new int[] { 1, 2147483647, 0 }, 2)]
        public void NumberOfDiscIntersectionsTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.NumberOfDiscIntersections(A));
        }

        [Theory]
        [InlineData(new int[] { -3, 1, 2, -2, 5, 6 }, 60)]
        [InlineData(new int[] { -5, 5, -5, 4 }, 125)]
        public void MaxProductOfThreeTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.MaxProductOfThree(A));
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 1, 2, 3, 1 }, 3)]
        public void DistinctTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.Distinct(A));
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 1, 1 }, 5)]
        public void PassingCarsTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.PassingCars(A));
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 2, 5, 1, 5, 8 }, 1)]
        [InlineData(new int[] { 100, -100 }, 0)]
        public void MinAvgTwoSliceTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.MinAvgTwoSlice(A));
        }

        [Theory]
        [InlineData("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 }, new int[] { 2, 4, 1 })]
        [InlineData("A", new int[] { 0 }, new int[] { 0 }, new int[] { 1 })]
        public void GenomicRangeQueryTest(String S, int[] P, int[] Q, int[] expected)
        {
            Assert.Equal(expected, _codility.GenomicRangeQuery(S, P, Q));
        }

        [Theory]
        [InlineData(6, 11, 2, 3)]
        [InlineData(0, 0, 11, 1)]
        public void CountDiv(int A, int B, int K, int expected)
        {
            Assert.Equal(expected, _codility.CountDiv(A, B, K));
        }

        [Theory]
        [InlineData(new int[] { 4, 1, 3 ,2 }, 1)]
        [InlineData(new int[] { 4, 1, 3 }, 0)]
        [InlineData(new int[] { 4, 1 }, 0)]
        [InlineData(new int[] { 2, 1 }, 1)]
        [InlineData(new int[] { 1, 1 }, 0)]
        [InlineData(new int[] { 4 }, 0)]
        public void PermCheckTest(int[] A, int expected)
        {
            Assert.Equal(expected, _codility.PermCheck(A));
        }

        [Theory]
        [InlineData(5, new int[] { 3, 4, 4, 6, 1, 4, 4 }, new int[] { 3, 2, 2, 4, 2 })]
        [InlineData(1, new int[] { 2, 1, 1, 2, 1 }, new int[] { 3 })]
        public void MaxCountersTest(int N, int[] A, int[] expected)
        {
            Assert.Equal(expected, _codility.MaxCounters(N, A));
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
