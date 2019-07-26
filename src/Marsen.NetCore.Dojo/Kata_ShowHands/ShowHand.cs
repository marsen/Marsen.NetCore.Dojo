using System;
using System.Collections.Generic;

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


            if (this._firstPlayerHandCard.GetCategory() - this._secondPlayerHandCard.GetCategory() == 0)
            {
                var category = _categoryLookup[this._firstPlayerHandCard.GetCategory()];
                for (var i = 0; i < this._firstPlayerHandCard.KeyCard.Count; i++)
                {
                    var firstKeyCard = this._firstPlayerHandCard.KeyCard[i];
                    var secondKeyCard = this._secondPlayerHandCard.KeyCard[i];
                    if (firstKeyCard > secondKeyCard)
                    {
                        return
                            $"{_firstPlayerName} Win, Because {category}, Key Card {KeyCardDisplay(firstKeyCard)}";
                    }

                    if (firstKeyCard < secondKeyCard)
                    {
                        return
                            $"{_secondPlayerName} Win, Because {category}, Key Card {KeyCardDisplay(secondKeyCard)}";
                    }
                }

                return "End in a tie";
            }

            return $"{GetWinner()} Win, Because {GetWinnerCategory()}";
        }

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

            if (firstKeyCard == 14)
            {
                return "A";
            }

            if (firstKeyCard == 13)
            {
                return "K";
            }

            if (firstKeyCard == 12)
            {
                return "Q";
            }

            if (firstKeyCard == 11)
            {
                return "J";
            }

            return firstKeyCard.ToString();
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
}