namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class AdvState : State
    {
        public override string Score()
        {
            return $"{Winner()} Adv";
        }

        private string Winner()
        {
            var winner = Context.ServerPoint > Context.ReceiverPoint ? Context.ServerPlayer : "Iris";
            return winner;
        }

        public override void ServerScore()
        {
            Context.ServerPoint++;
            ChangeState();
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }

        private void ChangeState()
        {
            State state = (Context.ServerPoint == Context.ReceiverPoint) ? (State) new DeuceState() : new AdvState();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}