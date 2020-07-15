namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
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
            throw new System.NotImplementedException();
        }
    }
}