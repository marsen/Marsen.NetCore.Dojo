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

        public ShowHand(string firstPlayerName, string secondPlayerName)
        {
            this._firstPlayerName = firstPlayerName;
            this._secondPlayerName = secondPlayerName;
        }

        public string Duel(string firstPlayerCard, string secondPlayerCard)
        {
            var comparer = new HandCardComparer();
            var compareResult = comparer.Compare(this.GetHandCard(firstPlayerCard), this.GetHandCard(secondPlayerCard));
            return compareResult == 0
                ? "End in a tie"
                : $"{this.GetWinner(compareResult)} Win, Because {this._categoryLookup[comparer.Category]}{this.GetKeyCardInfo(comparer)}";
        }

        private HandCard GetHandCard(string firstPlayerCard)
        {
            return new HandCard(new CardParser().Parse(firstPlayerCard));
        }

        private string GetWinner(int compare)
        {
            return compare > 0 ? _firstPlayerName : _secondPlayerName;
        }

        private string GetKeyCardInfo(HandCardComparer comparer)
        {
            return comparer.KeyCard > 0             ? $", Key Card {KeyCardDisplay(comparer.KeyCard)}" :
                string.IsNullOrEmpty(comparer.Suit) ? string.Empty : $", And {comparer.Suit}";
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