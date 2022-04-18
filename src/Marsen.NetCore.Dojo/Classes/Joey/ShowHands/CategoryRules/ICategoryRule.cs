using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules
{
    public interface ICategoryRule
    {
        Category Category { get; }
        bool Apply(List<Card> cardList);
    }
}