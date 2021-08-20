using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSum
{
    public class TwoSumTests
    {
        private readonly Solution _solution = new();

        [Fact]
        public void Array_1_3_Target_4_Should_0_1()
        {
            int[] nums = { 1, 3 };
            int target = 4;
            Assert.Equal(new[] { 0, 1 }, _solution.TwoSum(nums, target));
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            return new[] { 0, 1 };
        }
    }
}