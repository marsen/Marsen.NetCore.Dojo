using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.PickingTicket;
using NSubstitute.ExceptionExtensions;
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

    [Fact]
    public void Array_0_1_3_Should_2()
    {
        // Arrange
        var ary = new[] { 0, 1, 3 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(2);
    }

    [Fact]
    public void Sort_Array_3_0_1_Should_2()
    {
        // Arrange
        var ary = new[] { 3, 0, 1 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(2);
    }

    [Fact]
    public void Two_Subsequence_Array_0_1_3_4_Should_2()
    {
        // Arrange
        var ary = new[] { 0, 1, 3, 4 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(2);
    }

    [Fact(Skip = "Just One More Test")]
    public void Array_0_1_2_4_4_Should_3()
    {
        // Arrange
        var ary = new[] { 0, 1, 2, 4, 4 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(3);
    }

    [Fact(DisplayName = "PM Sample")]
    public void Array_8_5_4_8_4_Should_3()
    {
        // Arrange
        var ary = new[] { 8, 5, 4, 8, 4 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(3);
    }

    [Fact]
    public void Array_1_2_5_6_7_Should_1()
    {
        // Arrange
        var ary = new[] { 1, 2, 5, 6, 7 };
        // Act、Assert
        _target.MaxTickets(ary).Should().Be(3);
    }
    
    [Fact]
    public void Array_Empty_Should_Throw_Exception()
    {
        // Arrange
        var ary = Array.Empty<int>();
        // Act、Assert
        _target.MaxTickets(ary).Should().Throws(new PickingTicketException());
    }
}

