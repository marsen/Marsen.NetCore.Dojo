using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var nonZeroIdx = 0;
        var zeroIdx = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroIdx++;
            }

            if (nums[i] != 0)
            {
                nums[nonZeroIdx] = nums[i];
                nonZeroIdx++;
            }
        }

        for (int i = 0; i < zeroIdx; i++)
        {
            nums[i + nonZeroIdx] = 0;
        }
    }
}