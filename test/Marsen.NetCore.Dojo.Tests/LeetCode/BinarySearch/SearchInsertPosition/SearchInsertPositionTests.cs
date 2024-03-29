using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.SearchInsertPosition;

public class SearchInsertPositionTests
{
    readonly Solution _sol = new();

    [Fact]
    public void Find_5_In_Empty_Array_Should_be_0()
    {
        _sol.SearchInsert(Array.Empty<int>(), 5).Should().Be(0);
    }

    [Fact]
    public void Find_5_In_1_Array_Should_be_1()
    {
        _sol.SearchInsert(new[] { 1 }, 5).Should().Be(1);
    }

    [Fact]
    public void Find_5_In_7_Array_Should_be_0()
    {
        _sol.SearchInsert(new[] { 7 }, 5).Should().Be(0);
    }

    [Fact]
    public void Find_5_In_3_5_7_Array_Should_be_1()
    {
        _sol.SearchInsert(new[] { 3, 5, 7 }, 5).Should().Be(1);
    }

    [Fact]
    public void Find_7_In_1_3_5_6_Array_Should_be_4()
    {
        _sol.SearchInsert(new[] { 1, 3, 5, 6 }, 7).Should().Be(4);
    }
}