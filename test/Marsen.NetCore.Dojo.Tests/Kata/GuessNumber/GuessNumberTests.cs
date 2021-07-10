using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class GuessNumberTests
    {
        Game game = new Game();

        [Fact]
        public void TestItShouldGet4A0B()
        {
            Assert.Equal("4A0B", game.Guess("1234"));
        }

        [Fact]
        public void TestRandomAnswerLengthShouldBe4()
        {
            var answer = RandomAnswer();
            Assert.Equal(4, answer.Length);
        }

        [Fact]
        public void TestRandomAnswerShouldAllBeNumber()
        {
            string allNumber = "0123456789";
            var answer = RandomAnswer();
            var firstNumber = answer.Substring(0, 1);
            Assert.True(allNumber.Contains(firstNumber));
        }

        private string RandomAnswer()
        {
            return "AAAA";
        }
    }

    public class Game
    {
        private string _answer;

        public string Guess(string number)
        {
            SetAnswer();
            //TODO Hard Code Return
            return "4A0B";
        }

        private void SetAnswer()
        {
            //TODO Random Answer
            //TODO Hard Code Answer 1234
            _answer = "1234";
        }
    }
}