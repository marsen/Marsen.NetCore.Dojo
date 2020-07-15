namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
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

    public class ThirtyLove : State
    {
        public override string Score()
        {
            return "Thirty Love";
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