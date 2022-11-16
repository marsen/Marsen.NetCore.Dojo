using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MinimumAbsoluteDifference;

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var result = new List<IList<int>>();
        var list = arr.ToList();
        list.Sort();
        var min = Int32.MaxValue;
        for (var i = 0; i < list.Count - 1; i++)
        {
            var diff = list[i + 1] - list[i];
            if (diff < min)
            {
                min = diff;
                result = new List<IList<int>>();
                result.Add(new List<int> {list[i], list[i + 1]});
            }
            else if (diff == min)
                result.Add(new List<int> {list[i], list[i + 1]});
        }

        return result;
    }
}