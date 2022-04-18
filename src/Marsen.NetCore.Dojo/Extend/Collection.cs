using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Extend;

public static class Collection
{
    private static readonly Random Rng = new();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        //This is Fisher–Yates shuffle
        var buffer = source.ToList();
        for (var i = 0; i < buffer.Count; i++)
        {
            var j = Rng.Next(i, buffer.Count);
            yield return buffer[j];
            buffer[j] = buffer[i];
        }
    }
}