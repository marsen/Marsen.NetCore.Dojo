namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

internal class Solution003
{
    public void Rotate(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k == 0)
            return;

        int n = nums.Length;
        int[] tmp = new int[n];
        for (int i = 0; i < n; i++)
            tmp[(i + k) % n] = nums[i];

        for (int i = 0; i < n; i++)
            nums[i] = tmp[i];
    }
}