﻿using System;
using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata.Tennis
{
    public class TennisGame
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;
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
        public TennisGame(string firstPlayerName, string secondPlayerName)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        public string Score()
        {
            return IsSameScore()
                ? (IsOverForty() ? DeuceScore() : SameScore())
                : (IsReadyForWin() ? AdvScore() : NormalScore());
        }

        private bool IsOverForty()
        {
            return _firstPlayerScore >= 3;
        }

        private static string DeuceScore()
        {
            return "Deuce";
        }

        private string NormalScore()
        {
            return $"{_scoreLookup[_firstPlayerScore]} {_scoreLookup[_secondPlayerScore]}";
        }

        private string SameScore()
        {
            return $"{_scoreLookup[_firstPlayerScore]} All";
        }

        private string AdvScore()
        {
            return $"{GetWinnerName()} " + (IsLeading2() ? "Win" : "Adv");
        }

        private bool IsLeading2()
        {
            return Math.Abs(_firstPlayerScore - _secondPlayerScore) > 1;
        }

        private string GetWinnerName()
        {
            return _firstPlayerScore > _secondPlayerScore ? _firstPlayerName : _secondPlayerName;
        }

        private bool IsReadyForWin()
        {
            return _firstPlayerScore > 3 || _secondPlayerScore > 3;
        }

        private bool IsSameScore()
        {
            return _firstPlayerScore == _secondPlayerScore;
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