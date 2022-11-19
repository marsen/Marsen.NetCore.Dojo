namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        int index1 = 1, index2 = 2;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            if (numbers[index1 - 1] + numbers[index2 - 1 + i] == target)
            {
                result = new[] { index1, index2 + i };
            }
        }

        return result;
    }
}