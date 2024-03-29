﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands;

public class HandCardComparer : IComparer<HandCard>
{
    private readonly Dictionary<Suit, string> _suitLookup = new()
    {
        { ShowHands.Suit.C, "Club" },
        { ShowHands.Suit.S, "Spades" },
        { ShowHands.Suit.D, "Diamond" },
        { ShowHands.Suit.H, "Heart" }
    };

    public string Suit { get; set; }

    public int KeyCard { get; set; }
    public Category Category { get; set; }

    public int Compare(HandCard x, HandCard y)
    {
        if (x.GetCategory() == y.GetCategory())
        {
            Category = x.GetCategory();
            switch (Category)
            {
                case Category.HighCard:
                    return HighCardCompare(x, y);

                case Category.TwoPair:
                    return TwoPairCompare(x, y);

                case Category.OnePair:
                case Category.Straight:
                    return KeyCardRankCompare(x, y);

                default:
                    return NormalCompare(x, y);
            }
        }

        return CategoryCompare(x, y);
    }

    private int CategoryCompare(HandCard x, HandCard y)
    {
        Category = (Category)Math.Max((int)x.GetCategory(), (int)y.GetCategory());
        return x.GetCategory() - y.GetCategory();
    }

    private int NormalCompare(HandCard x, HandCard y)
    {
        if (KeyCardRankCompare(x, y) == 0)
        {
            if (x.GetKeyCard().OrderBy(c => c.Rank).Last().Suit -
                y.GetKeyCard().OrderBy(c => c.Rank).Last().Suit > 0)
                Suit = x.GetSuit();
            else
                Suit = y.GetSuit();

            return x.GetKeyCard().OrderBy(c => c.Rank).Last().Suit -
                   y.GetKeyCard().OrderBy(c => c.Rank).Last().Suit;
        }

        return KeyCardRankCompare(x, y);
    }

    private int TwoPairCompare(HandCard x, HandCard y)
    {
        if (KeyCardRankCompare(x, y) == 0)
        {
            if (x.GetKeyCard().First().Suit - y.GetKeyCard().First().Suit > 0) Suit = x.GetSuit();

            if (y.GetKeyCard().First().Suit - x.GetKeyCard().First().Suit > 0) Suit = y.GetSuit();

            return x.GetKeyCard().First().Suit - y.GetKeyCard().First().Suit;
        }

        return KeyCardRankCompare(x, y);
    }

    private int HighCardCompare(HandCard x, HandCard y)
    {
        var first = x.GetKeyCard().Zip(
            y.GetKeyCard(),
            (c, d) =>
            {
                if (c.Rank == d.Rank && c.Suit == d.Suit)
                    return Tuple.Create(0, c);
                if (c.Rank == d.Rank && c.Suit > d.Suit)
                    return Tuple.Create(c.Suit - d.Suit, c);
                if (c.Rank == d.Rank && d.Suit > c.Suit)
                    return Tuple.Create(c.Suit - d.Suit, d);
                return Tuple.Create(c.Rank - d.Rank, c);
            }).First(k => k.Item1 != 0);
        if (first != null)
        {
            Suit = _suitLookup[first.Item2.Suit];
            return first.Item1;
        }

        return 0;
    }

    private int KeyCardRankCompare(HandCard firstPlayerHandCard, HandCard secondPlayerHandCard)
    {
        var result = firstPlayerHandCard.GetKeyCard()
            .Zip(secondPlayerHandCard.GetKeyCard(),
                (x, y) =>
                    Tuple.Create(x.Rank - y.Rank, x.Rank, y.Rank)
            ).FirstOrDefault(x => x.Item1 != 0);

        if (result == null) return 0;
        KeyCard = Math.Max(result.Item2, result.Item3);
        return result.Item1;
    }
}