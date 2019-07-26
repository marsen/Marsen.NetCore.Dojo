using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class CardParser
    {
        public List<Card> Parse(string cards)
        {
            return cards.Split(',').Select(x => new Card
            {
                Rank = ParseRank(x.Substring(1)),
                Suit = Enum.Parse<SuitEnum>(x.Substring(0, 1))
            }).ToList();
        }

        private int ParseRank(string x)
        {
            if (int.TryParse(x, out int result) == false)
            {
                var rankLookup = new Dictionary<string, int>
                {
                    {"A", 14},
                    {"K", 13},
                    {"Q", 12},
                    {"J", 11},
                };

                return rankLookup[x];
            }

            return result;
            if (x == "A")
            {
                return 14;
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