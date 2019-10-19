using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsen.NetCore.Dojo.Kata_ShowHands
{
    public class HandCardComparer : IComparer<HandCard>
    {
        public int Compare(HandCard x, HandCard y)
        {
            if (x.GetCategory() == y.GetCategory())
            {
                Category = x.GetCategory();
                if (Category == Category.StraightFlush)
                {
                    if (KeyCardCompare(x, y) == 0)
                    {
                        Suit = x.GetSuit();
                        return 1;
                    }
                }

                return KeyCardCompare(x, y);
            }

            Category = (Category) Math.Max((int) x.GetCategory(), (int) y.GetCategory());
            return x.GetCategory() - y.GetCategory();
        }

        public string Suit { get; set; }

        private int KeyCardCompare(HandCard firstPlayerHandCard, HandCard secondPlayerHandCard)
        {
            var result = firstPlayerHandCard.GetKeyCard()
                .Zip(secondPlayerHandCard.GetKeyCard(),
                    (x, y) =>
                        Tuple.Create<int, int, int>(x - y, x, y)
                ).FirstOrDefault(x => x.Item1 != 0);

            if (result == null) return 0;
            KeyCard = Math.Max(result.Item2, result.Item3);
            return result.Item1;
        }

        public int KeyCard { get; set; }
        public Category Category { get; set; }
    }
}