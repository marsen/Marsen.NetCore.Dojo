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

        [Fact]
        public void Fifteen_All_After_ReceiverScore()
        {
            _result = _game.ServerScore();
            _result = _game.ReceiverScore();
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void Fifteen_All_After_ServerScore()
        {
            _result = _game.ReceiverScore();
            _result = _game.ServerScore();
            ScoreShouldBe("Fifteen All");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _result);
        }
    }
}