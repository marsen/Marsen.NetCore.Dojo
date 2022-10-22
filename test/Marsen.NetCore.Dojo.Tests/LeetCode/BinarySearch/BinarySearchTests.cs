using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch;

public class BinarySearchTests
{
    private readonly Solution _sol = new();

    [Fact]
    public void You_Got_Minus_1_with_Empty_Array()
    {
        _sol.Search(Array.Empty<int>(), 1).Should().Be(-1);
    }

}