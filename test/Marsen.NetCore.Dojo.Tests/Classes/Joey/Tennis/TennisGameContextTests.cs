using Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis.States;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameContextTests
    {
        private readonly TennisGameContext _tennisGameContext;

        public TennisGameContextTests()
        {
            _tennisGameContext = new TennisGameContext("Mark", "Iris");
        }

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

        [Fact]
        public void FortyFifteen()
        {
            GivenServerPoint(3);
            GivenReceiverPoint(1);
            ScoreShouldBe("Forty Fifteen");
        }

        [Fact]
        public void FortyThirty()
        {
            GivenServerPoint(3);
            GivenReceiverPoint(2);
            ScoreShouldBe("Forty Thirty");
        }

        [Fact]
        public void ThirtyForty()
        {
            GivenServerPoint(2);
            GivenReceiverPoint(3);
            ScoreShouldBe("Thirty Forty");
        }

        [Fact]
        public void Deuce()
        {
            GivenDeuce();
            ScoreShouldBe("Deuce");
        }

        private void GivenDeuce()
        {
            GivenServerPoint(3);
            GivenReceiverPoint(3);
        }

        [Fact]
        public void Deuce_When_4_4_After_ServerScore()
        {
            GivenDeuce();
            GivenReceiverPoint(1);
            GivenServerPoint(1);
            ScoreShouldBe("Deuce");
        }

        [Fact]
        public void Deuce_When_4_4_After_ReceiverScore()
        {
            GivenDeuce();
            GivenServerPoint(1);
            GivenReceiverPoint(1);
            ScoreShouldBe("Deuce");
        }


        [Fact]
        public void ServerAdv()
        {
            GivenDeuce();
            GivenServerPoint(1);
            ScoreShouldBe("Mark Adv");
        }

        [Fact]
        public void ReceiverAdv()
        {
            GivenDeuce();
            GivenReceiverPoint(1);
            ScoreShouldBe("Iris Adv");
        }

        [Fact]
        public void ReceiverWin()
        {
            GivenDeuce();
            GivenReceiverPoint(2);
            ScoreShouldBe("Iris Win");
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