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
            GivenReceiverPoint(1);
            ScoreShouldBe("Love Fifteen");
        }

        [Fact]
        public void Love_Thirty()
        {
            GivenReceiverPoint(2);
            ScoreShouldBe("Love Thirty");
        }

        [Fact]
        public void Love_Forty()
        {
            GivenReceiverPoint(3);
            ScoreShouldBe("Love Forty");
        }

        [Fact]
        public void Fifteen_All()
        {
            _tennisGameContext.State.ServerScore();
            GivenReceiverPoint(1);
            ScoreShouldBe("Fifteen All");
        }


        private void GivenReceiverPoint(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennisGameContext.State.ReceiverScore();
            }
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _tennisGameContext.Score());
        }
    }
}