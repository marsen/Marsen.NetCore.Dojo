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
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(1);
    }

    [Fact]
    public void Array_1_1_Should_2()
    {
        // Arrange
        var ary = new[] { 1, 1 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(2);
    }

    [Fact]
    public void Array_1_1_3_Should_2()
    {
        // Arrange
        var ary = new[] { 1, 1, 3 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(2);
    }
}