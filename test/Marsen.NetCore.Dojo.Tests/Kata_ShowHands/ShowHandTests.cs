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
            var actual = showHand.Duel("S3,C3,D5,H5,C5", "S3,C3,D6,H6,C6");
            Assert.Equal("Lee Win, Because Three Of a Kind, Key Card 6", actual);
        }

        [Fact]
        public void ThreeOfAKind_ThreeOfAKind_End_In_A_Tie()
        {
            var actual = showHand.Duel("S3,C3,D6,H6,C6", "S3,C3,D6,H6,C6");
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
    }
}