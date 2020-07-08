using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContext
    {
        internal State State ;
        protected internal int _serverScore;
        protected internal int _receiverScore;

        public GameContext()
        {
            State = new NormalState();
            State.SetContext(this);
        }

        public string ServerScore()
        {
            _serverScore++;
            State.ChangeState();
            return State.ServerScore();
        }

        public string ReceiverScore()
        {
            _receiverScore++;
            State.ChangeState();
            return State.ReceiverScore();
        }
    }
}