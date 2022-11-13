using System;
using System.Collections.Generic;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.MinimumAbsoluteDifference;
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
            }, o => o.WithStrictOrdering());
    }

    [Fact]
    public void Array_2_1_Return_1_2()
    {
        _sol.MinimumAbsDifference(new[] { 2, 1 })
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() { 1, 2 }
            }, o => o.WithStrictOrdering());
    }
}