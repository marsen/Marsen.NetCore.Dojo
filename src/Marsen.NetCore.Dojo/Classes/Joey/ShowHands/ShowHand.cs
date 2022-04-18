using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Classes.Joey.ShowHands;

public class ShowHand
{
    private readonly Dictionary<Category, string> _categoryLookup = new()
    {
        { Category.StraightFlush, "Straight Flush" },
        { Category.Flush, "Flush" },
        { Category.FourOfAKind, "Four Of a Kind" },
        { Category.ThreeOfAKind, "Three Of a Kind" },
        { Category.Straight, "Straight" },
        { Category.TwoPair, "Two Pair" },
        { Category.OnePair, "One Pair" },
        { Category.HighCard, "High Card" }
    };

    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;

    public ShowHand(string firstPlayerName, string secondPlayerName)
    {
        _firstPlayerName = firstPlayerName;
        _secondPlayerName = secondPlayerName;
    }

    public string Duel(string firstPlayerCard, string secondPlayerCard)
    {
        var comparer = new HandCardComparer();
        var compareResult = comparer.Compare(GetHandCard(firstPlayerCard), GetHandCard(secondPlayerCard));
        return compareResult == 0
            ? "End in a tie"
            : $"{GetWinner(compareResult)} Win, Because {_categoryLookup[comparer.Category]}{GetKeyCardInfo(comparer)}";
    }

    private HandCard GetHandCard(string firstPlayerCard)
    {
        return new HandCard(new CardParser().Parse(firstPlayerCard));
    }

    private string GetWinner(int compare)
    {
        return compare > 0 ? _firstPlayerName : _secondPlayerName;
    }

    private string GetKeyCardInfo(HandCardComparer comparer)
    {
        return comparer.KeyCard > 0 ? KeyCardInfo(comparer) : SuitInfo(comparer);
    }

    private static string SuitInfo(HandCardComparer comparer)
    {
        return string.IsNullOrEmpty(comparer.Suit) ? string.Empty : $", And {comparer.Suit}";
    }

    private string KeyCardInfo(HandCardComparer comparer)
    {
        return $", Key Card {KeyCardDisplay(comparer.KeyCard)}";
    }

    private string KeyCardDisplay(int firstKeyCard)
    {
        if (firstKeyCard < 11 && firstKeyCard > 1) return firstKeyCard.ToString();

        var rankLookup = new Dictionary<int, string>
        {
            { 14, "A" },
            { 13, "K" },
            { 12, "Q" },
            { 11, "J" }
        };
        return rankLookup[firstKeyCard];
    }
}