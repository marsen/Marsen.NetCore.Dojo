namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override string Score()
        {
            if (Context.ServerPoint < 4 && Context.ReceiverPoint < 4)
            {
                return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
            }

            return "";
        }

        public override void ServerScore()
        {
            Context.ServerPoint++;
            ChangeState();
        }

        private void ChangeState()
        {
            State state = new NormalState();
            if (Context.ServerPoint == Context.ReceiverPoint)
            {
                if (Context.ServerPoint >= 3)
                {
                    state = new DeuceState();
                }
                else
                {
                    state = new SameState();
                }
            }

            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }
    }
}