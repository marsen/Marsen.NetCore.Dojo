using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.ReverseString;
using Marsen.NetCore.Dojo.Kata.ReverseString.ReverseWordsInAString;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.ReverseString.ReverseWordsInAString;

public class ReverseWordsInAStringTests
{
    readonly Solution _sol = new(new Reversal());

    [Fact]
    public void Given_HI_Get_IH()
    {
        _sol.ReverseWords("HI").Should().Be("IH");
    }

    [Fact]
    public void Given_HI_Jo_Get_IH_oJ()
    {
        _sol.ReverseWords("HI Jo").Should().Be("IH oJ");
    }
}