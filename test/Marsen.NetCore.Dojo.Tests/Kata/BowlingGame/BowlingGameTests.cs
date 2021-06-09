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
            Assert.Equal(0, _line.Calculate(new List<int> { 0 }));
            Assert.Equal(1, _line.Calculate(new List<int> { 1 }));
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