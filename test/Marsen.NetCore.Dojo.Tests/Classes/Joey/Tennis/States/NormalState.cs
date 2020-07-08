namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : IState
    {
        public virtual string ServerScore()
        {
            return "Fifteen Love";
        }

        public virtual string ReceiverScore()
        {
            return "Love Fifteen";
        }

        public void ChangeState(GameContext gameContext)
        {
            if (gameContext._serverScore == gameContext._receiverScore)
            {
                gameContext.State = new AllState();
            }
        }
    }
}