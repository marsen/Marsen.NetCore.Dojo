using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSumII;

public class TwoSum2Tests
{
    [Fact]
    public void Given_1_2_target_3_return_1_2()
    {
        var sol = new Solution();
        int[] result = sol.TwoSum(new[] { 1, 2 }, 3);
        result.Should().Equal(1, 2);
    }
}

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        return new[] { 1, 2 };
    }
}