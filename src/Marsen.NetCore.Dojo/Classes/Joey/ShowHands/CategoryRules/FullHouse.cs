using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules
{
    public class FullHouse : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.Rank).Any(x => x.Count() == 3) &&
                   cardList.GroupBy(x => x.Rank).Any(x => x.Count() == 2);
        }

        public Category Category => Category.FullHouse;
    }
}