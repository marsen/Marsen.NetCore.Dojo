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
        _sol.Search(new int[] { }, 1).Should().Be(-1);
    }

    [Fact]
    public void You_Got_0_When_Looking_4_in_Array_4()
    {
        _sol.Search(new int[] {4}, 4).Should().Be(0);
    }
}