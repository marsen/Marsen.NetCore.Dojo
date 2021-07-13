using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Extend
{
    public static class Collection
    {
        private static readonly Random Rng = new();

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            return list.OrderBy(_ => Rng.Next());
        }
    }
}