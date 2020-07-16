using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public abstract class State
    {
        protected readonly Dictionary<int, string> ScoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"}
        };

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