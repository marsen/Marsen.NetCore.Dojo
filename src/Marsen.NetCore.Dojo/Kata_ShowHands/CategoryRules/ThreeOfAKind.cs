using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public class ThreeOfAKind : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().Any(x => x.Count == 3);
        }

        public Category Category => Category.ThreeOfAKind;
    }
}