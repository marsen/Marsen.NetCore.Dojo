using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public class HighCard : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return true;
        }

        public Category Category => Category.HighCard;
    }
}