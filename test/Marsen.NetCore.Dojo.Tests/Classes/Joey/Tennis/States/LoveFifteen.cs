namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class LoveFifteen : State
    {
        public override string Score()
        {
            return "Love Fifteen";
        }

        public override void ServerScore()
        {
            var state = new FifteenAll();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            var state = new LoveThirty();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}