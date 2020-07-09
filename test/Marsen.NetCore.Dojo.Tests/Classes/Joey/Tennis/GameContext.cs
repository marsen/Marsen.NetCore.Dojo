using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContext
    {
        internal State State;
        protected internal int ServerScore;
        protected internal int ReceiverScore;

        public GameContext()
        {
            State = new NormalState();
            State.SetContext(this);
        }

        public void ServerScored()
        {
            ServerScore++;
            State.ServerScore();
        }

        public void ReceiverScored()
        {
            ReceiverScore++;
            State.ReceiverScore();
        }

        public bool IsSame()
        {
            return ServerScore == ReceiverScore;
        }

        public void ChangeState(State state)
        {
            this.State = state;
        }
    }
}