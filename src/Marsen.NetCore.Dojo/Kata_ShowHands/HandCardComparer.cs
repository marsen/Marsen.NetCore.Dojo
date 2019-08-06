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
                return KeyCardCompare(x, y);
            }

            return x.GetCategory() - y.GetCategory();
        }

        private int KeyCardCompare(HandCard firstPlayerHandCard, HandCard secondPlayerHandCard)
        {
            var result = firstPlayerHandCard.GetKeyCard()
                .Zip(secondPlayerHandCard.GetKeyCard(),
                    (x, y) =>
                        Tuple.Create<int, int, int>(x - y, x, y)
                ).FirstOrDefault(x => x.Item1 != 0);

            if (result != null)
            {
                KeyCard = Math.Max(result.Item2, result.Item3);
                if (result.Item2 > result.Item3)
                {
                    Category = firstPlayerHandCard.GetCategory();
                }
                else
                {
                    Category = secondPlayerHandCard.GetCategory();
                }

                return result.Item1;
            }

            return 0;
        }

        public int KeyCard { get; set; }
        public Category Category { get; set; }
    }
}