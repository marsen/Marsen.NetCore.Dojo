namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class FifteenAll : State
    {
        public override string Score()
        {
            return "Fifteen All";
        }

        public override void ServerScore()
        {
            var state = new ThirtyFifteen();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            Context.ReceiverPoint++;
            var state = new NormalState();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}