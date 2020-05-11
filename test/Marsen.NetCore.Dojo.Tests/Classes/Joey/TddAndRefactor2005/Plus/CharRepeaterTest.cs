using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeaterTest
    {
        private readonly CharRepeater _charRepeater;

        public CharRepeaterTest()
        {
            _charRepeater = new CharRepeater();
        }

        [Fact]
        public void The_A_GetA()
        {
            var input = "A";
            AfterRepeat(input).ShouldBe("A");
        }

        private string AfterRepeat(string input)
        {
            return this._charRepeater.Repeat(input);
        }
    }

    public static class CharRepeaterTestExt
    {
        public static void ShouldBe(this string actual, string expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}