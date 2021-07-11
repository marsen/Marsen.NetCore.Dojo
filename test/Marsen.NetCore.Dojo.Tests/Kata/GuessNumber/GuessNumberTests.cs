using Marsen.NetCore.Dojo.Kata.GuessNumber;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class GuessNumberTests
    {
        public GuessNumberTests()
        {
            var randomInt = Substitute.For<IRandomInt>();
            randomInt.GetNonRepeatInt(4).Returns("1234");
            _game = new Game(randomInt);
        }

        private readonly Game _game;

        [Fact]
        public void TestGuessNumber()
        {
            Assert.Equal("4A0B", _game.Guess("1234"));
            Assert.Equal("3A0B", _game.Guess("1235"));
            Assert.Equal("2A0B", _game.Guess("1265"));
            Assert.Equal("1A0B", _game.Guess("1765"));
            Assert.Equal("1A1B", _game.Guess("1365"));
            Assert.Equal("0A4B", _game.Guess("4321"));
            Assert.Equal("0A0B", _game.Guess("5678"));
        }
    }
}