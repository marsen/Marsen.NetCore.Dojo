using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.SearchInsertPosition;

public class SearchInsertPositionTests
{
    readonly Solution _sol = new();

    [Fact]
    public void Find_5_In_Empty_Array_Should_be_0()
    {
        _sol.SearchInsert(Array.Empty<int>(), 5).Should().Be(0);
    }
}