namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        public override void ServerScore()
        {
            Scored();
        }

        public override void ReceiverScore()
        {
            Scored();
        }

        private void Scored()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                _gameContext.State.SetContext(_gameContext);
                _gameContext.State.ReceiverScore();
            }

            Score = $"{_gameContext.ServerScore} {_gameContext.ReceiverScore}";
        }
    }
}