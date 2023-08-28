using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.PalindromeNumber;

public class PalindromeNumberTests
{
    [Fact]
    public void Give_1_Should_Be_True()
    {
        // Arrange
        var target = new Solution();
        // Act
        bool result = target.IsPalindrome(1);
        // Assert
        Assert.True(result);
    }
}