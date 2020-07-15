using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContextTests
    {
        readonly TennisGameContext _tennisGameContext = new TennisGameContext(new LoveAll());

        [Fact]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [Fact]
        public void Fifteen_Love()
        {
            _tennisGameContext.State.ServerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void Love_Fifteen()
        {
            _tennisGameContext.State.ReceiverScore();
            ScoreShouldBe("Love Fifteen");
        }

        [Fact]
        public void Love_Thirty()
        {
            _tennisGameContext.State.ReceiverScore();
            _tennisGameContext.State.ReceiverScore();
            ScoreShouldBe("Love Thirty");
        }

        [Fact]
        public void Love_Forty()
        {
            _tennisGameContext.State.ReceiverScore();
            _tennisGameContext.State.ReceiverScore();
            _tennisGameContext.State.ReceiverScore();
            ScoreShouldBe("Love Forty");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _tennisGameContext.Score());
        }
    }
}