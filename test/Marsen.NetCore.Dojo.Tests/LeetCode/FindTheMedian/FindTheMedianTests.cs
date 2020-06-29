using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.FindTheMedian
{
    public class FindTheMedianTests
    {
        readonly ArrayFinder _target = new ArrayFinder();

        [Fact]
        public void arr_1_should_be_1()
        {
            Assert.Equal(1, _target.Median(new[] {1}));
        }

        [Fact]
        public void arr_2_should_be_2()
        {
            Assert.Equal(2, actual: _target.Median(new[] {2}));
        }
    }

    public class ArrayFinder
    {
        public int Median(int[] array)
        {
            return array[0];
        }
    }
}