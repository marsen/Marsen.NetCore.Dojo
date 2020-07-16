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
            throw new System.NotImplementedException();
        }

        public override void ReceiverScore()
        {
            var state = new FifteenThirty();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }

    public class FifteenThirty : State
    {
        public override string Score()
        {
            return "Fifteen Thirty";
        }

        public override void ServerScore()
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiverScore()
        {
            throw new System.NotImplementedException();
        }
    }
}