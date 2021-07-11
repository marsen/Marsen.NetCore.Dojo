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
            //TODO Rename Test Case
            var length = 4;
            Assert.Matches(new Regex($"^\\d{{{length}}}$"), _randomHelper.GetNonRepeatInt(length));
        }

        [Fact]
        public void TestRandomNumberShouldUnique()
        {
            //TODO Combine the test Case
            var answer = _randomHelper.GetNonRepeatInt(4);
            Assert.Equal(answer.Length, answer.Distinct().Count());
        }
    }
}