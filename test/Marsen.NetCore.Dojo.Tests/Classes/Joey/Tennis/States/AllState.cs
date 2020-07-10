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
        }

        public override void ServerScore()
        {
            Scored();
        }
    }
}