namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public abstract class State
    {
        protected GameContext _gameContext;
        public string Score;
        public abstract void ServerScore();
        public abstract void ReceiverScore();

        public void SetContext(GameContext gameContext)
        {
            this._gameContext = gameContext;
        }
    }
}