using System;

namespace Marsen.NetCore.Dojo.LeetCode.LongestConsecutiveSequence;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var result = 1;
        var current = result;
        Array.Sort(nums);
        for (var i = 0; i < nums.Length - 1; i++)
        {
            switch (nums[i + 1] - nums[i])
            {
                case 0:
                    continue;
                case 1:
                    current++;
                    if (current > result) result = current;
                    break;
                default:
                    current = 1;
                    break;
            }
        }

        return result;
    }
}