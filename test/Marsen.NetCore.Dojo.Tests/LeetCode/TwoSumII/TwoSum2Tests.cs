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
        _sol.TwoSum(new[] {1, 2}, 3).Should().Equal(1, 2);
    }

    [Fact]
    public void Given_0_1_3_target_3_return_1_3()
    {
        _sol.TwoSum(new[] {0, 1, 3}, 3).Should().Equal(1, 3);
    }

    [Fact]
    public void Given_0_1_3_4_target_7_return_3_4()
    {
        _sol.TwoSum(new[] {0, 1, 3, 4}, 7).Should().Equal(3, 4);
    }

    [Fact]
    public void Given_minus_1_0_target_minus_1_return_1_2()
    {
        _sol.TwoSum(new[] {-1, 0}, -1).Should().Equal(1, 2);
    }

    [Fact]
    public void Given_2_3_4_target_6_return_1_3()
    {
        _sol.TwoSum(new[] {2, 3, 4}, 6).Should().Equal(1, 3);
    }

    [Fact]
    public void Given_2_3_4_4_target_8_return_3_4()
    {
        _sol.TwoSum(new[] {2, 3, 4, 4}, 8).Should().Equal(3, 4);
    }
}