namespace Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;

public class Solution
{
    public bool IsPalindrome(int i)
    {
        if (i > 0 && i / 10 == 0)
        {
            return true;
        }

        return (i / 10 == i % 10);
    }
}