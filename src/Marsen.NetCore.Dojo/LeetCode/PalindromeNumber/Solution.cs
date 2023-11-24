namespace Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;

public class Solution
{
    public bool IsPalindrome(int origin)
    {
        if (origin < 0)
        {
            return false;
        }

        var reversed = 0;
        for (var temp = origin; temp != 0; temp /= 10)
        {
            reversed = reversed * 10 + temp % 10;
        }

        return origin == reversed;
    }
}