using System.Collections.Generic;
using Marsen.NetCore.Dojo.Kata_ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ShowHands
{
    public class HandCardTests
    {
        [Fact]
        public void FourOfAKind()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.H},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 6, Suit = SuitEnum.D},
                new Card {Rank = 8, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.FourOfAKind;
            Assert.Equal(expected, actual);
        }
    }
}