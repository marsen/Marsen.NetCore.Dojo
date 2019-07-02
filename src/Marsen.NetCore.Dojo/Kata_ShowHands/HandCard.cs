using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
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
                .Select(g => new {Count = g.Count()});
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