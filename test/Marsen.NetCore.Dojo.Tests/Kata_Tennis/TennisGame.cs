using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGame
    {
        private int _firstPlayerScore;

        private int _secondPlayerScore;

        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };


        public string Score()
        {
            if (_firstPlayerScore == _secondPlayerScore)
            {
                if (_firstPlayerScore == 3)
                {
                    return "Deuce";
                }

                return $"{_scoreLookup[_firstPlayerScore]} All";
            }


            return $"{_scoreLookup[_firstPlayerScore]} {_scoreLookup[_secondPlayerScore]}";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScore++;
        }

        public void SecondPlayerScore()
        {
            _secondPlayerScore++;
        }
    }
}