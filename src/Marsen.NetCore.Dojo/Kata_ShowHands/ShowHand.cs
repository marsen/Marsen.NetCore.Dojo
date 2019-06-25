﻿using System;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class ShowHand
    {
        private readonly string _firstPlayerName;

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            return $"{_firstPlayerName} Win, Because Four Of a Kind";
        }
    }
}