using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class CardParser
    {
        public List<Card> Parse(string cards)
        {
            return cards.Split(',').Select(x => new Card
            {
                Rank = int.Parse(x.Substring(1)),
                Suit = Enum.Parse<SuitEnum>(x.Substring(0, 1))
            }).ToList();
        }
    }
}