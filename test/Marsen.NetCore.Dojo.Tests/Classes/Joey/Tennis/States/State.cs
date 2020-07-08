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

        public void ChangeState()
        {
            if (_gameContext.ServerScore == _gameContext.ReceiverScore)
            {
                _gameContext.State = new AllState();
            }
        }
    }
}