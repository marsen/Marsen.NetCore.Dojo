using Marsen.NetCore.Dojo.Classes.Joey.ShowHands.CategoryRules;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands
{
    public class HandCard
    {
        private readonly List<Card> _cardList;

        public HandCard(List<Card> parse)
        {
            this._cardList = parse;
        }

        private readonly List<ICategoryRule> _categoryRules = new List<ICategoryRule>
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

        public Category GetCategory()
        {
            return this._categoryRules.First(x => x.Apply(this._cardList)).Category;
        }

        public IEnumerable<Card> GetKeyCard()
        {
            return this._cardList
                .GroupBy(x => x.Rank)
                .OrderBy(x => x.Count())
                .ThenByDescending(x => x.Key)
                .Select(x => new Card {Rank = x.Key, Suit = x.Max(y => y.Suit)});
        }

        public string GetSuit()
        {
            var suitLookup = new Dictionary<Suit, string>
            {
                {Suit.C, "Club"},
                {Suit.S, "Spades"},
                {Suit.D, "Diamond"},
                {Suit.H, "Heart"},
            };
            if (this.GetCategory() == Category.StraightFlush)
            {
                return suitLookup[this._cardList[0].Suit];
            }

            if (this.GetCategory() == Category.FourOfAKind || this.GetCategory() == Category.Flush)
            {
                return suitLookup[this._cardList.GroupBy(x => x.Rank).Last().First().Suit];
            }

            if (this.GetCategory() == Category.TwoPair)
            {
                return suitLookup[this._cardList.GroupBy(x => x.Rank).OrderBy(x => x.Count()).First().First().Suit];
            }

            // HighCard 
            return suitLookup[this._cardList.OrderBy(x => x.Rank).Last().Suit];
        }
    }
}