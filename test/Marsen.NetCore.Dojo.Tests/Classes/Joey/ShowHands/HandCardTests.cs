using System.Collections.Generic;
using Marsen.NetCore.Dojo.Classes.Joey.ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.ShowHands
{
    public class HandCardTests
    {
        [Fact]
        public void FourOfAKind()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.H },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 6, Suit = Suit.D },
                new() { Rank = 8, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.FourOfAKind;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Straight_Flush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 7, Suit = Suit.S },
                new() { Rank = 8, Suit = Suit.S },
                new() { Rank = 9, Suit = Suit.S },
                new() { Rank = 10, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.StraightFlush;
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void FullHouse()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 6, Suit = Suit.H },
                new() { Rank = 9, Suit = Suit.C },
                new() { Rank = 9, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.FullHouse;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ThreeOfAKind()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 6, Suit = Suit.H },
                new() { Rank = 8, Suit = Suit.C },
                new() { Rank = 9, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.ThreeOfAKind;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TwoPair()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 8, Suit = Suit.H },
                new() { Rank = 8, Suit = Suit.C },
                new() { Rank = 9, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.TwoPair;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OnePair()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 8, Suit = Suit.H },
                new() { Rank = 7, Suit = Suit.C },
                new() { Rank = 9, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.OnePair;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Straight()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 5, Suit = Suit.S },
                new() { Rank = 6, Suit = Suit.C },
                new() { Rank = 8, Suit = Suit.H },
                new() { Rank = 7, Suit = Suit.C },
                new() { Rank = 9, Suit = Suit.S }
            });
            var actual = target.GetCategory();
            var expected = Category.Straight;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Flush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 6, Suit = Suit.H },
                new() { Rank = 6, Suit = Suit.H },
                new() { Rank = 8, Suit = Suit.H },
                new() { Rank = 7, Suit = Suit.H },
                new() { Rank = 9, Suit = Suit.H }
            });
            var actual = target.GetCategory();
            var expected = Category.Flush;
            Assert.Equal(expected, actual);
        }


        [Fact(DisplayName = "DA,D2,D3,D4,D5同花順的花色為方塊")]
        public void DiamondStraightFlush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 1, Suit = Suit.D },
                new() { Rank = 2, Suit = Suit.D },
                new() { Rank = 3, Suit = Suit.D },
                new() { Rank = 4, Suit = Suit.D },
                new() { Rank = 5, Suit = Suit.D }
            });
            var actual = target.GetSuit();
            var expected = "Diamond";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "SA,S2,S3,S4,S5同花順的花色為黑桃")]
        public void SpadesStraightFlush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 1, Suit = Suit.S },
                new() { Rank = 2, Suit = Suit.S },
                new() { Rank = 3, Suit = Suit.S },
                new() { Rank = 4, Suit = Suit.S },
                new() { Rank = 5, Suit = Suit.S }
            });
            var actual = target.GetSuit();
            var expected = "Spades";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "HA,H2,H3,H4,H5同花順的花色為紅心")]
        public void HeartStraightFlush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 1, Suit = Suit.H },
                new() { Rank = 2, Suit = Suit.H },
                new() { Rank = 3, Suit = Suit.H },
                new() { Rank = 4, Suit = Suit.H },
                new() { Rank = 5, Suit = Suit.H }
            });
            var actual = target.GetSuit();
            var expected = "Heart";
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "CA,C2,C3,C4,C5同花順的花色為梅花")]
        public void ClubStraightFlush()
        {
            var target = new HandCard(new List<Card>
            {
                new() { Rank = 1, Suit = Suit.C },
                new() { Rank = 2, Suit = Suit.C },
                new() { Rank = 3, Suit = Suit.C },
                new() { Rank = 4, Suit = Suit.C },
                new() { Rank = 5, Suit = Suit.C }
            });
            var actual = target.GetSuit();
            var expected = "Club";
            Assert.Equal(expected, actual);
        }
    }
}