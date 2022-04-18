﻿using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules;

public class TwoPair : ICategoryRule
{
    public bool Apply(List<Card> cardList)
    {
        return cardList
            .GroupBy(x => x.Rank)
            .Select(g => new { Count = g.Count(), Rank = g.Key }).Count(x => x.Count == 2) == 2;
    }

    public Category Category => Category.TwoPair;
}