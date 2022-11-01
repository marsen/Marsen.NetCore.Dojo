using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.RotateArray;

public class Solution1stTests
{
    [Fact]
    public void MethodName_WithSomething_ShouldDoSomething()
    {
        // Arrange
        var sol = new Solution1st();
        // Act
        int[] r = sol.Rotate(Array.Empty<int>(), 0);

        // Assert
        r.Should().Equal(Array.Empty<int>());
    }
}

public class Solution1st
{
    public int[] Rotate(int[] nums, int i)
    {
        throw new NotImplementedException();
    }
}