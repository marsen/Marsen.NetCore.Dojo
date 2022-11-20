using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ReverseString;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ReverseString;

public class ReverseWordsInAStringTests
{
    [Fact]
    public void Given_HI_Get_IH()
    {
        var r = new Reversal();
        var sol = new Solution(r);
        var actual = sol.ReverseWords("HI");
        actual.Should().Be("IH");
    }
}

public class Solution
{
    private readonly IStringReversal _reversal;

    public Solution(IStringReversal reversal)
    {
        _reversal = reversal;
    }

    public string ReverseWords(string s)
    {
        return _reversal.Do(s);
    }
}