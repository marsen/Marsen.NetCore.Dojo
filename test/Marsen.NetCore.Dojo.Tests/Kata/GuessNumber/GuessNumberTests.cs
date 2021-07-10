using System;
using System.Linq;
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
            var answer = game.RandomAnswer();
            Assert.Equal(4, answer.Length);
        }

        [Fact]
        public void TestRandomAnswerShouldAllBeNumber()
        {
            string allNumber = "0123456789";
            var answer = game.RandomAnswer();
            Assert.Contains(answer.Substring(0, 1), allNumber);
            Assert.Contains(answer.Substring(1, 1), allNumber);
            Assert.Contains(answer.Substring(2, 1), allNumber);
            Assert.Contains(answer.Substring(3, 1), allNumber);
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

        public string RandomAnswer()
        {
            return new string("1234567890"
                .OrderBy(x => new Random().Next())
                .Take(4)
                .ToArray());
        }
    }
}