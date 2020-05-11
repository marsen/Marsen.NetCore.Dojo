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
            AfterRepeat("A").ShouldBe("A");
        }

        [Fact]
        public void The_b_GetB()
        {
            AfterRepeat("b").ShouldBe("B");
        }

        [Fact]
        public void The_bb_GetB_Bb()
        {
            AfterRepeat("bb").ShouldBe("B-Bb");
        }

        [Fact]
        public void The_ab_GetA_Bb()
        {
            AfterRepeat("ab").ShouldBe("A-Bb");
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