﻿using System.Linq;
using System.Text;
using Marsen.NetCore.Dojo.Common;

namespace Marsen.NetCore.Dojo.Classes.Joey.TddAndRefactor2005.Plus;

public class CharRepeater
{
    public string Repeat(string input)
    {
        if (string.IsNullOrEmpty(input)) throw new DojoException("input should not be null or empty");

        var list = input.Select((c, index) => c.ToString().ToUpper() + Repeat(c.ToString(), index).ToLower());
        return string.Join('-', list);
    }

    private string Repeat(string substring, int times)
    {
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < times; i++) stringBuilder.Append(substring);

        return stringBuilder.ToString();
    }
}