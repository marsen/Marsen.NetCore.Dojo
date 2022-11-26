using FluentAssertions;
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
}

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            result++;
        }

        return result;
    }
}