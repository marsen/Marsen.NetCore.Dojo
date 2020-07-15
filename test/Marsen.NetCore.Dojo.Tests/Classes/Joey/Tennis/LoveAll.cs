namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class LoveAll : State
    {
        public override string Score()
        {
            return "Love All";
        }

        public override void ServerScore()
        {
            this.Context.ChangeState(new FifteenLove());
        }

        public override void ReceiverScore()
        {
            var state = new LoveFifteen();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}