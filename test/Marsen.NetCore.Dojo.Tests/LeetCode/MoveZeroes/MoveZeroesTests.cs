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
}