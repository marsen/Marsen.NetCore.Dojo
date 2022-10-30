using FluentAssertions;
using Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.FirstBadVersion;

public class FirstBadVersionTests
{
    readonly Solution _sol = Substitute.For<Solution>();

    [Theory]
    [InlineData(1, 1)]
    //[InlineData(2, 1)]
    //[InlineData(3, 1)]
    public void The_1_Version_is_Bad_Version(int input, int output)
    {
        _sol.IsBadVersion(Arg.Is<int>(x => x >= 1)).Returns(true);
        _sol.FirstBadVersion(input).Should().Be(output);
    }
}