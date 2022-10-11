using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        return nums.ToList().IndexOf(target);
    }
}