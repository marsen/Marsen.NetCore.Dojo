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

    public abstract class State
    {
        protected TennisGameContext Context;
        public abstract string Score();
        public void SetContext(TennisGameContext context)
        {
            this.Context = context;
        }
        public abstract void ServerScore();
    }

    public class LoveAll : State
    {
        public override string Score()
        {
            return "Love All";
        }

        public override void ServerScore()
        {
            var fifteenLove = new FifteenLove();
            this.Context.ChangeState(fifteenLove);

        }
    }

    public class FifteenLove :State
    {
        public override string Score()
        {
            return "Fifteen Love";
        }
        
        public override void ServerScore()
        {
            throw new System.NotImplementedException();
        }
    }


    public class TennisGameContext
    {
        public TennisGameContext(State state)
        {
            this.State = state;
            state.SetContext(this);
        }

        public string Score()
        {
            return State.Score();
        }

        public State State { get; private set; }

        public void ChangeState(State state)
        {
            this.State = state;
        }
    }
}