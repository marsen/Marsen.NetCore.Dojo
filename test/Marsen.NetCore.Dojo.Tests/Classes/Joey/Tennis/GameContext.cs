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

        public string ServerScored()
        {
            ServerScore++;
            State.ChangeState();
            return State.ServerScore();
        }

        public string ReceiverScored()
        {
            ReceiverScore++;
            return State.ReceiverScore();
        }
        
   
    }
}