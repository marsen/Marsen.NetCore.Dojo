using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContextTests
    {
        readonly TennisGameContext _tennisGameContext = new TennisGameContext();
        [Fact]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _tennisGameContext.Score());
        }
    }

    public class TennisGameContext
    {
        public string Score()
        {
            return "Love All";
        }
    }
}