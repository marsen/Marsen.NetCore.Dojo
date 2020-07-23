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

        [Fact]
        public void FifteenLove()
        {
            _context.ServerScore();
            ScoreShouldBe("Fifteen Love");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _context.Score());
        }
    }

    public class GameContext
    {
        private IState _state;

        public GameContext()
        {
            _state = new SameState();
        }

        public string Score()
        {
            if (ServerPoint == 1)
            {
                return "Fifteen Love";
            }
            if (ReceiverPoint == 1)
            {
                _state = new NormalState();
                return _state.Score();
            }

            return _state.Score();
        }

        public void ReceiverScore()
        {
            ReceiverPoint++;
        }

        private int ReceiverPoint { get; set; }

        public void ServerScore()
        {
            ServerPoint++;
        }

        private int ServerPoint { get; set; }
    }

    public class NormalState : IState
    {
        public string Score()
        {
            return "Love Fifteen";
        }
    }

    public interface IState
    {
        string Score();
    }

    public class SameState : IState
    {
        public string Score()
        {
            return "Love All";
        }
    }
}