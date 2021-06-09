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
        public void testFirstFrame()
        {
            Assert.Equal(0, _line.Calculate(new List<int> { 0 }));
            Assert.Equal(1, _line.Calculate(new List<int> { 1 }));
            Assert.Equal(4, _line.Calculate(new List<int> { 1, 3 }));
        }

        [Fact]
        public void testFirstSpare()
        {
            Assert.Equal(null, _line.Calculate(new List<int> { 0, 10 }));
        }
    }


    public class BowlingLine
    {
        public int? Calculate(List<int> hitBalls)
        {
            if (hitBalls.Any())
            {
                if (hitBalls.Sum()==10)
                {
                    return null;
                }

                return hitBalls.Sum();
            }

            return null;
        }
    }
}