namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public abstract class State
    {
        protected GameContext _gameContext;
        public abstract string ServerScore();
        public abstract string ReceiverScore();

        public void SetContext(GameContext gameContext)
        {
            this._gameContext = gameContext;
        }
    }
}