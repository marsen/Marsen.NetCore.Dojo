using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.PickingTicket;

public class PickingTicketTests
{
    [Fact]
    public void MethodName_WithWhat_ShouldDoWhat()
    {
        // Arrange
        var target = new Solution();
        var ary = new int[] { 1 };
        // Act
        var result = target.MaxTickets(ary);

        // Assert
        Assert.Equal(result, 1);
    }
}

public class Solution
{
    public int MaxTickets(int[] ary)
    {
        throw new System.NotImplementedException();
    }
}