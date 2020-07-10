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
            GivenServerScored(1);
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void Thirty_Love()
        {
            GivenServerScored(2);
            ScoreShouldBe("Thirty Love");
        }

        [Fact]
        public void Forty_Love()
        {
            GivenServerScored(3);
            ScoreShouldBe("Forty Love");
        }

        private void GivenServerScored(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _game.ServerScored();
            }
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