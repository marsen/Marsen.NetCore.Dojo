using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContextTests
    {
        [Fact]
        public void Love_All()
        {
            TennisGameContext tennisGameContext = new TennisGameContext();
            var score = tennisGameContext.Score();
            Assert.Equal("Love All",score);
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