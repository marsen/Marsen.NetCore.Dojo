using System;
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
        public void The_A_Should_Be_A()
        {
            AfterRepeat("A").ShouldBe("A");
        }

        [Fact]
        public void The_b_Should_Be_B()
        {
            AfterRepeat("b").ShouldBe("B");
        }

        [Fact]
        public void The_bb_Should_Be_B_Bb()
        {
            AfterRepeat("bb").ShouldBe("B-Bb");
        }

        [Fact]
        public void The_ab_Should_Be_A_Bb()
        {
            AfterRepeat("ab").ShouldBe("A-Bb");
        }

        [Fact]
        public void The_abc_Should_Be_A_Bb_Ccc()
        {
            AfterRepeat("abc").ShouldBe("A-Bb-Ccc");
        }

        [Fact]
        public void The_a1_Should_Be_A_11()
        {
            AfterRepeat("a1").ShouldBe("A-11");
        }

        [Fact(Skip = "空字串應拋錯誤")]
        public void The_string_Empty_Should_Be_Empty()
        {
            AfterRepeat(string.Empty).ShouldBe("");
        }

        [Fact]
        public void The_string_Empty_Should_Throw_Exception()
        {
            Assert.Throws<Exception>(()=>AfterRepeat(string.Empty));
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