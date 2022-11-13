using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MinimumAbsoluteDifference;

public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var result = new List<IList<int>>();
        var list = arr.ToList();
        var min = int.MaxValue;
        list.Sort();
        for (var i = 0; i < list.Count - 1; i++)
        {
            if (min > list[i + 1] - list[i])
            {
                result = new List<IList<int>>();
                min = list[i + 1] - list[i];
            }

            result.Add(new List<int> { list[i], list[i + 1] });
        }

        return result;

        if (arr.Length > 0)
        {
            result = new List<IList<int>> { list };
        }

        return result;
    }
}