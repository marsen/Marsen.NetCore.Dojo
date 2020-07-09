namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override void ServerScore()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                _gameContext.State.ReceiverScore();
            }

            Score = "Fifteen Love";
        }

        public override void ReceiverScore()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                _gameContext.State.ReceiverScore();
            }

            Score = "Love Fifteen";
        }
    }
}