using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.LongestConsecutiveSequence;

public class LongestConsecutiveSequenceTests
{
    [Fact]
    public void METHOD()
    {
        var sol = new Solution();
        var actual = sol.LongestConsecutive(new[] { 1 });
        Assert.Equal(1, actual);
    }
}

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        throw new NotImplementedException();
    }
}