using Marsen.NetCore.Dojo.LeetCode.MoveZeroes;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.MoveZeroes;

public class MoveZeroesTests
{
    [Fact]
    public void When_0_Get_0()
    {
        // Arrange
        var target = new Solution();

        // Act
        var actual = target.MoveZeroes(new[] {0});
        var expected = new[] {0};
        // Assert
        Assert.Equal(expected, actual);
    }
}