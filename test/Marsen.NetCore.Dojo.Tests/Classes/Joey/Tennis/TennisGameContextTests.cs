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
            ScoreShouldBe("Fifteen Love");
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _tennisGameContext.Score());
        }
    }

    public interface IState
    {
        string Score();
    }

    public class LoveAll : IState
    {
        public string Score()
        {
            return "Love All";
        }
    }


    public class TennisGameContext
    {
        public TennisGameContext(IState state)
        {
            this._state = state;
        }

        public string Score()
        {
            return _state.Score();
        }

        private IState _state { get; }
    }
}