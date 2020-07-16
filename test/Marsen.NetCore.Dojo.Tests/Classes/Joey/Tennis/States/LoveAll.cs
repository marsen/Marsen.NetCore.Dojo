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
            Context.ServerPoint++;
            var state = new NormalState();
            state.SetContext(this.Context);
            Context.ChangeState(state);
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