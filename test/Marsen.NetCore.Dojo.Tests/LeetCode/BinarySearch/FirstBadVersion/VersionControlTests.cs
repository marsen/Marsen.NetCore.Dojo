using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.FirstBadVersion;

public class VersionControlTests
{
    private readonly MockVersionControl _target = new();

    public VersionControlTests()
    {
        _target.SetBadVersion(4);
    }

    [Theory]
    [InlineData(3,false)]
    public void Bad_Version_is_4_And_input_3(int version,bool isBad)
    {
        _target.IsBadVersion(version).Should().Be(isBad);
    }

    [Fact]
    public void Bad_Version_is_4_And_input_5()
    {
        _target.IsBadVersion(5).Should().BeTrue();
    }

    [Fact]
    public void Bad_Version_is_4_And_input_4()
    {
        _target.IsBadVersion(4).Should().BeTrue();
    }
}