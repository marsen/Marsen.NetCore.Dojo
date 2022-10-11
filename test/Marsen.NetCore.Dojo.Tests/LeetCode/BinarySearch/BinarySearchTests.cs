using Marsen.NetCore.Dojo.LeetCode.BinarySearch;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch;

public class BinarySearchTests
{
    private readonly Solution _sol = new();

    [Fact]
    public void You_Got_Minus_1_with_Empty_Array()
    {
        // Arrange
        int[] array = { };
        int target = 1;

        // Act
        var ans = _sol.Search(array, target);

        // Assert
        Assert.Equal(-1, ans);
    }

    [Fact]
    public void You_Got_0_with_1_Array()
    {
        // Arrange
        int[] array = {1};
        int target = 1;

        // Act
        var ans = _sol.Search(array, target);

        // Assert
        Assert.Equal(0, ans);
    }
    [Fact]
    public void You_Got_1_with_0_1_Array()
    {
        // Arrange
        int[] array = {0,1};
        int target = 1;

        // Act
        var ans = _sol.Search(array, target);

        // Assert
        Assert.Equal(1, ans);
    }
}