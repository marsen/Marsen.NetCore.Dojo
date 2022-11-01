using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public int[] Rotate(int[] nums, int rotateNum)
    {
        var r = new int[nums.Length];
        if (rotateNum == 0)
        {
            for (int i = 0; i < nums.Length - rotateNum; i++)
            {
                r[i] = rotateNum == 0 ? nums[i] : nums[nums.Length - 1 - i];
                r[rotateNum + i] = nums[i];
            }

            return r;
        }

        for (int i = 0; i < nums.Length - rotateNum; i++)
        {
            r[i] = rotateNum == 0 ? nums[i] : nums[nums.Length - 1 - i];
            r[rotateNum + i] = nums[i];
        }


        return r;
    }
}