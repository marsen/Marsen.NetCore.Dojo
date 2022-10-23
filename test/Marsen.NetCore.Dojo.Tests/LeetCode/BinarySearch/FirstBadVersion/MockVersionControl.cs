using Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

namespace Marsen.NetCore.Dojo.Tests.LeetCode.BinarySearch.FirstBadVersion;

public class MockVersionControl : VersionControl
{
    public void SetBadVersion(int n)
    {
        badVersion = n;
    }
}