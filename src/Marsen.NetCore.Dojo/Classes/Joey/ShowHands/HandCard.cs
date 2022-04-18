using System.Collections.Generic;
using System.Linq;
using Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands
{
    public class HandCard
    {
        private readonly List<Card> _cardList;

        private readonly List<ICategoryRule> _categoryRules = new()
        {
            new StraightFlush(),
            new FourOfAKind(),
            new FullHouse(),
            new Flush(),
            new Straight(),
            new ThreeOfAKind(),
            new TwoPair(),
            new OnePair(),
            new HighCard()
        };

        public HandCard(List<Card> parse)
        {
            _cardList = parse;
        }

        public Category GetCategory()
        {
            return _categoryRules.First(x => x.Apply(_cardList)).Category;
        }

        public IEnumerable<Card> GetKeyCard()
        {
            return _cardList
                .GroupBy(x => x.Rank)
                .OrderBy(x => x.Count())
                .ThenByDescending(x => x.Key)
                .Select(x => new Card { Rank = x.Key, Suit = x.Max(y => y.Suit) });
        }

        public string GetSuit()
        {
            var suitLookup = new Dictionary<Suit, string>
            {
                { Suit.C, "Club" },
                { Suit.S, "Spades" },
                { Suit.D, "Diamond" },
                { Suit.H, "Heart" }
            };
            if (GetCategory() == Category.StraightFlush) return suitLookup[_cardList[0].Suit];

            if (GetCategory() == Category.FourOfAKind || GetCategory() == Category.Flush)
                return suitLookup[_cardList.GroupBy(x => x.Rank).Last().First().Suit];

            if (GetCategory() == Category.TwoPair)
                return suitLookup[_cardList.GroupBy(x => x.Rank).OrderBy(x => x.Count()).First().First().Suit];

            // HighCard 
            return suitLookup[_cardList.OrderBy(x => x.Rank).Last().Suit];
        }
    }
}