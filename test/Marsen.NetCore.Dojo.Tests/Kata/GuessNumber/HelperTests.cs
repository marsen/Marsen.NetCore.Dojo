using System.Linq;
using System.Text.RegularExpressions;
using Marsen.NetCore.Dojo.Kata.GuessNumber;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.GuessNumber
{
    public class HelperTests
    {
        private readonly RandomHelper _randomHelper = new();


        [Fact]
        public void TestRandomNumberShouldAllBeNumber()
        {
            Assert.Matches(new Regex("^\\d{4}$"), _randomHelper.GetNonRepeatInt(4));
        }

        [Fact]
        public void TestRandomNumberShouldUnique()
        {
            var answer = _randomHelper.GetNonRepeatInt(4);
            var originCount = answer.Length;
            var afterDistinct = answer.Distinct().Count();
            Assert.Equal(originCount, afterDistinct);
        }
    }
}