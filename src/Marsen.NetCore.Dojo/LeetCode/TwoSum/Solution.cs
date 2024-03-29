using System;
using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Common;

namespace Marsen.NetCore.Dojo.LeetCode.TwoSum;

public class Solution
{
    public static int[] TwoSum(IEnumerable<int> nums, int target)
    {
        var result = new int[2];
        var lookup = new Dictionary<int, int>();
        foreach (var n in nums.Select((num, index) => new {num, index}))
        {
            if (lookup.ContainsKey(target - n.num))
            {
                result[0] = lookup[target - n.num];
                result[1] = n.index;
                return result;
            }

            if (!lookup.ContainsKey(n.num))
            {
                lookup.Add(n.num, n.index);
            }
        }

        throw new TowSumException();
    }
}

public class TowSumException : DojoException
{
}