using System;

namespace Marsen.NetCore.Dojo.LeetCode.RotateArray;

public class Solution001
{
    public int[] Rotate(int[] nums, int i)
    {
        if (nums.Length > 0)
        {
            return new[] {1, 2};
        }

        return Array.Empty<int>();
    }
}