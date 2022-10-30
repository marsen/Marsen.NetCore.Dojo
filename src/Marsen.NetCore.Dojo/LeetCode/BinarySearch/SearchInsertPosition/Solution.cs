namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch.SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (right >= left)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return mid;
            if (nums[mid] < target)
            {
                left++;
                return 1;
            }

            if (nums[mid] > target)
            {
                right--;
                return 0;
            }
        }

        return 0;
    }
}