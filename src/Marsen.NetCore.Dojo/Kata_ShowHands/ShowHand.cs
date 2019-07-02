using System.Collections.Generic;

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

            var firstPlayerHandCard = new HandCard(cardParser.Parse(firstPlayerCard));
            var secondHandCard = new HandCard(cardParser.Parse(secondPlayerCard));
            string winner = null;
            string winnerCategory = null;
            string highCard = string.Empty;
            if (firstPlayerHandCard.Category - secondHandCard.Category > 0)
            {
                winner = _firstPlayerName;
                winnerCategory = categoryLookup[firstPlayerHandCard.Category];
            }

            if (firstPlayerHandCard.Category - secondHandCard.Category == 0)
            {
                winner = "Lee";
                winnerCategory = categoryLookup[secondHandCard.Category];
                highCard = ", High Card 6";
            }

            if (firstPlayerHandCard.Category - secondHandCard.Category < 0)
            {
                winner = _secondPlayerName;
                winnerCategory = categoryLookup[secondHandCard.Category];
            }

            return $"{winner} Win, Because {winnerCategory}{highCard}";
        }
    }
}