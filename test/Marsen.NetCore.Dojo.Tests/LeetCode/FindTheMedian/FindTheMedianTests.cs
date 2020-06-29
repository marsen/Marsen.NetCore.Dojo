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
            var arr = new int[] {1};
            Assert.Equal(1, _target.Median(arr));
        }

        [Fact]
        public void arr_2_should_be_2()
        {
            var arr = new int[] {2};
            Assert.Equal(2, actual: _target.Median(arr));
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