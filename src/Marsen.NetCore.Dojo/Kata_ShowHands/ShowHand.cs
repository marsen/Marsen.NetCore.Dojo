﻿using System.Collections.Generic;
using System.Linq;

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
            var cardParser = new CardParser();
            var categoryLookup = new Dictionary<Category,string>
            {
                {Category.FourOfAKind, "Four Of a Kind"}
            };
            List<Card> firstCardList = cardParser.Parse(firstPlayerCard);
            var firstCategory = GetCategory(firstCardList);
            List<Card> secondCardList = cardParser.Parse(secondPlayerCard);
            var secondCategory = GetCategory(secondCardList);
            string winner = null;
            string winnerCategory = null;
            if (firstCategory - secondCategory > 0)
            {
                winner = _firstPlayerName;
                winnerCategory = categoryLookup[firstCategory];
            }

            var firstPlayerCategory = "Four Of a Kind";
            return $"{winner} Win, Because {winnerCategory}";
        }

        private Category GetCategory(List<Card> cardList)
        {
            var groupCards = cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count()});
            if (groupCards.Any(x => x.Count == 4))
            {
                return Category.FourOfAKind;
            }

            return Category.ThreeOfAKind;
        }
    }

    internal enum Category
    {
        ThreeOfAKind,
        FourOfAKind,
    }
}