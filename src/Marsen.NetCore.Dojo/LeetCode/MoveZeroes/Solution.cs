using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public int[] MoveZeroes(int[] nums)
    {
        var zeroCount = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount++;
            }
        }

        if (zeroCount > 0)
        {
            return nums.Reverse().ToArray();
        }

        return nums;
    }
}