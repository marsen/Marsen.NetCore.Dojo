using System.Reflection.Metadata;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class SameState : State
    {
        public override string Score()
        {
            if (Context.ServerPoint >= 3)
            {
                return "Deuce";
            }

            return $"{ScoreLookup[Context.ServerPoint]} All";
        }

        public override void ServerScore()
        {
            Context.ServerPoint++;
            ChangeState();
        }

        private void ChangeState()
        {
            State state = new NormalState();
            state.SetContext(this.Context);
            Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }
    }
}