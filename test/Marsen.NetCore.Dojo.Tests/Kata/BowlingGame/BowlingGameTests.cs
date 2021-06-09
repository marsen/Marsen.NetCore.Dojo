using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingGameTests
    {
        [Fact]
        public void testInitialNewLine()
        {
            var hitBalls = new List<int>();
            var line = new BowlingLine();
            var result = line.Calculate(hitBalls);
            Assert.Equal(null, result);
        }

        [Fact]
        public void testFirstHit()
        {
            var firstPlayerHitBalls = new List<int> { 0 };
            var secondPlayerHitBalls = new List<int> { 1 };
            var line = new BowlingLine();
            var firstPlayerScore = line.Calculate(firstPlayerHitBalls);
            var secondPlayerScore = line.Calculate(secondPlayerHitBalls);
            Assert.Equal(0, firstPlayerScore);
            Assert.Equal(1, secondPlayerScore);
        }
    }

    public class BowlingLine
    {
        public int? Calculate(List<int> hitBalls)
        {
            if (hitBalls.Any())
            {
                return 0;
            }

            return null;
        }
    }
}