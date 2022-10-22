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
        _sol.Search(new int[] {5}, 5).Should().Be(0);
    }

    [Fact]
    public void Search_5_in_5_6_Array()
    {
        _sol.Search(new int[] {5, 6}, 5).Should().Be(0);
    }

    [Fact]
    public void Search_5_in_4_5_Array()
    {
        _sol.Search(new int[] {4, 5}, 5).Should().Be(1);
    }
}