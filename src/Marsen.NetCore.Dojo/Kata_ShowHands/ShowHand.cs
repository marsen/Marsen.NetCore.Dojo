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
            {Category.HighCard, "High Card"},
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
            var comparer = new HandCardComparer();
            var compare = comparer.Compare(new HandCard(cardParser.Parse(firstPlayerCard)),
                new HandCard(cardParser.Parse(secondPlayerCard)));
            return compare == 0
                ? "End in a tie"
                : $"{this.GetWinner(compare)} Win, Because {this._categoryLookup[comparer.Category]}{this.GetKeyCardInfo(comparer.KeyCard)}";
        }

        private string GetWinner(int compare)
        {
            return compare > 0 ? _firstPlayerName : _secondPlayerName;
        }

        private string GetKeyCardInfo(int keyCard)
        {
            return keyCard > 0 ? $", Key Card {KeyCardDisplay(keyCard)}" : string.Empty;
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
    }
}