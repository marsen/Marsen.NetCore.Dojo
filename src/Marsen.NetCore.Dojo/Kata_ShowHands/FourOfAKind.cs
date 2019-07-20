using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class FourOfAKind : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().Any(x => x.Count == 4);
        }

        public Category Category => Category.FourOfAKind;
    }
}