namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class AllState : State
    {
        public override void ReceiverScore()
        {
            Scored();
        }

        private void Scored()
        {
            Score = $"{_gameContext.ServerScore} All";
            if (_gameContext._serverScore == 3)
            {
                Score = "Deuce";
            }

        }

        public override void ServerScore()
        {
            Scored();
        }
    }
}