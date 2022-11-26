using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.LongestConsecutiveSequence;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        var hashSet = nums.ToHashSet();
        var result = 0;
        foreach (var num in hashSet)
        {
            if (hashSet.Contains(num + 1)) continue;
            var length = 0;
            var number = num;
            while (hashSet.Contains(number))
            {
                length++;
                number--;
            }

            result = Math.Max(result, length);
        }

        return result;
    }
}