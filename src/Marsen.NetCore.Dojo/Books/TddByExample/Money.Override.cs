using System;

namespace Marsen.NetCore.Dojo.Books.TddByExample;

public partial class Money
{
    private readonly int _hashCode = 0;
    public override string ToString()
    {
        return $"{Amount.ToString()} {Currency}";
    }

    public override bool Equals(object obj)
    {
        var money = (Money)obj!;
        return Amount == money.Amount && Currency == money.Currency;
    }

    public override int GetHashCode()
    {
        return _hashCode.GetHashCode();
    }
}