using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.FindTheMedian
{
    public class FindTheMedianTests
    {
        [Fact]
        public void arr_1_should_be_1()
        {
            var target = new ArrayFinder();
            var arr = new int[1];
            Assert.Equal(1, target.Median(arr));
        }
    }

    public class ArrayFinder
    {
        public int Median(Array array)
        {
            throw new System.NotImplementedException();
        }
    }
}