namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        private GameContext _gameContext;

        public override string ServerScore()
        {
            return "Fifteen Love";
        }

        public override string ReceiverScore()
        {
            return "Love Fifteen";
        }
    }
}