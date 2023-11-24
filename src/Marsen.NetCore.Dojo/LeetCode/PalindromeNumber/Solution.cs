namespace Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;

public class Solution
{
    public bool IsPalindrome(int i)
    {
        if (i < 0)
        {
            return false;
        }

        if (i > 99)
        {
            return true;
        }

        if (i / 10 == 0) // 0~9
        {
            return true;
        }

        return (i / 10 == i % 10); // 10~99
    }
}