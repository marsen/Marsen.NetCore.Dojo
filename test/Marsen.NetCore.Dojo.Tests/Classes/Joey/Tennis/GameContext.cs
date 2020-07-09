using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContext
    {
        internal State State;
        private int _serverScore;
        private int _receiverScore;

        public GameContext()
        {
            State = new NormalState();
            State.SetContext(this);
        }

        public void ServerScored()
        {
            _serverScore++;
            State.ServerScore();
        }

        public void ReceiverScored()
        {
            _receiverScore++;
            State.ReceiverScore();
        }

        public bool IsSame()
        {
            return _serverScore == _receiverScore;
        }

        public void ChangeState(State state)
        {
            this.State = state;
        }
    }
}