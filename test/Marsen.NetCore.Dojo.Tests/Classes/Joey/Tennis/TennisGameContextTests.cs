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


        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _tennisGameContext.Score());
        }
    }

    public interface IState
    {
        string Score();
        void SetContext(TennisGameContext context);
        void ServerScore();
    }

    public class LoveAll : IState
    {
        private TennisGameContext _context;

        public string Score()
        {
            return "Love All";
        }

        public void SetContext(TennisGameContext context)
        {
            this._context = context;
        }

        public void ServerScore()
        {
            var fifteenLove = new FifteenLove();
            this._context.ChangeState(fifteenLove);

        }
    }

    public class FifteenLove :IState
    {
        private TennisGameContext _context;

        public string Score()
        {
            return "Fifteen Love";
        }

        public void SetContext(TennisGameContext context)
        {
            this._context = context;
        }

        public void ServerScore()
        {
            throw new System.NotImplementedException();
        }
    }


    public class TennisGameContext
    {
        public TennisGameContext(IState state)
        {
            this.State = state;
            state.SetContext(this);
        }

        public string Score()
        {
            return State.Score();
        }

        public IState State { get; set; }

        public void ChangeState(IState state)
        {
            this.State = state;
        }
    }
}