using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var result = new int[nums.Length];
        int j = nums.Length - 1;
        int k = 0;
        foreach (var t in nums)
        {
            if (t == 0)
            {
                result[j] = 0;
            }
            else
            {
                result[k] = t;
                k++;
            }
        }

        for (var i = 0; i < result.Length; i++)
        {
            nums[i] = result[i];
        }
    }
}