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
        public string Guess(string s)
        {
            throw new NotImplementedException();
        }
    }
}