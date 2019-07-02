using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class HandCard
    {
        public HandCard(List<Card> parse)
        {
            this.Category = this.GetCategory(parse);
        }

        public Category Category { get; }

        public List<int> KeyCard { get; set; }

        private Category GetCategory(List<Card> cardList)
        {
            var groupCards = cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key});
            this.KeyCard = groupCards.OrderBy(x => x.Count).Select(x => x.Rank).ToList();
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