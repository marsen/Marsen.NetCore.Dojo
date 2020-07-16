using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContextTests
    {
        readonly TennisGameContext _tennisGameContext = new TennisGameContext(new SameState());

        [Fact]
        public void Love_All()
        {
            ScoreShouldBe("Love All");
        }

        [Fact]
        public void Fifteen_Love()
        {
            GivenServerPoint(1);
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
            GivenServerPoint(1);
            GivenReceiverPoint(1);
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void LoveFifteen_To_FifteenAll()
        {
            GivenReceiverPoint(1);
            GivenServerPoint(1);
            ScoreShouldBe("Fifteen All");
        }


        [Fact]
        public void Thirty_Love()
        {
            GivenServerPoint(2);
            ScoreShouldBe("Thirty Love");
        }

        [Fact]
        public void Forty_Love()
        {
            GivenServerPoint(3);
            ScoreShouldBe("Forty Love");
        }

        [Fact]
        public void Forty_Fifteen()
        {
            GivenServerPoint(3);
            GivenReceiverPoint(1);
            ScoreShouldBe("Forty Fifteen");
        }

        [Fact]
        public void Fifteen_Thirty()
        {
            GivenServerPoint(1);
            GivenReceiverPoint(2);
            ScoreShouldBe("Fifteen Thirty");
        }

        [Fact]
        public void Thirty_Fifteen()
        {
            GivenServerPoint(2);
            GivenReceiverPoint(1);
            ScoreShouldBe("Thirty Fifteen");
        }

        [Fact]
        public void FifteenAll_To_ThirtyFifteen()
        {
            GivenServerPoint(1);
            GivenReceiverPoint(1);
            GivenServerPoint(1);
            ScoreShouldBe("Thirty Fifteen");
        }

        [Fact]
        public void FifteenAll_To_FifteenThirty()
        {
            GivenReceiverPoint(1);
            GivenServerPoint(1);
            GivenReceiverPoint(1);
            ScoreShouldBe("Fifteen Thirty");
        }

        [Fact]
        public void ThirtyAll()
        {
            GivenReceiverPoint(2);
            GivenServerPoint(2);
            ScoreShouldBe("Thirty All");
        }

        [Fact]
        public void FifteenForty()
        {
            GivenServerPoint(1);
            GivenReceiverPoint(3);
            ScoreShouldBe("Fifteen Forty");
        }


        private void GivenServerPoint(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennisGameContext.State.ServerScore();
            }
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