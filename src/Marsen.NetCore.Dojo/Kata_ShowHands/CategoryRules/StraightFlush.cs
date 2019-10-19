﻿using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules
{
    public class StraightFlush : ICategoryRule
    {
        public bool Apply(List<Card> cardList)
        {
            return new Straight().Apply(cardList) && new Flush().Apply(cardList);
        }

        public Category Category => Category.StraightFlush;
    }
}