﻿using System.Collections.Generic;
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

        public string Score()
        {
            if (ServerPoint == 1 || ReceiverPoint == 1)
            {
                _state = new NormalState();
                _state.SetContext(this);
                return _state.Score();
            }

            return _state.Score();
        }

        public void ReceiverScore()
        {
            ReceiverPoint++;
        }

        private int ReceiverPoint { get; set; }

        public void ServerScore()
        {
            _state.ServerScore();
        }

        internal int ServerPoint { get; set; }
    }

    public class NormalState : State
    {
        public override string Score()
        {
            if (this._context.ServerPoint == 1)
            {
                return "Fifteen Love";
            }

            return "Love Fifteen";
        }
    }

    public abstract class State
    {
        protected GameContext _context;
        public abstract string Score();

        public void SetContext(GameContext context)
        {
            this._context = context;
        }

        public void ServerScore()
        {
            _context.ServerPoint++; 
        }
    }

    public class SameState : State
    {
        public override string Score()
        {
            return "Love All";
        }
    }
}