using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if (nums.Contains(target))
        {
            return 0;
        }

        return -1;
    }
}