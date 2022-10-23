using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.FirstBadVersion;

public class FirstBadVersionTests
{
    [Fact]
    public void The_1_Version_is_Bad_Version()
    {
        var sol = new Solution();
        sol.FirstBadVersion(1).Should().Be(1);
    }
}