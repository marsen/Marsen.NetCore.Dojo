using System;
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
            _context.ReceiverScore();
            ScoreShouldBe("Love Fifteen");
        }

        [Fact]
        public void FifteenLove()
        {
            _context.ServerScore();
            ScoreShouldBe("Fifteen Love");
        }

        [Fact]
        public void FifteenAll()
        {
            _context.ServerScore();
            _context.ReceiverScore();
            ScoreShouldBe("Fifteen All");
        }

        [Fact]
        public void ThirtyAll()
        {
            _context.ServerScore();
            _context.ReceiverScore();
            _context.ReceiverScore();
            _context.ServerScore();
            ScoreShouldBe("Thirty All");
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
            if (this.Context.ServerPoint == 1)
            {
                return "Fifteen Love";
            }

            return "Love Fifteen";
        }

        protected override void ChangeState()
        {
            Context.ChangeState(new SameState());
        }
    }

    public abstract class State
    {
        protected GameContext Context;
        public abstract string Score();

        public void SetContext(GameContext context)
        {
            this.Context = context;
        }

        public void ServerScore()
        {
            ChangeState();
            Context.ServerPoint++;
        }

        public void ReceiverScore()
        {
            ChangeState();
            Context.ReceiverPoint++;
        }

        protected abstract void ChangeState();
    }

    public class SameState : State
    {
        public override string Score()
        {
            if (Context.ServerPoint==2)
            {
                return "Thirty All";
            }
            if (Context.ServerPoint == 1)
            {
                return "Fifteen All";
            }

            if (Context.ServerPoint == 0)
            {
                return "Love All";
            }
            throw new NotImplementedException();
        }

        protected override void ChangeState()
        {
            Context.ChangeState(new NormalState());
        }
    }
}