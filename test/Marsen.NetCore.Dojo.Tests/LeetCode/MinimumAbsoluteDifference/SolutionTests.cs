using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.MinimumAbsoluteDifference;

public class SolutionTest
{
    [Fact]
    public void EmptyArrayReturnArray()
    {
        var sol = new Solution();
        IList<IList<int>> actual = sol.MinimumAbsDifference(Array.Empty<int>());
        actual.Should().BeEquivalentTo(new List<List<int>>());
    }
}

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        return new List<IList<int>>();
    }
}