namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public abstract class State
    {
        private GameContext _gameContext;
        public abstract string ServerScore();
        public abstract string ReceiverScore();

        public void SetContext(GameContext gameContext)
        {
            this._gameContext = gameContext;
        }

        public void ChangeState(GameContext gameContext)
        {
            if (_gameContext._serverScore == _gameContext._receiverScore)
            {
                _gameContext._state = new AllState();
            }
        }
    }
}