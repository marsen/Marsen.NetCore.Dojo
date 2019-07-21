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
                for (var i = 0; i < this._firstPlayerHandCard.KeyCard.Count; i++)
                {
                    var category = _categoryLookup[this._firstPlayerHandCard.GetCategory()];
                    if (this._firstPlayerHandCard.KeyCard[i] > this._secondPlayerHandCard.KeyCard[i])
                    {
                        return
                            $"{_firstPlayerName} Win, Because {category}, Key Card {this._firstPlayerHandCard.KeyCard[i]}";
                    }

                    if (this._firstPlayerHandCard.KeyCard[i] < this._secondPlayerHandCard.KeyCard[i])
                    {
                        return
                            $"{_secondPlayerName} Win, Because {category}, Key Card {this._secondPlayerHandCard.KeyCard[i]}";
                    }
                }

                return "End in a tie";
            }

            if (IsFirstPlayerWin())
            {
                return $"{_firstPlayerName} Win, Because {_categoryLookup[this._firstPlayerHandCard.GetCategory()]}";
            }
            else
            {
                return $"{_secondPlayerName} Win, Because {_categoryLookup[this._secondPlayerHandCard.GetCategory()]}";
            }
        }

        private bool IsFirstPlayerWin()
        {
            return this._firstPlayerHandCard.GetCategory() - this._secondPlayerHandCard.GetCategory() > 0;
        }
    }
}