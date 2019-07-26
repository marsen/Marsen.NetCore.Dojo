using System.Text;
using Marsen.NetCore.Dojo.Kata_ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ShowHands
{
    public class ShowHandTests
    {
        ShowHand showHand = new ShowHand("Tom", "Lee");

        [Fact]
        public void FourOfAKind_ThreeOfAKind()
        {
            var actual = showHand.Duel("S3,C3,D3,H3,H7", "S3,C3,D3,H7,H8");
            Assert.Equal("Tom Win, Because Four Of a Kind", actual);
        }


        [Fact]
        public void TwoPairs_ThreeOfAKind()
        {
            var actual = showHand.Duel("S3,C3,D5,H5,H7", "S3,C3,D3,H7,H8");
            Assert.Equal("Lee Win, Because Three Of a Kind", actual);
        }

        [Fact]
        public void ThreeOfAKind_ThreeOfAKind_With_Key_Card_6()
        {
            var actual = showHand.Duel("S3,C4,D5,H5,C5", "S3,C4,D6,H6,C6");
            Assert.Equal("Lee Win, Because Three Of a Kind, Key Card 6", actual);
        }

        [Fact]
        public void ThreeOfAKind_ThreeOfAKind_End_In_A_Tie()
        {
            var actual = showHand.Duel("S3,C4,D6,H6,C6", "S3,C4,D6,H6,C6");
            Assert.Equal("End in a tie", actual);
        }

        [Fact]
        public void TwoPair_TwoPair_With_Key_Card_9()
        {
            var actual = showHand.Duel("S4,C4,D5,H5,C7", "S4,C4,D5,S5,S9");
            Assert.Equal("Lee Win, Because Two Pair, Key Card 9", actual);
        }

        [Fact]
        public void TwoPair_TwoPair()
        {
            var actual = showHand.Duel("S4,C4,D5,H5,C7", "S4,C4,D5,S5,S7");
            Assert.Equal("End in a tie", actual);
        }


        [Fact]
        public void TwoPair_OnePair()
        {
            var actual = showHand.Duel("S4,C4,D5,H5,C7", "S4,C4,D5,S6,S7");
            Assert.Equal("Tom Win, Because Two Pair", actual);
        }

        [Fact]
        public void OnePair_HighCard()
        {
            var actual = showHand.Duel("S2,C4,D5,H9,C7", "S4,C4,D5,S6,S7");
            Assert.Equal("Lee Win, Because One Pair", actual);
        }

        [Fact]
        public void ThreeOfAKind_Straight()
        {
            var actual = showHand.Duel("S2,C4,D9,H9,C9", "S8,C4,D5,S6,S7");
            Assert.Equal("Lee Win, Because Straight", actual);
        }

        [Fact]
        public void Straight_Flush()
        {
            var actual = showHand.Duel("S8,C4,D5,S6,S7", "S2,S4,S9,S6,S5");
            Assert.Equal("Lee Win, Because Flush", actual);
        }

        [Fact]
        public void StraightFlush_StraightFlush_With_Key_Card_K()
        {
            var actual = showHand.Duel("SA,SK,SJ,S10,SQ", "S2,S4,SA,S3,S5");
            Assert.Equal("Tom Win, Because Straight Flush, Key Card K", actual);
        }

        [Fact]
        public void StraightFlush_StraightFlush_With_Key_Card_Q()
        {
            var actual = showHand.Duel("D9,D8,D7,D5,D6", "S9,S8,SJ,S10,SQ");
            Assert.Equal("Lee Win, Because Straight Flush, Key Card Q", actual);
        }

        [Fact]
        public void StraightFlush_StraightFlush_With_Key_Card_J()
        {
            var actual = showHand.Duel("D9,D8,D10,DJ,D7", "S9,S8,S7,S10,S6");
            Assert.Equal("Tom Win, Because Straight Flush, Key Card J", actual);
        }
    }
}