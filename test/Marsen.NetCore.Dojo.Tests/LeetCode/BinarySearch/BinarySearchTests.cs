using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch;

public class BinarySearchTests
{
    [Fact]
    public void You_Got_Minus_1_with_Empty_Array()
    {
        // Arrange
        int[] array = new int[] { };
        int target = 1;

        var sol = new Solution();
        // Act
        var ans = sol.Search(array, target);
        
        // Assert
        Assert.Equal(-1,ans);
    }
}