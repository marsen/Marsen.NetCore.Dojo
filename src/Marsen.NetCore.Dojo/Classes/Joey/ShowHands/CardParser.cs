using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands
{
    public class CardParser
    {
        private readonly Dictionary<string, int> _rankLookup = new()
        {
            { "A", 14 },
            { "K", 13 },
            { "Q", 12 },
            { "J", 11 }
        };

        public List<Card> Parse(string cards)
        {
            return cards.Split(',').Select(x => new Card
            {
                Rank = ParseRank(x.Substring(1)),
                Suit = Enum.Parse<Suit>(x.Substring(0, 1))
            }).ToList();
        }

        private int ParseRank(string x)
        {
            return int.TryParse(x, out var result) ? result : _rankLookup[x];
        }
    }
}