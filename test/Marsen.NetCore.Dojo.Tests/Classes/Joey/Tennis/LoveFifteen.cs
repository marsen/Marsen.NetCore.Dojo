namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
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