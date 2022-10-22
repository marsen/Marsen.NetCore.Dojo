namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (right >= left)
        {
            int mid = (right - left) / 2 + left;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] < target)
            {
                left = mid + 1;
            }

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}