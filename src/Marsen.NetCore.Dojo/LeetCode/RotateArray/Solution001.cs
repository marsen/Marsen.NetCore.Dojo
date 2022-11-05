using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public void Rotate(int[] nums, int k)
    {
        var length = nums.Length;
        var rotateTimes = length == 0 ? k : k % length;
        var r = new int[length];
        for (var i = 0; i < rotateTimes; i++)
        {
            r[i] = rotateTimes == 0 ? nums[i] : nums[length - rotateTimes + i];
        }

        for (var i = length - 1; i >= rotateTimes; i--)
        {
            r[i] = nums[i - rotateTimes];
        }

        Array.Copy(r, nums, length);
    }
}