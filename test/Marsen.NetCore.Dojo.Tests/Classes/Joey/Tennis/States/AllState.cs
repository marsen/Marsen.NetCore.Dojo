using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States
{
    public class AllState : State
    {
        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public override void ReceiverScore()
        {
            Scored();
        }

        private void Scored()
        {
            Score = $"{_scoreLookup[_gameContext._serverScore]} All";
        }

        public override void ServerScore()
        {
            Scored();
        }
    }
}