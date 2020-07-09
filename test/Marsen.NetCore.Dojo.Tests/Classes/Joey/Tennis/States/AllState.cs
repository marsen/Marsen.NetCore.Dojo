namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class AllState : NormalState
    {
        public override string ReceiverScore()
        {
            Score = "Fifteen All";
            return "Fifteen All";
        }

        public override string ServerScore()
        {
            Score = "Fifteen All";
            return "Fifteen All";
        }
    }
}