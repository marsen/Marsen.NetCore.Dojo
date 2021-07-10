using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class HelperTests
    {
        private readonly Helper _helper = new();
        [Fact]
        public void TestRandomNumberLengthShouldBe4()
        {
            //TODO Combine Two case 
            Assert.Equal(4, _helper.GetRandomNumber(4).Length);
        }

        [Fact]
        public void TestRandomNumberShouldAllBeNumber()
        {
            Assert.Matches(new Regex("\\d+"), _helper.GetRandomNumber(4));
        }

        [Fact]
        public void TestRandomNumberShouldUnique()
        {
            var answer = _helper.GetRandomNumber(4);
            var originCount = answer.Length;
            var afterDistinct = answer.Distinct().Count();
            Assert.Equal(originCount, afterDistinct);
        }
    }
}