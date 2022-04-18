using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Books.TddByExample;

public class Bank
{
    private readonly Dictionary<string, int> _rateLookup = new();

    public Money reduce(IExpression expression, string currency)
    {
        if (expression.GetType() == typeof(Sum)) expression = (Sum)expression;

        return expression.Reduce(this, currency);
    }

    public void addRate(string chf, string usd, int i)
    {
        _rateLookup.Add($"{chf}{usd}", i);
    }

    public int rate(string from, string to)
    {
        return from == to ? 1 : _rateLookup[$"{from}{to}"];
    }
}