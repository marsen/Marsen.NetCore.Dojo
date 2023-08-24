using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.PickingTicket;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.PickingTicket;

public class PickingTicketTests
{
    private readonly Solution _target = new();

    [Fact]
    public void Should_Return_An_Integer_Array_1_Return_1()
    {
        // Arrange
        var ary = new[] { 1 };
        // Act
        var result = _target.MaxTickets(ary);
        // Assert
        result.Should().Be(1);
    }
}