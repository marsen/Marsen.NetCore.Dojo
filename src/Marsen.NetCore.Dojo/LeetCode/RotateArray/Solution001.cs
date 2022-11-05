using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public void Rotate(int[] nums, int k)
    {
        var rotateTimes = nums.Length == 0 ? k : k % nums.Length;
        var r = new int[nums.Length];
        for (var i = 0; i < rotateTimes; i++)
        {
            r[i] = rotateTimes == 0 ? nums[i] : nums[nums.Length - rotateTimes + i];
        }

        for (var i = nums.Length - 1; i >= rotateTimes; i--)
        {
            r[i] = nums[i - rotateTimes];
        }

        Array.Copy(r, nums, nums.Length);
    }
}