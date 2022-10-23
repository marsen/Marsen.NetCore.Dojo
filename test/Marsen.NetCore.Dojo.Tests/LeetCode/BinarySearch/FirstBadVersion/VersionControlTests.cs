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
    [InlineData(3, false)]
    [InlineData(4, true)]
    [InlineData(5, true)]
    public void IsBadVersion(int version, bool isBad)
    {
        _target.IsBadVersion(version).Should().Be(isBad);
    }
}