using System;

namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        for (var i = 0; i < numbers.Length; i++)
        {
            var j = Array.BinarySearch(numbers, target - numbers[i]);
            if (j > -1)
            {
                return new[] {i + 1, j != i ? j + 1 : j + 2};
            }
        }

        return result;
    }
}