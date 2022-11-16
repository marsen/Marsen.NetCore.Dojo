using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.MoveZeroes;

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int nonZeroIdx = 0, zeroIdx = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                zeroIdx++;
            else
            {
                nums[nonZeroIdx] = nums[i];
                nonZeroIdx++;
            }
        }

        //fill 0
        for (var i = 0; i < zeroIdx; i++)
        {
            nums[i + nonZeroIdx] = 0;
        }
    }
}