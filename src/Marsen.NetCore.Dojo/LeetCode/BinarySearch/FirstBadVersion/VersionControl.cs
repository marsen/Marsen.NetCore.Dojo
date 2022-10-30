namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

public class VersionControl
{
    protected int BadVersion;

    public virtual bool IsBadVersion(int n)
    {
        return n >= BadVersion;
    }
}