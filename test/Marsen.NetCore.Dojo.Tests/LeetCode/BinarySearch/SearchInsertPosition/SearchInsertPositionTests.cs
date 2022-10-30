using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.SearchInsertPosition;

public class SearchInsertPositionTests
{
    [Fact]
    public void METHOD()
    {
        var sol = new Solution();
        var result = sol.SearchInsert(Array.Empty<int>(), 5);
        Assert.Equal(0, result);
    }
}

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        throw new NotImplementedException();
    }
}