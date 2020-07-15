namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class LoveThirty : State
    {
        public override string Score()
        {
            return "Love Thirty";
        }

        public override void ServerScore()
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiverScore()
        {
            this.Context.ChangeState(new LoveForty());
        }
    }
}