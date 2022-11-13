using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.MinimumAbsoluteDifference;

public class SolutionTest
{
    readonly Solution _sol = new();

    [Fact]
    public void EmptyArrayReturnArray()
    {
        _sol.MinimumAbsDifference(Array.Empty<int>())
            .Should().BeEquivalentTo(new List<List<int>>());
    }
}

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        return new List<IList<int>>();
    }
}