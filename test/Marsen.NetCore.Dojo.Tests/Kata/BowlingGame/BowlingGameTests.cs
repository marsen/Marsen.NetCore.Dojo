using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingGameTests
    {
        [Fact]
        public void testInterface()
        {
            List<int> hitBalls = new List<int>();
            BowlingLine game = new BowlingLine();
            int? result = game.Calculate(hitBalls);
            Assert.Equal(null,result);
        }
    }

    public class BowlingLine
    {
        public int? Calculate(List<int> hitBalls)
        {
            throw new NotImplementedException();
        }
    }
}