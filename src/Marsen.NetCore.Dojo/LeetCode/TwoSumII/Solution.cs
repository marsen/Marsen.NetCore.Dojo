using System;

namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        for (int k = 0; k < numbers.Length; k++)
        {
            var n = Array.BinarySearch(numbers, target - numbers[k]);
            if (n > -1)
            {
                var y = n == k ? n + 2 : n + 1;
                return new[] {k + 1, y};
            }
        }

        return result;
    }
}