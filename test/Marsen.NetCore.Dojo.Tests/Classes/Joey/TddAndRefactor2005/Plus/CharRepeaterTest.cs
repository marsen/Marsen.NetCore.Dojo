using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.Plus;
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

        [Fact]
        public void The_string_Empty_Should_Throw_Exception_2()
        {
            Action act = () => this._charRepeater.Repeat(string.Empty);
            act.Should().Throw<Exception>();
        }

        [Fact]
        public void The_null_Should_Throw_Exception()
        {
            Assert.Throws<Exception>(() => AfterRepeat(null));
        }

        [Theory]
        [InlineData("ZpglnRxqenU", "Z-Pp-Ggg-Llll-Nnnnn-Rrrrrr-Xxxxxxx-Qqqqqqqq-Eeeeeeeee-Nnnnnnnnnn-Uuuuuuuuuuu")]
        [InlineData("NyffsGeyylB", "N-Yy-Fff-Ffff-Sssss-Gggggg-Eeeeeee-Yyyyyyyy-Yyyyyyyyy-Llllllllll-Bbbbbbbbbbb")]
        [InlineData("MjtkuBovqrU", "M-Jj-Ttt-Kkkk-Uuuuu-Bbbbbb-Ooooooo-Vvvvvvvv-Qqqqqqqqq-Rrrrrrrrrr-Uuuuuuuuuuu")]
        [InlineData("EvidjUnokmM", "E-Vv-Iii-Dddd-Jjjjj-Uuuuuu-Nnnnnnn-Oooooooo-Kkkkkkkkk-Mmmmmmmmmm-Mmmmmmmmmmm")]
        [InlineData("HbideVbxncC", "H-Bb-Iii-Dddd-Eeeee-Vvvvvv-Bbbbbbb-Xxxxxxxx-Nnnnnnnnn-Cccccccccc-Ccccccccccc")]
        public void Batch_Unit_Test_From_Code_War(string input, string expected)
        {
            AfterRepeat(input).ShouldBe(expected);
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