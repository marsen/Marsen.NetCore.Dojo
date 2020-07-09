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
            _game.ServerScored();
            ScoreShouldToBe("Fifteen Love");
        }

        [Fact]
        public void Love_Fifteen()
        {
            _result = _game.ReceiverScored();
            ScoreShouldToBe("Love Fifteen");
        }

        private void ScoreShouldToBe(string expected)
        {
            Assert.Equal(expected, _game.State.Score);
        }

        [Fact]
        public void Fifteen_All_After_ReceiverScore()
        {
            _result = _game.ServerScored();
            _result = _game.ReceiverScored();
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void Fifteen_All_After_ServerScore()
        {
            _result = _game.ReceiverScored();
            _result = _game.ServerScored();
            ScoreShouldBe("Fifteen All");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _result);
        }
    }
}