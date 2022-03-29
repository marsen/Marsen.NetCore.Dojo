using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.TwoSum;
using NSubstitute.ExceptionExtensions;
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
        public void Array_1_3_Target_2_Should_Throw_Exception()
        {
            Action act = () => Solution.TwoSum(new []{1,3}, 2);
            act.Should().Throw<TowSumException>();
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

        [Fact]
        public void Array_1_3_3_Target_4_Should_0_1()
        {
            GivenArrayIs(1, 3, 3);
            GivenTargetIs(4);
            ShouldBe(0, 1);
        }

        [Fact]
        public void Array_3_2_4_Target_6_Should_1_2()
        {
            GivenArrayIs(3, 2, 4);
            GivenTargetIs(6);
            ShouldBe(1, 2);
        }

        [Fact]
        public void Array_2_7_11_15_Target_9_Should_0_1()
        {
            GivenArrayIs(2, 7, 11, 15);
            GivenTargetIs(9);
            ShouldBe(0, 1);
        }

        [Fact]
        public void Array_0_0_1_3_Target_4_Should_2_3()
        {
            GivenArrayIs(0, 0, 1, 3);
            GivenTargetIs(4);
            ShouldBe(2, 3);
        }

        [Fact]
        public void Array_0_0_4_1_3_Target_4_Should_0_2()
        {
            GivenArrayIs(0, 0, 4, 1, 3);
            GivenTargetIs(4);
            ShouldBe(0, 2);
        }
    }
}