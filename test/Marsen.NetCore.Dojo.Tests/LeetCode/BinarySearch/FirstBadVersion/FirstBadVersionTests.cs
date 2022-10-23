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

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
public class VersionControlTests
{
    [Fact]
    public void Bad_Version_is_4_And_input_3()
    {
        var target = new VersionControl();
        target.IsBadVersion(3).Should().BeFalse();
    }
}