using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.SquaresOfASortedArray;

public class SquaresOfASortedArrayTests
{
    [Fact]
    public void GetArrayEmptyWhenInputArrayEmpty()
    {
        var sol = new Solution();
        int[] result = sol.SortedSquares(Array.Empty<int>());
        result.Should().BeEquivalentTo(Array.Empty<int>());
    }
}

public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        return Array.Empty<int>();
    }
}