namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length;
        while (right > left)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
                return 1;
        }

        return 0;
    }
}