using System;
using System.Collections.Generic;
using System.Linq;
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

    [Fact]
    public void Array_1_2_Return_1_2()
    {
        _sol.MinimumAbsDifference(new[] { 1, 2 })
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() { 1, 2 }
            });
    }
}

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var result = new List<IList<int>>();
        if (arr.Length > 0)
        {
            return new List<IList<int>> { arr.ToList() };
        }

        return result;
    }
}