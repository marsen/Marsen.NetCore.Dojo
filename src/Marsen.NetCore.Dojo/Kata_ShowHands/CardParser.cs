using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class CardParser
    {
        private bool isAceBe14;

        public List<Card> Parse(string cards)
        {
            this.isAceBe14 = string.Join(',', cards.Split(',').Select(x => x.Substring(1)).OrderBy(x => x).ToList())
                .Contains("10,A,J,K,Q");
            return cards.Split(',').Select(x => new Card
            {
                Rank = ParseRank(x.Substring(1)),
                Suit = Enum.Parse<SuitEnum>(x.Substring(0, 1))
            }).ToList();
        }

        private int ParseRank(string x)
        {
            if (x == "A")
            {
                return isAceBe14 ? 14 : 1;
            }

            if (x == "K")
            {
                return 13;
            }

            if (x == "Q")
            {
                return 12;
            }

            if (x == "J")
            {
                return 11;
            }

            return int.Parse(x);
        }
    }
}