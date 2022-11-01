using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.RotateArray;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.RotateArray;

public class Solution1stTests
{
    [Fact]
    public void MethodName_WithSomething_ShouldDoSomething()
    {
        // Arrange
        var sol = new Solution001();
        // Act
        int[] r = sol.Rotate(Array.Empty<int>(), 0);

        // Assert
        r.Should().Equal(Array.Empty<int>());
    }
}

