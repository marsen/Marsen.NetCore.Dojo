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
        var result = _sol.SortedSquares(Array.Empty<int>());
        result.Should().BeEquivalentTo(Array.Empty<int>());
    }

    [Fact]
    public void Get_4_WhenInput_2_Array()
    {
        var result = _sol.SortedSquares(new[] { 2 });
        result.Should().BeEquivalentTo(new[] { 4 });
    }
}