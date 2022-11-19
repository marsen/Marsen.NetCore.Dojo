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
            //for (int i = k + 1; i < numbers.Length; i++)
            {
                //if (numbers[k] + numbers[i] == target)
                if (n > -1)
                {
                    return new[] {k + 1, n + 1};
                }
            }
        }

        return result;
    }
}