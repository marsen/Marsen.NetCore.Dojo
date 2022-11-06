using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.SquaresOfASortedArray;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.SquaresOfASortedArray;

public class SquaresOfASortedArrayTests
{
    readonly Solution _sol = new();

    [Fact]
    public void GetArrayEmptyWhenInputArrayEmpty()
    {
        _sol.SortedSquares(Array.Empty<int>())
            .Should()
            .Equal(Array.Empty<int>());
    }

    [Fact]
    public void Get_4_WhenInput_2_Array()
    {
        _sol.SortedSquares(new[] { 2 })
            .Should()
            .Equal(new[] { 4 });
    }

    [Fact]
    public void Get_4_9_WhenInput_m3_2_Array()
    {
        _sol.SortedSquares(new[] { -3, 2 })
            .Should()
            .Equal(new[] { 4, 9 });
    }

    [Fact]
    public void Get_4_9_WhenInput_m2_3_Array()
    {
        _sol.SortedSquares(new[] { -2, 3 })
            .Should()
            .Equal(new[] { 4, 9 });
    }
}
