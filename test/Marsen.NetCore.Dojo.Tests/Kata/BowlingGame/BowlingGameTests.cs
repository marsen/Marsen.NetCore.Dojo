using System;
using System.Collections.Generic;
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
            Assert.Equal(null,result);
        }
    }

    public class BowlingLine
    {
        public int? Calculate(List<int> hitBalls)
        {
            return null;
        }
    }
}