namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
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