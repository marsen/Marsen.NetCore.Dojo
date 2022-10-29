namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
public abstract class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        return IsBadVersion(n) ? 1 : 0;
    }
}