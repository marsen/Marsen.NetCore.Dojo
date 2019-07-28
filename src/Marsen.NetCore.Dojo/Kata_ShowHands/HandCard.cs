﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Marsen.NetCore.Dojo.Kata_ShowHands.CategoryRules;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
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

        public IEnumerable<int> GetKeyCard()
        {
            return this._cardList
                .GroupBy(x => x.Rank)
                .OrderBy(x => x.Count())
                .ThenByDescending(x => x.Key)
                .Select(x => x.Key);
        }
    }
}