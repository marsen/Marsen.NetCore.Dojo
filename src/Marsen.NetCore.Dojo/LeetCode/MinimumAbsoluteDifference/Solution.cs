using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MinimumAbsoluteDifference;

public class Solution
{
    public IEnumerable<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var sortedArray = arr.OrderBy(x => x).ToArray();
        int? minDiff = null;
        var result = new List<IList<int>>();

        for (var i = 0; i < sortedArray.Length - 1; i++)
        {
            var diff = sortedArray[i + 1] - sortedArray[i];
        
            if (minDiff == null || diff < minDiff)
            {
                minDiff = diff;
                result = new List<IList<int>> { new List<int> { sortedArray[i], sortedArray[i + 1] } };
            }
            else if (diff == minDiff)
            {
                result.Add(new List<int> { sortedArray[i], sortedArray[i + 1] });
            }
        }

        return result;
    }
}