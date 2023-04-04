using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.LongestConsecutiveSequence;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.LongestConsecutiveSequence;

public class LongestConsecutiveSequenceTests
{
    private readonly Solution _sol = new();

    [Fact]
    public void Given_1_Should_Get_1()
    {
        _sol.LongestConsecutive(new[] { 1 })
            .Should().Be(1);
    }

    [Fact]
    public void Given_1_2_Should_Get_2()
    {
        _sol.LongestConsecutive(new[] { 1, 2 })
            .Should().Be(2);
    }

    [Fact]
    public void Given_1_2_4_Should_Get_2()
    {
        _sol.LongestConsecutive(new[] { 1, 2, 4 })
            .Should().Be(2);
    }

    [Fact]
    public void Given_1_2_4_5_6_Should_Get_3()
    {
        _sol.LongestConsecutive(new[] { 1, 2, 4, 5, 6 })
            .Should().Be(3);
    }

    [Fact]
    public void Given_4_2_1_6_5_Should_Get_3()
    {
        _sol.LongestConsecutive(new[] { 4, 2, 1, 6, 5 })
            .Should().Be(3);
    }

    [Fact]
    public void Given_Empty_Should_Get_0()
    {
        _sol.LongestConsecutive(Array.Empty<int>())
            .Should().Be(0);
    }

    [Fact]
    public void Given_1_2_0_1_Should_Get_3()
    {
        _sol.LongestConsecutive(new[] { 1, 2, 0, 1 })
            .Should().Be(3);
    }

    [Fact]
    public void Given_1_2_2_3_4_Should_Get_4()
    {
        _sol.LongestConsecutive(new[] { 1, 2, 2, 3, 4 })
            .Should().Be(4);
    }

    [Fact]
    public void Given_m3_m2_m1_0_1_2_3_Should_Get_7()
    {
        _sol.LongestConsecutive(new[] { -3, -2, -1, 0, 1, 2, 3 })
            .Should().Be(7);
    }

    [Fact]
    public void Given_1_2_4_5_7_Should_Get_2()
    {
        _sol.LongestConsecutive(new[] { 1, 2, 4, 5, 7 })
            .Should().Be(2);
    }

    [Fact]
    public void Given_0_1_1000000000_m1000000000_2_3_Should_Get_4()
    {
        _sol.LongestConsecutive(new[] { 0, 1, 1000000000, -1000000000, 2, 3 })
            .Should().Be(4);
    }
}