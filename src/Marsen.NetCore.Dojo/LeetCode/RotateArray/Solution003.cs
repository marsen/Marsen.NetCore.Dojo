namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

internal class Solution003
{
    public void Rotate(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k == 0)
            return;

        var n = nums.Length;
        var tmp = new int[n];
        for (var i = 0; i < n; i++)
            tmp[(i + k) % n] = nums[i];

        for (var i = 0; i < n; i++)
            nums[i] = tmp[i];
    }
}