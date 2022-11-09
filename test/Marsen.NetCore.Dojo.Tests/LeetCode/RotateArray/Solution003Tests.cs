using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.RotateArray;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.RotateArray;

public class Solution003Tests
{
    private readonly Solution003 _sol = new();

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

    [Fact]
    public void Rotate_1_2_3_with_1()
    {
        var nums = new[] { 1, 2, 3 };
        _sol.Rotate(nums, 1);
        nums.Should().Equal(3, 1, 2);
    }

    [Fact]
    public void Rotate_1_2_3_4_5_6_7_with_3()
    {
        var nums = new[] { 1, 2, 3, 4, 5, 6, 7 };
        _sol.Rotate(nums, 3);
        nums.Should().Equal(5, 6, 7, 1, 2, 3, 4);
    }

    [Fact]
    public void Rotate_minus_1_with_2()
    {
        var nums = new[] { -1 };
        _sol.Rotate(nums, 2);
        nums.Should().Equal(-1);
    }

    [Fact]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public void Rotate_Empty_with_0()
    {
        int[] nums = null;
        _sol.Rotate(nums, 0);
        nums.Should().Equal(null);
    }
}