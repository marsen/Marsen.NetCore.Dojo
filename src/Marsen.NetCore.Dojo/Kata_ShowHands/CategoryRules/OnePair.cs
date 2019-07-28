using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public class OnePair : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                       .GroupBy(x => x.Rank)
                       .Select(g => new {Count = g.Count(), Rank = g.Key}).Count(x => x.Count == 2) == 1;
        }

        public Category Category => Category.OnePair;
    }
}