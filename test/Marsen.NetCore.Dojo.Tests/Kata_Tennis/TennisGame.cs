using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGame
    {
        private readonly string _firstPlayerName;
        private int _firstPlayerScore;

        private int _secondPlayerScore;

        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TennisGame" /> class.
        /// </summary>
        public TennisGame(string firstPlayerName)
        {
            _firstPlayerName = firstPlayerName;
        }

        public string Score()
        {
            if (_firstPlayerScore == _secondPlayerScore)
            {
                if (_firstPlayerScore >= 3)
                {
                    return "Deuce";
                }

                return $"{_scoreLookup[_firstPlayerScore]} All";
            }

            if (_firstPlayerScore > 3)
            {
                if (_firstPlayerScore - _secondPlayerScore > 1)
                {
                    return $"{_firstPlayerName} Win";
                }

                return $"{_firstPlayerName} Adv";
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