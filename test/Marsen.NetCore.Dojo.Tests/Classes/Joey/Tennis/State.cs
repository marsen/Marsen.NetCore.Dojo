using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public abstract class State
    {
        protected readonly Dictionary<int, string> ScoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        protected TennisGameContext Context;
        public abstract string Score();

        public void SetContext(TennisGameContext context)
        {
            this.Context = context;
        }

        protected string Winner()
        {
            return Context.ServerPoint > Context.ReceiverPoint
                ? Context.ServerName
                : Context.ReceiverName;
        }

        public void ServerScore()
        {
            Context.ServerPoint++;
            ChangeState();
        }

        protected abstract void ChangeState();

        public abstract void ReceiverScore();
    }
}