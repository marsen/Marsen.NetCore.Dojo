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
    }
}