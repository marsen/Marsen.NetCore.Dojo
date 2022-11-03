using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public void Rotate(int[] nums, int rotateNum)
    {
        var r = new int[nums.Length];
        for (var i = 0; i < nums.Length - rotateNum; i++)
        {
            r[i] = rotateNum == 0 ? nums[i] : nums[nums.Length - 1 - i];
        }

        for (var i = nums.Length - 1; i > 0; i--)
        {
            r[i] = nums[i-rotateNum];
        }


        Array.Copy(r, nums, nums.Length);
    }
}