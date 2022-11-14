using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.MoveZeroes;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.MoveZeroes;

public class MoveZeroesTests
{
    private readonly Solution _sol = new();

    [Fact]
    public void When_0_Get_0()
    {
        _sol.MoveZeroes(new[] {0})
            .Should().Equal(new[] {0});
    }

    [Fact]
    public void When_1_0_Get_1_0()
    {
        _sol.MoveZeroes(new[] {1, 0})
            .Should().Equal(new[] {1, 0});
    }

    [Fact]
    public void When_0_1_Get_1_0()
    {
        _sol.MoveZeroes(new[] {0, 1})
            .Should().Equal(new[] {1, 0});
    }

    [Fact]
    public void When_3_1_2_Get_3_1_2()
    {
        _sol.MoveZeroes(new[] {3, 1, 2})
            .Should().Equal(new[] {3, 1, 2});
    }

    [Fact]
    public void When_3_0_2_Get_3_2_0()
    {
        _sol.MoveZeroes(new[] {3, 0, 2})
            .Should().Equal(new[] {3, 2, 0});
    }

    [Fact]
    public void When_0_1_0_3_12_Get_1_3_12_0_0()
    {
        _sol.MoveZeroes(new[] {0, 1, 0, 3, 12})
            .Should().Equal(new[] {1, 3, 12, 0, 0});
    }
}