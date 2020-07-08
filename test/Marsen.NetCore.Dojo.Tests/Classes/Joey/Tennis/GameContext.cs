using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
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
}