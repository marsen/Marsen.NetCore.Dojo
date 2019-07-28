using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public interface ICategoryRule
    {
        bool Apply(List<Card> cardList);
        Category Category { get; }
    }
}