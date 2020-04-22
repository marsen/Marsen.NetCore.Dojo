using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules
{
    public interface ICategoryRule
    {
        bool Apply(List<Card> cardList);
        Category Category { get; }
    }
}