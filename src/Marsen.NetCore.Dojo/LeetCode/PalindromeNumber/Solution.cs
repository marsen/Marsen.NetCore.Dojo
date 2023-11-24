namespace Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;

public class Solution
{
    public bool IsPalindrome(int i)
    {
        if (i / 10 > 0)
        {
            return false;
        }

        if (i > 0)
        {
            return true;
        }

        return false;
    }
}