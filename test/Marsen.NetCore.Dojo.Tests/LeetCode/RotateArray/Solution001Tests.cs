using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.RotateArray;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.RotateArray;

public class Solution001Tests
{
    readonly Solution001 _sol = new();

    [Fact]
    public void Empty_Array()
    {
        _sol.Rotate(Array.Empty<int>(), 0)
            .Should()
            .Equal(Array.Empty<int>());
    }

    [Fact]
    public void Zero_Rotate()
    {
        _sol.Rotate(new[] {1, 2}, 0)
            .Should()
            .Equal(new[] {1, 2});
    }
}