using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public int[] Rotate(int[] nums, int rotateNum)
    {
        if (rotateNum == 0)
        {
            return nums;
        }

        var r = new int[nums.Length];
        for (int i = 0; i < rotateNum; i++)
        {
            r[i] = nums[nums.Length - 1 - i];
            r[rotateNum + i] = nums[i];
        }

        return r;
    }
}