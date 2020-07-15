namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public abstract class State
    {
        protected TennisGameContext Context;
        public abstract string Score();

        public void SetContext(TennisGameContext context)
        {
            this.Context = context;
        }

        public abstract void ServerScore();

        public abstract void ReceiverScore();
    }
}