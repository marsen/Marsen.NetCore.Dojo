using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class HandCard
    {
        private readonly List<Card> _cardList;

        private const string allCard = "1,2,3,4,5,6,7,8,9,10,J,Q,K";

        public HandCard(List<Card> parse)
        {
            this._cardList = parse;
        }


        public List<int> KeyCard { get; set; }

        public Category GetCategory()
        {
            var groupCards = this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key});
            var enumerable = groupCards.ToList();
            this.KeyCard = enumerable.OrderBy(x => x.Count).Select(x => x.Rank).ToList();
            if (IsFlush())
            {
                return Category.Flush;
            }

            if (enumerable.Any(x => x.Count == 4))
            {
                return Category.FourOfAKind;
            }

            if (allCard.Contains(string.Join(',', this._cardList.OrderBy(x => x.Rank).Select(x => x.Rank))))
            {
                return Category.Straight;
            }

            if (enumerable.Any(x => x.Count == 3))
            {
                return Category.ThreeOfAKind;
            }

            if (enumerable.Count(x => x.Count == 2) == 2)
            {
                return Category.TwoPair;
            }

            if (enumerable.Count(x => x.Count == 2) == 1)
            {
                return Category.OnePair;
            }

            return Category.HighCard;
        }

        private bool IsFlush()
        {
            return this._cardList.GroupBy(x => x.Suit).Count() == 1;
        }
    }
}