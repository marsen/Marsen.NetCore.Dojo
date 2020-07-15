namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class LoveAll : State
    {
        public override string Score()
        {
            return "Love All";
        }

        public override void ServerScore()
        {
            var state = new FifteenLove();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }

        public override void ReceiverScore()
        {
            var state = new LoveFifteen();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}