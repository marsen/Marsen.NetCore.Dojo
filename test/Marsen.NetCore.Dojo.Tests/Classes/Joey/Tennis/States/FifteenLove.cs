namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class FifteenLove : State
    {
        public override string Score()
        {
            return "Fifteen Love";
        }

        public override void ServerScore()
        {
            var state = new ThirtyLove();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            var state = new FifteenAll();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}