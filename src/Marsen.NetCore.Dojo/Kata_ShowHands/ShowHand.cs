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
            string winner = null;
            string winnerCategory = null;
            var keyCard = string.Empty;
            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category > 0)
            {
                winner = _firstPlayerName;
                winnerCategory = _categoryLookup[firstPlayerHandCard.Category];
            }

            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category == 0)
            {
                for (var i = 0; i < firstPlayerHandCard.KeyCard.Count; i++)
                {
                    if (firstPlayerHandCard.KeyCard[i] > secondPlayerHandCard.KeyCard[i])
                    {
                        winner = _firstPlayerName;
                        keyCard = $", High Card {firstPlayerHandCard.KeyCard[i]}";
                        winnerCategory = _categoryLookup[firstPlayerHandCard.Category];
                        break;
                    }

                    if (firstPlayerHandCard.KeyCard[i] < secondPlayerHandCard.KeyCard[i])
                    {
                        winner = _secondPlayerName;
                        keyCard = $", High Card {secondPlayerHandCard.KeyCard[i]}";
                        winnerCategory = _categoryLookup[secondPlayerHandCard.Category];
                        break;
                    }

                    if (i == firstPlayerHandCard.KeyCard.Count - 1)
                    {
                        return "End in a tie";
                    }
                }
            }

            if (firstPlayerHandCard.Category - secondPlayerHandCard.Category < 0)
            {
                winner = _secondPlayerName;
                winnerCategory = _categoryLookup[secondPlayerHandCard.Category];
            }

            return $"{winner} Win, Because {winnerCategory}{keyCard}";
        }
    }
}