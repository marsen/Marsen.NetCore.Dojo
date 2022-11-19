namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[1 - 1] + numbers[i + 1] == target)
            {
                result = new[] {1, i + 2};
            }
        }

        return result;
    }
}