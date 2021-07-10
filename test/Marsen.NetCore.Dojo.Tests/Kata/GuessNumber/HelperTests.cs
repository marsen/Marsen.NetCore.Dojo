using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class HelperTests
    {
        private readonly RandomNumber _randomNumber = new();
        [Fact]
        public void TestRandomNumberLengthShouldBe4()
        {
            //TODO Combine Two case 
            Assert.Equal(4, _randomNumber.Get(4).Length);
        }

        [Fact]
        public void TestRandomNumberShouldAllBeNumber()
        {
            Assert.Matches(new Regex("\\d+"), _randomNumber.Get(4));
        }

        [Fact]
        public void TestRandomNumberShouldUnique()
        {
            var answer = _randomNumber.Get(4);
            var originCount = answer.Length;
            var afterDistinct = answer.Distinct().Count();
            Assert.Equal(originCount, afterDistinct);
        }
    }
}