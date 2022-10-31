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
            if (Sqrt(nums[left]) >= Sqrt(nums[right]))
            {
                result[end--] = Sqrt(nums[left]);
                left++;
            }
            else
            {
                result[end--] = Sqrt(nums[right]);
                right--;
            }
        }

        return result;
    }

    private int Sqrt(int n)
    {
        return n * n;
    }
}