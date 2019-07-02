using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class ShowHand
    {
        private readonly string _firstPlayerName;
        private readonly string _secondPlayerName;

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            var cardParser = new CardParser();
            var categoryLookup = new Dictionary<Category, string>
            {
                {Category.FourOfAKind, "Four Of a Kind"},
                {Category.ThreeOfAKind, "Three Of a Kind"}
            };

            Category firstCategory = new HandCard(cardParser.Parse(firstPlayerCard)).Category;

            Category secondCategory = new HandCard(cardParser.Parse(secondPlayerCard)).Category;
            string winner = null;
            string winnerCategory = null;
            string highCard = string.Empty;
            if (firstCategory - secondCategory > 0)
            {
                winner = _firstPlayerName;
                winnerCategory = categoryLookup[firstCategory];
            }
            else if (firstCategory - secondCategory == 0)
            {
                winner = "Lee";
                winnerCategory = categoryLookup[secondCategory];
                highCard = ", High Card 6";
            }
            else
            {
                winner = _secondPlayerName;
                winnerCategory = categoryLookup[secondCategory];
            }

            return $"{winner} Win, Because {winnerCategory}{highCard}";
        }
    }

    public class HandCard
    {
        public HandCard(List<Card> parse)
        {
            this.Category = this.GetCategory(parse);
        }

        public Category Category { get; }

        private Category GetCategory(List<Card> cardList)
        {
            var groupCards = cardList
                .GroupBy(x => x.Rank)
                .Select(g => new { Count = g.Count() });
            if (groupCards.Any(x => x.Count == 4))
            {
                return Category.FourOfAKind;
            }

            if (groupCards.Any(x => x.Count == 3))
            {
                return Category.ThreeOfAKind;
            }

            return Category.TwoPair;
        }
    }
}