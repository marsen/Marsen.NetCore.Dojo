namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class FortyLove : State
    {
        public override string Score()
        {
            return "Forty Love";
        }

        public override void ServerScore()
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiverScore()
        {
            var state = new FortyFifteen();
            state.SetContext(this.Context);
            this.Context.ChangeState(state);
        }
    }
}