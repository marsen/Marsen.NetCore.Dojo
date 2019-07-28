using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public class Flush : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.Suit).Count() == 1;
        }

        public Category Category => Category.Flush;
    }
}