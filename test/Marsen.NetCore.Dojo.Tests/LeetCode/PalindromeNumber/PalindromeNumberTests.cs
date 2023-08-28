using Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.PalindromeNumber;

public class PalindromeNumberTests
{
    readonly Solution _sol = new ();
    [Fact]
    public void Give_1_Should_Be_True()
    {
        // Arrange, Act, Assert
        Assert.True(_sol.IsPalindrome(1));
    }
}