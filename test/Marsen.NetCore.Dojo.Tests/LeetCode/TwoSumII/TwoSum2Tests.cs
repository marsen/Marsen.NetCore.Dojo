using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.TwoSumII;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.TwoSumII;

public class TwoSum2Tests
{
    readonly Solution _sol = new();

    [Fact]
    public void Given_1_2_target_3_return_1_2()
    {
        _sol.TwoSum(new[] { 1, 2 }, 3).Should().Equal(1, 2);
    }
}