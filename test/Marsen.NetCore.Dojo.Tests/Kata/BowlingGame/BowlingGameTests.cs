using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingGameTests
    {
        private readonly BowlingLine _line = new();

        [Fact]
        public void testInitialNewLine()
        {
            var hitBalls = new List<int>();
            var result = _line.Calculate(hitBalls);
            Assert.Equal(null, result);
        }

        [Fact]
        public void testFirstHit()
        {
            var firstPlayerHitBalls = new List<int> { 0 };
            var firstPlayerScore = _line.Calculate(firstPlayerHitBalls);
            var secondPlayerHitBalls = new List<int> { 1 };
            var secondPlayerScore = _line.Calculate(secondPlayerHitBalls);
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
                return hitBalls.Sum();
            }

            return null;
        }
    }
}