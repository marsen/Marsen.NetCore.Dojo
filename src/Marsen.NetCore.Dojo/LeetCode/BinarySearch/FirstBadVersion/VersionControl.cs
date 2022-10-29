using System;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

public interface IVersionControl
{
    bool IsBadVersion(int n);
}

public class VersionControl : IVersionControl
{
    protected int BadVersion;
    public virtual bool IsBadVersion(int n)
    {
        return n >= BadVersion;
    }
}