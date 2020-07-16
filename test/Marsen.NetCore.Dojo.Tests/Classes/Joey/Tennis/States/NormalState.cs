namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override string Score()
        {
            return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
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
                state = new FifteenAll();
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