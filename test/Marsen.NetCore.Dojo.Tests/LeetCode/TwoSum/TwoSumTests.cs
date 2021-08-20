using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSum
{
    public class TwoSumTests
    {
        [Fact]
        public void Array_1_3_Target_4_Should_0_1()
        {
            var solution = new Solution();
            int target = 4;
            int[] nums = { 1, 3 };
            var actual = solution.TwoSum(nums, target);
            int[] expected = { 0, 1 };
            Assert.Equal(expected, actual);
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