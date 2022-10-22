using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch;

public class BinarySearchTests
{
    private readonly Solution _sol = new();

    [Fact]
    public void You_Got_Minus_1_with_Empty_Array()
    {
        _sol.Search(Array.Empty<int>(), 1).Should().Be(-1);
    }

    [Fact]
    public void Search_5_in_5_Array()
    {
        _sol.Search(new[] {5}, 5).Should().Be(0);
    }

    [Fact]
    public void Search_5_in_5_6_Array()
    {
        _sol.Search(new[] {5, 6}, 5).Should().Be(0);
    }

    [Fact]
    public void Search_5_in_4_5_Array()
    {
        _sol.Search(new[] {4, 5}, 5).Should().Be(1);
    }

    [Fact]
    public void Search_5_in_3_4_5_Array()
    {
        _sol.Search(new[] {3, 4, 5}, 5).Should().Be(2);
    }

    [Fact]
    public void Search_5_in_5_6_7_Array()
    {
        _sol.Search(new[] {5, 6, 7}, 5).Should().Be(0);
    }

    [Fact]
    public void Search_9_in_m1_0_3_5_9_12_Array()
    {
        _sol.Search(new[] {-1, 0, 3, 5, 9, 12}, 9).Should().Be(4);
    }
}