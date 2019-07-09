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
            {Category.FourOfAKind, "Four Of a Kind"},
            {Category.ThreeOfAKind, "Three Of a Kind"}
        };

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            var cardParser = new CardParser();

            var firstPlayerHandCard = new HandCard(cardParser.Parse(firstPlayerCard));
            var secondPlayerHandCard = new HandCard(cardParser.Parse(secondPlayerCard));
            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category > 0)
            {
                return $"{_firstPlayerName} Win, Because {_categoryLookup[firstPlayerHandCard.Category]}";
            }

            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category == 0)
            {
                for (var i = 0; i < firstPlayerHandCard.KeyCard.Count; i++)
                {
                    string keyCard;
                    if (firstPlayerHandCard.KeyCard[i] > secondPlayerHandCard.KeyCard[i])
                    {
                        keyCard = $", High Card {firstPlayerHandCard.KeyCard[i]}";
                        return
                            $"{_firstPlayerName} Win, Because {_categoryLookup[firstPlayerHandCard.Category]}{keyCard}";
                    }

                    if (firstPlayerHandCard.KeyCard[i] < secondPlayerHandCard.KeyCard[i])
                    {
                        keyCard = $", High Card {secondPlayerHandCard.KeyCard[i]}";
                        return
                            $"{_secondPlayerName} Win, Because {_categoryLookup[secondPlayerHandCard.Category]}{keyCard}";
                    }

                    if (i == firstPlayerHandCard.KeyCard.Count - 1)
                    {
                        return "End in a tie";
                    }
                }
            }

            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category < 0)
            {
                return $"{_secondPlayerName} Win, Because {_categoryLookup[secondPlayerHandCard.Category]}";
            }

            throw new NotImplementedException("un know duel exception");
        }
    }
}