﻿using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public interface ICategoryRule
    {
        bool Apply(List<Card> cardList);
    }
}