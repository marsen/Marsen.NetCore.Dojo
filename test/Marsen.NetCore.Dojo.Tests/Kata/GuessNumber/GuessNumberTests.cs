using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class GuessNumberTests
    {
        [Fact]
        public void TestItShouldGet4A0B()
        {
            var game = new Game();
            string result = game.Guess("1234");
            Assert.Equal("4A0B", result);
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