namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1, insertIdx = 0;

        while (right >= left)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
            {
                left = mid + 1;
                insertIdx = left;
            }

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
        }

        return insertIdx;
    }
}