using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.LeetCode.LongestConsecutiveSequence;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            if (!hashSet.Contains(num))
                hashSet.Add(num);
        }

        var max = 0;
        foreach (var num in hashSet)
        {
            if (!hashSet.Contains(num + 1))
            {
                var length = 0;
                var number = num;
                while (hashSet.Contains(number))
                {
                    length++;
                    number--;
                }

                max = Math.Max(max, length);
            }
        }

        return max;
        var result = nums.Length == 0 ? 0 : 1;
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