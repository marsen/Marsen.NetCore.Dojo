using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public int[] Rotate(int[] nums, int rotateNum)
    {
        var r = new int[nums.Length];
        if (rotateNum > 0)
        {
            r[0] = nums[nums.Length-1];
            r[1] = nums[0];
            return r;
        }


        if (nums.Length > 0 & rotateNum == 0)
        {
            return nums;
        }

        return Array.Empty<int>();
    }
}