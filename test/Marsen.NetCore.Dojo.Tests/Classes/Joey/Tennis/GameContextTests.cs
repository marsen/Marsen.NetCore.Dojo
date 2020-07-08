﻿using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        [Fact]
        public void FifteenLove()
        {
            GameContext game = new GameContext();
            string result = game.ServerScore();
            Assert.Equal("Fifteen Love", result);
        }
    }

    public class GameContext
    {
        public string ServerScore()
        {
            var normalState = new NormalState();
            return normalState.ServerScore();
        }
    }

    public class NormalState
    {
        public string ServerScore()
        {
            return "Fifteen Love";
        }
    }
}