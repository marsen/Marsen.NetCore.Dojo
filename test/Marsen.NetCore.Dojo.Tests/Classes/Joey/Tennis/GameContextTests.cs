using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        readonly GameContext _game = new GameContext();

        private string _result;
        [Fact]
        public void FifteenLove()
        {
            _result = _game.ServerScore();
            ScoreShouldBe("Fifteen Love");
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
    }

    public class NormalState
    {
        public string ServerScore()
        {
            return "Fifteen Love";
        }
    }
}