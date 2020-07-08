using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        readonly GameContext _game = new GameContext();

        private string _result;

        [Fact]
        public void Fifteen_Love()
        {
            _result = _game.ServerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void Love_Fifteen()
        {
            _result = _game.ReceiverScore();
            ScoreShouldBe("Love Fifteen");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _result);
        }
    }

    public class GameContext
    {
        public string ServerScore()
        {
            var normalState = new NormalState();
            return normalState.ServerScore();
        }

        public string ReceiverScore()
        {
            var normalState = new NormalState();
            return normalState.ReceiverScore();
        }
    }

    public class NormalState
    {
        public string ServerScore()
        {
            return "Fifteen Love";
        }

        public string ReceiverScore()
        {
            return "Love Fifteen";
        }
    }
}