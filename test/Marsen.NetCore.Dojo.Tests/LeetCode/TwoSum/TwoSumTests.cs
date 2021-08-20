using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSum
{
    public class TwoSumTests
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

        private void GivenTargetIs(int target)
        {
            _target = target;
        }

        private void ShouldBe(params int[] args)
        {
            Assert.Equal(args, _solution.TwoSum(_nums, _target));
        }

        private static void GivenArrayIs(params int[] args)
        {
            _nums = args;
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var index = nums.ToList().FindIndex(b => nums[i] + b == target);
                if (index==-1)
                {
                   continue; 
                }
                return new[] { i, index };
            }

            throw new NotImplementedException();
        }
    }
}