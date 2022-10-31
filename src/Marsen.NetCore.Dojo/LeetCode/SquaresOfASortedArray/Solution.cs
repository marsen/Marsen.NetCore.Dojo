using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.SquaresOfASortedArray;

public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        return nums.Select(n => n * n).OrderBy(x => x).ToArray();
    }
}