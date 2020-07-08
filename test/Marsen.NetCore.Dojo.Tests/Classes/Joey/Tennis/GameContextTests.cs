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

    public class GameContext
    {
        NormalState _state = new NormalState();
        private int _serverScore;
        private int _receiverScore;

        public string ServerScore()
        {
            _serverScore++;
            ChangeState();
            return _state.ServerScore();
        }

        public string ReceiverScore()
        {
            _receiverScore++;
            ChangeState();
            return _state.ReceiverScore();
        }

        private void ChangeState()
        {
            if (_serverScore == _receiverScore)
            {
                this._state = new AllState();
            }
        }
    }

    public class AllState : NormalState
    {
        public override string ReceiverScore()
        {
            return "Fifteen All";
        }

        public override string ServerScore()
        {
            return "Fifteen All";
        }
    }

    public class NormalState
    {
        public virtual string ServerScore()
        {
            return "Fifteen Love";
        }

        public virtual string ReceiverScore()
        {
            return "Love Fifteen";
        }
    }
}