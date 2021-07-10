using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class GuessNumberTests
    {
        public GuessNumberTests()
        {
            _helper = Substitute.For<IHelper>();
            _helper.Get(4).Returns("1234");
            game = new(_helper);
        }

        private Game game;
        private IHelper _helper;

        [Fact]
        public void TestGuessNumber()
        {
            Assert.Equal("4A0B", game.Guess("1234"));
            Assert.Equal("3A0B", game.Guess("1235"));
            Assert.Equal("2A0B", game.Guess("1265"));
            Assert.Equal("1A0B", game.Guess("1765"));
            Assert.Equal("1A1B", game.Guess("1365"));
            Assert.Equal("0A4B", game.Guess("4321"));
            Assert.Equal("0A0B", game.Guess("5678"));
        }
    }
}