using System.Collections.Generic;

namespace Marsen.NetCore.Dojo.Kata.FooBarQix;

public class ContainRule
{
    private readonly Dictionary<char, string> _charLookup = new()
    {
        { '3', "Foo" },
        { '5', "Bar" },
        { '7', "Qix" }
    };

    private readonly int _i;

    public ContainRule(int i)
    {
        _i = i + 48;
    }

    public string Apply(char c, string result)
    {
        if (c == _i) result += _charLookup[c];

        return result;
    }
}