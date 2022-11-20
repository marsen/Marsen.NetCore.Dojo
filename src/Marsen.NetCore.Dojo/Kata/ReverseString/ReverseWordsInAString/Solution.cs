using System.Linq;

namespace Marsen.NetCore.Dojo.Kata.ReverseString.ReverseWordsInAString;

public class Solution
{
    private readonly IStringReversal _reversal;

    public Solution(IStringReversal reversal)
    {
        _reversal = reversal;
    }

    public string ReverseWords(string s)
    {
        return s.Split(' ')
            .Aggregate("", (current, str) => current + _reversal.Do(str) + " ")
            .Trim();
    }
}