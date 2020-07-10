using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {1, "Fifteen"},
            {2, "Thirty"}
        };

        public override void ServerScore()
        {
            Scored();
            Score = $"{_scoreLookup[_gameContext._serverScore]} Love";
        }

        public override void ReceiverScore()
        {
            Scored();
            Score = $"Love {_scoreLookup[_gameContext._receiverScore]}";
        }

        private void Scored()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                _gameContext.State.ReceiverScore();
            }
        }
    }
}