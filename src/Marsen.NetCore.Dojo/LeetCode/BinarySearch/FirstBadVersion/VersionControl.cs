using System;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

public class VersionControl
{
    protected int badVersion;

    public bool IsBadVersion(int n)
    {
        return n >= badVersion;
    }
}