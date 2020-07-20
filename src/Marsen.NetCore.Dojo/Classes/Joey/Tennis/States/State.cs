using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.Tennis.States
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

        protected bool IsSamePoint()
        {
            return Context.ServerPoint == Context.ReceiverPoint;
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

        public void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }
    }
}