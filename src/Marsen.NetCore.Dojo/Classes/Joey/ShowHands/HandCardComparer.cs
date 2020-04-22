using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands
{
    public class HandCardComparer : IComparer<HandCard>
    {
        public int Compare(HandCard x, HandCard y)
        {
            var suitLookup = new Dictionary<SuitEnum, string>
            {
                {SuitEnum.C, "Club"},
                {SuitEnum.S, "Spades"},
                {SuitEnum.D, "Diamond"},
                {SuitEnum.H, "Heart"},
            };

            if (x.GetCategory() == y.GetCategory())
            {
                Category = x.GetCategory();
                if (Category == Category.HighCard)
                {
                    var first = x.GetKeyCard().Zip(
                        y.GetKeyCard(),
                        (c, d) =>
                        {
                            if (c.Rank == d.Rank && c.Suit == d.Suit)
                                return Tuple.Create<int, Card>(0, c);
                            else if (c.Rank == d.Rank && c.Suit > d.Suit)
                                return Tuple.Create<int, Card>(c.Suit - d.Suit, c);
                            else if (c.Rank == d.Rank && d.Suit > c.Suit)
                                return Tuple.Create<int, Card>(c.Suit - d.Suit, d);
                            else
                                return Tuple.Create<int, Card>(c.Rank - d.Rank, c);
                        }).First(k => k.Item1 != 0);
                    if (first != null)
                    {
                        Suit = suitLookup[first.Item2.Suit];
                        return first.Item1;
                    }

                    return 0;
                }

                if (Category == Category.OnePair)
                {
                }

                if (Category == Category.TwoPair && KeyCardRankCompare(x, y) == 0)
                {
                    if (x.GetKeyCard().First().Suit - y.GetKeyCard().First().Suit > 0)
                    {
                        Suit = x.GetSuit();
                        return 1;
                    }

                    if (y.GetKeyCard().First().Suit - x.GetKeyCard().First().Suit > 0)
                    {
                        Suit = y.GetSuit();
                        return -1;
                    }
                }

                if (Category == Category.StraightFlush || Category == Category.FourOfAKind ||
                    Category == Category.Flush)
                {
                    if (KeyCardRankCompare(x, y) == 0)
                    {
                        if (x.GetKeyCard().OrderBy(c => c.Rank).Last().Suit -
                            y.GetKeyCard().OrderBy(c => c.Rank).Last().Suit > 0)
                        {
                            Suit = x.GetSuit();
                            return 1;
                        }

                        if (x.GetKeyCard().OrderBy(c => c.Rank).Last().Suit -
                            y.GetKeyCard().OrderBy(c => c.Rank).Last().Suit < 0)
                        {
                            Suit = y.GetSuit();
                            return -1;
                        }

                        return 0;
                    }
                }

                return KeyCardRankCompare(x, y);
            }

            Category = (Category) Math.Max((int) x.GetCategory(), (int) y.GetCategory());
            return x.GetCategory() - y.GetCategory();
        }

        public string Suit { get; set; }

        private int KeyCardRankCompare(HandCard firstPlayerHandCard, HandCard secondPlayerHandCard)
        {
            var result = firstPlayerHandCard.GetKeyCard()
                .Zip(secondPlayerHandCard.GetKeyCard(),
                    (x, y) =>
                        Tuple.Create<int, int, int>(x.Rank - y.Rank, x.Rank, y.Rank)
                ).FirstOrDefault(x => x.Item1 != 0);

            if (result == null) return 0;
            KeyCard = Math.Max(result.Item2, result.Item3);
            return result.Item1;
        }

        public int KeyCard { get; set; }
        public Category Category { get; set; }
    }
}