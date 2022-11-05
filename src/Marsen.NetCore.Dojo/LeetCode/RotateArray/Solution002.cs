namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

internal class Solution002
{
    public void Rotate(int[] nums, int k)
    {
        if (nums == null || nums.Length < 2)
            return;

        k %= nums.Length;
        Reverse(nums, 0, nums.Length - 1);
        Reverse(nums, 0, k - 1);
        Reverse(nums, k, nums.Length - 1);
    }

    private static void Reverse(int[] nums, int left, int right)
    {
        //two points
        while (left < right)
        {
            //swap 
            (nums[left], nums[right]) = (nums[right], nums[left]);
            left++;
            right--;
        }
    }
}