namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        for (int k = 0; k < numbers.Length - 1; k++)
        {
            for (int i = k + 1; i < numbers.Length; i++)
            {
                if (numbers[k] + numbers[i] == target)
                {
                    result = new[] {k + 1, i + 1};
                }
            }
        }

        return result;
    }
}