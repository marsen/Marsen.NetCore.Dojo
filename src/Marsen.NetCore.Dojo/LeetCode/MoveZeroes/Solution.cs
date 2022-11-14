using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public int[] MoveZeroes(int[] nums)
    {
        var zeroCount = 0;
        var result = new int[nums.Length];
        int j = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                result[nums.Length - 1] = 0;
            }
            else
            {
                result[0] = 1;
            }
        }

        return result;

        if (zeroCount > 0)
        {
            return nums.Reverse().ToArray();
        }

        return nums;
    }
}