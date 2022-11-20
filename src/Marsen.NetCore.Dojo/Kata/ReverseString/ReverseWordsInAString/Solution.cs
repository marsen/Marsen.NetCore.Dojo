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
        var l = s.Split(' ');
        var r = "";
        foreach (var s1 in l)
        {
            r += _reversal.Do(s1)+" ";
        }

        return r.Trim();
    }
}