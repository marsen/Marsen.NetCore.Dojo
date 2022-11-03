using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public void Rotate(int[] nums, int rotateNum)
    {
        var r = new int[nums.Length];
        for (int i = 0; i < nums.Length - rotateNum; i++)
        {
            r[i] = rotateNum == 0 ? nums[i] : nums[nums.Length - 1 - i];
            r[rotateNum + i] = nums[i];
        }

        Array.Copy(r, nums, nums.Length);
    }
}