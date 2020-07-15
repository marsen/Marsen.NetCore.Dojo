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
            this.Context.ChangeState(new LoveFifteen());
        }
    }

    public class LoveFifteen : State
    {
        public override string Score()
        {
            return "Love Fifteen";
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