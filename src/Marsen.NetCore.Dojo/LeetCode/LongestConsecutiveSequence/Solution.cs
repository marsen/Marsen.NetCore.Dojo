using System;

namespace Marsen.NetCore.Dojo.LeetCode.LongestConsecutiveSequence;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        var result = 1;
        Array.Sort(nums);
        var current = result;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i + 1] - nums[i] == 1)
            {
                current++;
            }
            else
            {
                current = 1;
            }

            if (current > result)
            {
                result = current;
            }
        }

        return result;
    }
}