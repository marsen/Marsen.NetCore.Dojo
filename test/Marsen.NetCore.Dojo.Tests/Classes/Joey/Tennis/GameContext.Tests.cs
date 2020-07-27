using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        readonly GameContext _context = new GameContext("Sam", "Ben");

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
        public void ReceiverWin()
        {
            GiveReceiverScore(4);
            ScoreShouldBe("Ben Win");
        }


        [Fact]
        public void FifteenForty()
        {
            GiveReceiverScore(3);
            GiveServerScore(1);
            ScoreShouldBe("Fifteen Forty");
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
        public void ThirtyFifteen()
        {
            GiveServerScore(2);
            GiveReceiverScore(1);
            ScoreShouldBe("Thirty Fifteen");
        }


        [Fact]
        public void FortyLove()
        {
            GiveServerScore(3);
            ScoreShouldBe("Forty Love");
        }

        [Fact]
        public void ServerWin()
        {
            GiveServerScore(4);
            ScoreShouldBe("Sam Win");
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

        [Fact]
        public void Deuce()
        {
            GivenDeuce();
            ScoreShouldBe("Deuce");
        }

        [Fact]
        public void ServerAdv()
        {
            GivenDeuce();
            GiveServerScore(1);
            ScoreShouldBe("Sam Adv");
        }

        [Fact]
        public void ReceiverAdv()
        {
            GivenDeuce();
            GiveReceiverScore(1);
            ScoreShouldBe("Ben Adv");
        }

        [Fact]
        public void Deuce_When_4_4()
        {
            GivenDeuce();
            GiveReceiverScore(1);
            GiveServerScore(1);
            ScoreShouldBe("Deuce");
        }

        private void GivenDeuce()
        {
            GiveReceiverScore(3);
            GiveServerScore(3);
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

        public GameContext(string serverName, string receiverName)
        {
            ServerName = serverName;
            ReceiverName = receiverName;
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
        public string ServerName;

        public readonly string ReceiverName;
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
                if (Context.ServerPoint >= 3)
                {
                    Context.ChangeState(new DeuceState());
                }
                else
                {
                    Context.ChangeState(new SameState());
                }
            }
            else
            {
                if (Context.ServerPoint > 3)
                {
                    Context.ChangeState(new WinState());
                }
                else
                {
                    Context.ChangeState(new NormalState());
                }
            }
        }
    }

    public class WinState : State
    {
        public override string Score()
        {
            return "Sam Win";
        }

        protected override void ChangeState()
        {
            throw new System.NotImplementedException();
        }
    }

    public class DeuceState : State
    {
        public override string Score()
        {
            return "Deuce";
        }

        protected override void ChangeState()
        {
            Context.ChangeState(new AdvState());
        }
    }

    public class AdvState : State
    {
        public override string Score()
        {
            return $"{Winner()} Adv";
        }

        private string Winner()
        {
            return Context.ReceiverPoint > Context.ServerPoint ? $"{Context.ReceiverName}" : $"{Context.ServerName}";
        }

        protected override void ChangeState()
        {
            Context.ChangeState(new DeuceState());
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