using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.BinarySearch;

public class Solution
{
    public int Search(int[] array, int target)
    {
        if (array.Contains(target))
        {
            return 0;
        }

        return -1;
    }
}