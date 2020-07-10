using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        private readonly GameContext _game;

        public GameContextTests()
        {
            _game = new GameContext();
        }

        [Fact]
        public void Fifteen_Love()
        {
            _game.ServerScored();
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void Thirty_Love()
        {
            _game.ServerScored();
            _game.ServerScored();
            ScoreShouldBe("Thirty Love");
        }


        [Fact]
        public void Love_Fifteen()
        {
            _game.ReceiverScored();
            ScoreShouldBe("Love Fifteen");
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _game.State.Score);
        }

        [Fact]
        public void Fifteen_All_After_ReceiverScore()
        {
            _game.ServerScored();
            _game.ReceiverScored();
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void Fifteen_All_After_ServerScore()
        {
            _game.ReceiverScored();
            _game.ServerScored();
            ScoreShouldBe("Fifteen All");
        }
    }
}