using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        readonly GameContext _context = new GameContext();

        [Fact]
        public void LoveAll()
        {
            ScoreShouldBe("Love All");
        }

        [Fact]
        public void LoveFifteen()
        {
            GiveReceiverScore(1);
            ScoreShouldBe("Love Fifteen");
        }

        [Fact]
        public void LoveThirty()
        {
            GiveReceiverScore(2);
            ScoreShouldBe("Love Thirty");
        }

        [Fact]
        public void LoveForty()
        {
            GiveReceiverScore(3);
            ScoreShouldBe("Love Forty");
        }


        [Fact]
        public void FifteenLove()
        {
            GiveServerScore(1);
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void ThirtyLove()
        {
            GiveServerScore(2);
            ScoreShouldBe("Thirty Love");
        }

        [Fact]
        public void FortyLove()
        {
            GiveServerScore(3);
            ScoreShouldBe("Forty Love");
        }


        [Fact]
        public void FifteenAll()
        {
            GiveServerScore(1);
            GiveReceiverScore(1);
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void ThirtyAll()
        {
            GiveReceiverScore(2);
            GiveServerScore(2);
            ScoreShouldBe("Thirty All");
        }

        private void GiveServerScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _context.ServerScore();
            }
        }

        private void GiveReceiverScore(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _context.ReceiverScore();
            }
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.Equal(expected, _context.Score());
        }
    }

    public class GameContext
    {
        private State _state;

        public GameContext()
        {
            _state = new SameState();
            _state.SetContext(this);
        }

        public string Score() => _state.Score();

        internal void ChangeState(State state)
        {
            _state = state;
            _state.SetContext(this);
        }

        public void ReceiverScore() => _state.ReceiverScore();
        internal int ReceiverPoint { get; set; }
        public void ServerScore() => _state.ServerScore();
        internal int ServerPoint { get; set; }
    }

    public class NormalState : State
    {
        public override string Score()
        {
            return $"{ScoreLookup[Context.ServerPoint]} {ScoreLookup[Context.ReceiverPoint]}";
        }

        protected override void ChangeState()
        {
            if (Context.ServerPoint == Context.ReceiverPoint)
            {
                Context.ChangeState(new SameState());
            }
            else
            {
                Context.ChangeState(new NormalState());
            }
        }
    }

    public abstract class State
    {
        protected GameContext Context;

        protected readonly Dictionary<int, string> ScoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public abstract string Score();

        public void SetContext(GameContext context)
        {
            this.Context = context;
        }

        public void ServerScore()
        {
            Context.ServerPoint++;
            ChangeState();
        }

        public void ReceiverScore()
        {
            Context.ReceiverPoint++;
            ChangeState();
        }

        protected abstract void ChangeState();
    }

    public class SameState : State
    {
        public override string Score()
        {
            return $"{ScoreLookup[Context.ServerPoint]} All";
        }

        protected override void ChangeState()
        {
            Context.ChangeState(new NormalState());
        }
    }
}