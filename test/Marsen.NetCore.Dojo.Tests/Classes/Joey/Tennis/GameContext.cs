using System.Collections.Generic;
using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContext
    {
        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        internal State State;
        public int _serverScore;
        private int _receiverScore;

        public string ServerScore => _scoreLookup[_serverScore];

        public string ReceiverScore => _scoreLookup[_receiverScore];

        public GameContext()
        {
            State = new NormalState();
            State.SetContext(this);
        }

        public void ServerScored()
        {
            _serverScore++;
            State.ServerScore();
        }

        public void ReceiverScored()
        {
            _receiverScore++;
            State.ReceiverScore();
        }

        public bool IsSame()
        {
            return _serverScore == _receiverScore;
        }

        public void ChangeState(State state)
        {
            this.State = state;
        }
    }
}