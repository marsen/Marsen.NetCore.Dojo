using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.FirstBadVersion;

public class FirstBadVersionTests
{
    readonly Solution _sol = Substitute.For<Solution>();

    [Fact]
    public void The_1_Version_is_Bad_Version()
    {
        _sol.IsBadVersion(Arg.Is(1)).Returns(true);
        _sol.IsBadVersion(Arg.Is(2)).Returns(true);
        _sol.FirstBadVersion(1).Should().Be(1);
        _sol.FirstBadVersion(2).Should().Be(1);
    }
}