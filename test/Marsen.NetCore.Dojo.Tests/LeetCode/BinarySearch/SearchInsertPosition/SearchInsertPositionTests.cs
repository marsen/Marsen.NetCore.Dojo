using System;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.SearchInsertPosition;

public class SearchInsertPositionTests
{
    [Fact]
    public void Find_5_In_Empty_Array()
    {
        var sol = new Solution();
        var result = sol.SearchInsert(Array.Empty<int>(), 5);
        Assert.Equal(0, result);
    }
}

