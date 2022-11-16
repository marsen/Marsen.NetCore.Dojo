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
        _sol.MinimumAbsDifference(new[] {1, 2})
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() {1, 2}
            }, o => o.WithStrictOrdering());
    }

    [Fact]
    public void Array_2_1_Return_1_2()
    {
        _sol.MinimumAbsDifference(new[] {2, 1})
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() {1, 2}
            }, o => o.WithStrictOrdering());
    }

    [Fact]
    public void Array_3_2_1_Return_1_2_v_2_3()
    {
        _sol.MinimumAbsDifference(new[] {3, 2, 1})
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() {1, 2},
                new() {2, 3}
            }, o => o.WithStrictOrdering());
    }

    [Fact]
    public void Array_9_8_7_1_Return_7_8_v_8_9()
    {
        _sol.MinimumAbsDifference(new[] {9, 8, 7, 1})
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() {7, 8},
                new() {8, 9}
            }, o => o.WithStrictOrdering());
    }

    [Fact]
    public void Array_1_1_3_5_Return_1_1()
    {
        _sol.MinimumAbsDifference(new[] {1, 1, 3, 5})
            .Should().BeEquivalentTo(new List<List<int>>
            {
                new() {1, 1},
            }, o => o.WithStrictOrdering());
    }
}