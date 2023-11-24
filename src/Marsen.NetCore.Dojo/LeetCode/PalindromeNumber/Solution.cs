namespace Marsen.NetCore.Dojo.LeetCode.PalindromeNumber;

public class Solution
{
    public bool IsPalindrome(int i)
    {
        if (i < 0)
        {
            return false;
        }

        var temp = i;
        var reverse = 0;
        while (temp / 10 != 0)
        {
            reverse = reverse * 10 + temp % 10 * 10;
            temp /= 10;
        }
        reverse += temp;
        return i == reverse;

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