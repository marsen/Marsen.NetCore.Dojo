using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.RotateArray;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.RotateArray;

public class Solution001Tests
{
    readonly Solution001 _sol = new();

    [Fact]
    public void Empty_Array()
    {
        var nums = Array.Empty<int>();
        _sol.Rotate(nums, 0);
        nums.Should().Equal(Array.Empty<int>());
    }

    [Fact]
    public void Zero_Rotate()
    {
        var nums = new[] { 1, 2 };
        _sol.Rotate(nums, 0);
        nums.Should().Equal(1, 2);
    }

    [Fact]
    public void Rotate_1_2_with_1()
    {
        var nums = new[] { 1, 2 };
        _sol.Rotate(nums, 1);
        nums.Should().Equal(2, 1);
    }
}