using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public int[] Rotate(int[] nums, int rotateNum)
    {
        if (nums.Length > 0 & rotateNum == 0)
        {
            return nums;
        }

        return Array.Empty<int>();
    }
}