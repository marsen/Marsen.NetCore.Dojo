using System;
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


            if (this._firstPlayerHandCard.GetCategory() == this._secondPlayerHandCard.GetCategory())
            {
                for (var i = 0; i < this._firstPlayerHandCard.GetKeyCard().Count(); i++)
                {
                    var firstKeyCard = this._firstPlayerHandCard.GetKeyCard().ElementAt(i);
                    var secondKeyCard = this._secondPlayerHandCard.GetKeyCard().ElementAt(i);
                    if (firstKeyCard == secondKeyCard)
                    {
                        continue;
                    }

                    string winner;
                    int winnerKeyCard;
                    if (firstKeyCard > secondKeyCard)
                    {
                        winner = _firstPlayerName;
                        winnerKeyCard = firstKeyCard;
                    }
                    else
                    {
                        winner = _secondPlayerName;
                        winnerKeyCard = secondKeyCard;
                    }

                    return
                        $"{winner} Win, Because {_categoryLookup[this._firstPlayerHandCard.GetCategory()]}, Key Card {KeyCardDisplay(winnerKeyCard)}";
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