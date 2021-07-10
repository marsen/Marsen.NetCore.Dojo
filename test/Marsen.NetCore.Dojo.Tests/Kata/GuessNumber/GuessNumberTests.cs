using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class GuessNumberTests
    {
        Game game = new();

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

        [Fact]
        public void TestRandomAnswerLengthShouldBe4()
        {
            //TODO Combine Two case 
            Assert.Equal(4, game.RandomAnswer().Length);
        }

        [Fact]
        public void TestRandomAnswerShouldAllBeNumber()
        {
            Assert.Matches(new Regex("\\d+"),game.RandomAnswer());
        }

        [Fact]
        public void TestRandomAnswerShouldUnique()
        {
            var answer = game.RandomAnswer();
            var originCount = answer.Length;
            var afterDistinct = answer.Distinct().Count();
            Assert.Equal(originCount, afterDistinct);
        }
    }
}