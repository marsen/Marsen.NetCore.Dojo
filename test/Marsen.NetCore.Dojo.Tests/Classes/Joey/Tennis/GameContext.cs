using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContext
    {
        NormalState _state = new NormalState();
        protected internal int _serverScore;
        protected internal int _receiverScore;

        public NormalState State
        {
            set { _state = value; }
            get { return _state; }
        }


        public string ServerScore()
        {
            _serverScore++;
            _state.ChangeState(this);
            return _state.ServerScore();
        }

        public string ReceiverScore()
        {
            _receiverScore++;
            _state.ChangeState(this);
            return _state.ReceiverScore();
        }
    }
}