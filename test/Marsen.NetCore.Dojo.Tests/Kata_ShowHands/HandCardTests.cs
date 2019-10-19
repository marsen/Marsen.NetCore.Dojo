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


        [Fact]
        public void Straight_Flush()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 7, Suit = SuitEnum.S},
                new Card {Rank = 8, Suit = SuitEnum.S},
                new Card {Rank = 9, Suit = SuitEnum.S},
                new Card {Rank = 10, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.StraightFlush;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void FullHouse()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 6, Suit = SuitEnum.H},
                new Card {Rank = 9, Suit = SuitEnum.C},
                new Card {Rank = 9, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.FullHouse;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeOfAKind()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 6, Suit = SuitEnum.H},
                new Card {Rank = 8, Suit = SuitEnum.C},
                new Card {Rank = 9, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.ThreeOfAKind;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoPair()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 8, Suit = SuitEnum.H},
                new Card {Rank = 8, Suit = SuitEnum.C},
                new Card {Rank = 9, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.TwoPair;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePair()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 8, Suit = SuitEnum.H},
                new Card {Rank = 7, Suit = SuitEnum.C},
                new Card {Rank = 9, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.OnePair;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Straight()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 5, Suit = SuitEnum.S},
                new Card {Rank = 6, Suit = SuitEnum.C},
                new Card {Rank = 8, Suit = SuitEnum.H},
                new Card {Rank = 7, Suit = SuitEnum.C},
                new Card {Rank = 9, Suit = SuitEnum.S},
            });
            var actual = target.GetCategory();
            Category expected = Category.Straight;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Flush()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 6, Suit = SuitEnum.H},
                new Card {Rank = 6, Suit = SuitEnum.H},
                new Card {Rank = 8, Suit = SuitEnum.H},
                new Card {Rank = 7, Suit = SuitEnum.H},
                new Card {Rank = 9, Suit = SuitEnum.H},
            });
            var actual = target.GetCategory();
            Category expected = Category.Flush;
            Assert.Equal(expected, actual);
        }


        [Fact(DisplayName = "DA,D2,D3,D4,D5同花順的花色為方塊")]
        public void DiamondStraightFlush()
        {
            var target = new HandCard(new List<Card>
            {
                new Card {Rank = 1, Suit = SuitEnum.D},
                new Card {Rank = 2, Suit = SuitEnum.D},
                new Card {Rank = 3, Suit = SuitEnum.D},
                new Card {Rank = 4, Suit = SuitEnum.D},
                new Card {Rank = 5, Suit = SuitEnum.D},
            });
            var actual = target.GetSuit();
            var expected = "Diamond";
            Assert.Equal(expected, actual);
        }
    }
}