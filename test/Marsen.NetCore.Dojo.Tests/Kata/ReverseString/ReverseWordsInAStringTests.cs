using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ReverseString;

public class ReverseWordsInAStringTests
{
    [Fact]
    public void Given_HI_Get_IH()
    {
        var sol = new Solution();
        var actual = sol.ReverseWords("HI");
        actual.Should().Equals("IH");
    }
}

public class Solution
{
    public string ReverseWords(string s)
    {
        throw new NotImplementedException();
    }
}