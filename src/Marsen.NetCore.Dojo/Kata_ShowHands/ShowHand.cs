﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class ShowHand
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;

        private readonly Dictionary<Category, string> _categoryLookup = new Dictionary<Category, string>
        {
            {Category.StraightFlush, "Straight Flush"},
            {Category.Flush, "Flush"},
            {Category.FourOfAKind, "Four Of a Kind"},
            {Category.ThreeOfAKind, "Three Of a Kind"},
            {Category.Straight, "Straight"},
            {Category.TwoPair, "Two Pair"},
            {Category.OnePair, "One Pair"},
        };

        private HandCard _firstPlayerHandCard;
        private HandCard _secondPlayerHandCard;

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            var cardParser = new CardParser();

            this._firstPlayerHandCard = new HandCard(cardParser.Parse(firstPlayerCard));
            this._secondPlayerHandCard = new HandCard(cardParser.Parse(secondPlayerCard));
            var handCardComparer = new HandCardComparer();
            if (handCardComparer.Compare(this._firstPlayerHandCard, this._secondPlayerHandCard) == 0)
            {
                return CompareKeyCard() == null
                    ? "End in a tie"
                    : $"{KeyCardWinner} Win, Because {this.GetWinnerCategory()}, Key Card {KeyCardDisplay(KeyCard)}";
            }

            if (handCardComparer.KeyCard > 0)
            {
                return
                    $"{GetWinner()} Win, Because {GetWinnerCategory()}, Key Card{KeyCardDisplay(handCardComparer.KeyCard)}";
            }

            return $"{GetWinner()} Win, Because {GetWinnerCategory()}";
        }


        private Tuple<int, int, int> CompareKeyCard()
        {
            var result = this._firstPlayerHandCard.GetKeyCard()
                .Zip(this._secondPlayerHandCard.GetKeyCard(),
                    (x, y) =>
                        Tuple.Create(x - y, x, y)
                ).FirstOrDefault(x => x.Item1 != 0);
            if (result != null)
            {
                KeyCard = Math.Max(result.Item2, result.Item3);
                KeyCardWinner = result.Item2 > result.Item3 ? _firstPlayerName : _secondPlayerName;
            }

            return result;
        }

        public string KeyCardWinner { get; set; }

        public int KeyCard { get; set; }

        private string KeyCardDisplay(int firstKeyCard)
        {
            if (firstKeyCard < 11 && firstKeyCard > 1)
            {
                return firstKeyCard.ToString();
            }

            var rankLookup = new Dictionary<int, string>
            {
                {14, "A"},
                {13, "K"},
                {12, "Q"},
                {11, "J"},
            };
            return rankLookup[firstKeyCard];
        }

        private string GetWinnerCategory()
        {
            return IsFirstPlayerWin()
                ? _categoryLookup[this._firstPlayerHandCard.GetCategory()]
                : _categoryLookup[this._secondPlayerHandCard.GetCategory()];
        }

        private string GetWinner()
        {
            return IsFirstPlayerWin() ? _firstPlayerName : _secondPlayerName;
        }

        private bool IsFirstPlayerWin()
        {
            return this._firstPlayerHandCard.GetCategory() - this._secondPlayerHandCard.GetCategory() > 0;
        }
    }

    public class HandCardComparer : IComparer<HandCard>
    {
        public int Compare(HandCard x, HandCard y)
        {
            return x.GetCategory() - y.GetCategory();
        }

        private Tuple<int, int, int> CompareKeyCard(HandCard x, HandCard y)
        {
            var result = x.GetKeyCard()
                .Zip(y.GetKeyCard(),
                    (a, b) =>
                        Tuple.Create(a - b, a, b)
                ).FirstOrDefault(r => r.Item1 != 0);
            return result;
        }

        public int KeyCard { get; set; }
    }
}