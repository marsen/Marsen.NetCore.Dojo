﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class HandCard
    {
        private readonly List<Card> _cardList;

        private const string allCard = "1,2,3,4,5,6,7,8,9,10,J,Q,K";

        public HandCard(List<Card> parse)
        {
            this._cardList = parse;
        }


        public List<int> KeyCard { get; set; }

        public Category GetCategory()
        {
            this.KeyCard = this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().OrderBy(x => x.Count).Select(x => x.Rank)
                .ToList();
            if (IsFlush(this._cardList))
            {
                return Category.Flush;
            }

            if (IsFourOfAKind())
            {
                return Category.FourOfAKind;
            }

            if (IsStraight())
            {
                return Category.Straight;
            }

            if (IsThreeOfAKind())
            {
                return Category.ThreeOfAKind;
            }

            if (IsTwoPair())
            {
                return Category.TwoPair;
            }

            if (IsOnePair())
            {
                return Category.OnePair;
            }

            return Category.HighCard;
        }

        protected virtual bool IsOnePair()
        {
            return this._cardList
                       .GroupBy(x => x.Rank)
                       .Select(g => new {Count = g.Count(), Rank = g.Key}).Count(x => x.Count == 2) == 1;
        }

        protected virtual bool IsTwoPair()
        {
            return this._cardList
                       .GroupBy(x => x.Rank)
                       .Select(g => new {Count = g.Count(), Rank = g.Key}).Count(x => x.Count == 2) == 2;
        }

        protected virtual bool IsThreeOfAKind()
        {
            return this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().Any(x => x.Count == 3);
        }

        private bool IsStraight()
        {
            return allCard.Contains(string.Join(',', this._cardList.OrderBy(x => x.Rank).Select(x => x.Rank)));
        }

        protected virtual bool IsFourOfAKind()
        {
            return this._cardList
                .GroupBy(x => x.Rank)
                .Select(g => new {Count = g.Count(), Rank = g.Key}).ToList().Any(x => x.Count == 4);
        }

        private bool IsFlush(List<Card> cardList)
        {
            return cardList.GroupBy(x => x.Suit).Count() == 1;
        }
    }
}