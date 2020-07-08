namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : IState
    {
        public string ServerScore()
        {
            return "Fifteen Love";
        }

        public string ReceiverScore()
        {
            return "Love Fifteen";
        }
    }
}