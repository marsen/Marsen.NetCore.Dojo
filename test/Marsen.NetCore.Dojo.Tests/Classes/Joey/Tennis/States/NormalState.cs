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
            if (_gameContext._serverScore == _gameContext._receiverScore)
            {
                _gameContext._state = new AllState();
            }
        }

        public void SetContext(GameContext gameContext)
        {
            this._gameContext = gameContext;
        }
    }
}