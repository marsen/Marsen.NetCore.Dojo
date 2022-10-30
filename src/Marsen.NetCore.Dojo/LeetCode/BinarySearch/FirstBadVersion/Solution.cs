namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.FirstBadVersion;

/* The isBadVersion API is defined in the parent class VersionControl.*/
public abstract class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int left = 1, right = n;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (IsBadVersion(mid))
                right = mid;
            else
                left = mid + 1;
        }

        return left;
    }
}