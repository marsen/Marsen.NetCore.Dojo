using System;
using System.Linq;

namespace Marsen.NetCore.Dojo.LeetCode.SquaresOfASortedArray;

public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];
        int left = 0, right = nums.Length - 1, end = nums.Length - 1;
        while (left <= right)
        {
            var sqrtLeft = nums[left] * nums[left];
            var sqrtRight = nums[right] * nums[right];
            if (sqrtLeft >= sqrtRight)
            {
                result[end--] = sqrtLeft;
                left++;
            }
            else
            {
                result[end--] = sqrtRight;
                right--;
            }
        }

        return result;
    }
}