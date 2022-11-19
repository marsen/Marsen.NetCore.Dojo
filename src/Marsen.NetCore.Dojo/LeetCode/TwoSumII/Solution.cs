namespace Marsen.NetCore.Dojo.LeetCode.TwoSumII;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var result = new int[2];
        int index1 = 1, index2 = 2;
        if (numbers[index1 - 1] + numbers[index2 - 1] == target)
        {
            result = new[] { index1, index2 };
        }

        return result;
    }
}