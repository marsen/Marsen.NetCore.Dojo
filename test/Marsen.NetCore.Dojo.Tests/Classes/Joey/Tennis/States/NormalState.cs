using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class NormalState : State
    {
        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public override void ServerScore()
        {
            Scored();
        }

        public override void ReceiverScore()
        {
            Scored();
        }

        private void Scored()
        {
            if (_gameContext.IsSame())
            {
                _gameContext.ChangeState(new AllState());
                _gameContext.State.SetContext(_gameContext);
                _gameContext.State.ReceiverScore();
            }

            Score = $"{_scoreLookup[_gameContext._serverScore]} {_scoreLookup[_gameContext._receiverScore]}";
        }
    }
}