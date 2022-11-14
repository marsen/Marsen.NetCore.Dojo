using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public int[] MoveZeroes(int[] nums)
    {
        var result = new int[nums.Length];
        int j = nums.Length - 1;
        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                result[j] = 0;
            }
            else
            {
                result[k] = nums[i];
            }
        }

        return result;
    }
}