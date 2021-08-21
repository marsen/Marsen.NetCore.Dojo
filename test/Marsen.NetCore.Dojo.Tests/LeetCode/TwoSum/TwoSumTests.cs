using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSum
{
    public partial class TwoSumTests
    {
        private readonly Solution _solution = new();
        private static int[] _nums;
        private int _target;

        [Fact]
        public void Array_1_3_Target_4_Should_0_1()
        {
            GivenArrayIs(1, 3);
            GivenTargetIs(4);
            ShouldBe(0, 1);
        }

        [Fact]
        public void Array_1_2_3_Target_4_Should_0_2()
        {
            GivenArrayIs(1, 2, 3);
            GivenTargetIs(4);
            ShouldBe(0, 2);
        }


        [Fact]
        public void Array_1_2_3_Target_5_Should_1_2()
        {
            GivenArrayIs(1, 2, 3);
            GivenTargetIs(5);
            ShouldBe(1, 2);
        }

        [Fact]
        public void Array_3_3_Target_6_Should_0_1()
        {
            GivenArrayIs(3, 3);
            GivenTargetIs(6);
            ShouldBe(0, 1);
        }

        [Fact]
        public void Array_1_3_3_Target_6_Should_1_2()
        {
            GivenArrayIs(1, 3, 3);
            GivenTargetIs(6);
            ShouldBe(1, 2);
        }


        [Fact(Skip = "LeetCodeCase")]
        public void LeetCodeCases()
        {
            GivenArrayIs(2, 7, 11, 15);
            GivenTargetIs(9);
            ShouldBe(0, 1);
            GivenArrayIs(3, 2, 4);
            GivenTargetIs(6);
            ShouldBe(1, 2);
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                var firstIndex = i;
                var secondIndex = FindSecondIndex(nums, target - nums[i]);
                if (secondIndex != -1) return new[] { firstIndex, secondIndex };
            }

            throw new NotImplementedException();
        }

        private static int FindSecondIndex(int[] nums, int addon)
        {
            if (nums.Count(x => x == addon) == 0)
                return -1;

            if (nums.Count(x => x == addon) == 1)
                return nums.ToList().IndexOf(addon);

            var duplicates = nums
                .Select((t,i) => new { Index = i,No = t })
                .Where(x=>x.No==addon);
            return duplicates.ElementAt(1).Index;
        }
    }
}