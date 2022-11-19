namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        for (int k = 0; k < numbers.Length - 1; k++)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[k] + numbers[i + 1] == target)
                {
                    result = new[] {k + 1, i + 2};
                }
            }
        }

        return result;
    }
}