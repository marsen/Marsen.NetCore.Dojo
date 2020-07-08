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

        public void ChangeState(GameContext gameContext)
        {
            if (_gameContext.ServerScore == _gameContext.ReceiverScore)
            {
                _gameContext.State = new AllState();
            }
        }

        public void SetContext(GameContext gameContext)
        {
            this._gameContext = gameContext;
        }
    }
}