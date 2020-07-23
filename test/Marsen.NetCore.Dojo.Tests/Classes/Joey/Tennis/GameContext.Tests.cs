using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        readonly GameContext _context = new GameContext();

        [Fact]
        public void LoveAll()
        {
            ScoreShouldBe("Love All");
        }

        [Fact]
        public void LoveFifteen()
        {
            _context.ReceiverScore();
            ScoreShouldBe("Love Fifteen");
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _context.Score());
        }
    }

    public class GameContext
    {
        public string Score()
        {
            if (ReceiverPoint==1)
            {
                return "Love Fifteen";
            }
            var state = new SameState();
            return state.Score();
        }

        public void ReceiverScore()
        {
            ReceiverPoint++;
        }

        private int ReceiverPoint { get; set; }
    }

    public class SameState
    {
        public string Score()
        {
            return "Love All";
        }
    }
}