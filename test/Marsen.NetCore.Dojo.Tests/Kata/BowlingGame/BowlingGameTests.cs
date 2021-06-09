using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
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
            Assert.Equal(null, _line.Calculate(new List<int> { 0 }));
            Assert.Equal(null, _line.Calculate(new List<int> { 1 }));
            Assert.Equal(0, _line.Calculate(new List<int> { 0, 0 }));
            Assert.Equal(1, _line.Calculate(new List<int> { 1, 0 }));
            Assert.Equal(4, _line.Calculate(new List<int> { 1, 3 }));
        }

        [Fact]
        public void testFirstSpare()
        {
            Assert.Equal(null, _line.Calculate(new List<int> { 0, 10 }));
            Assert.Equal(11, _line.Calculate(new List<int> { 0, 10, 1 }));
        }

        [Fact]
        public void testFirstStrike()
        {
            Assert.Equal(null, _line.Calculate(new List<int> { 10 }));
            Assert.Equal(null, _line.Calculate(new List<int> { 10, 2 }));
        }

        [Fact]
        public void testFrameScore()
        {
            Assert.Equal(7, new Frame(4, 3).Score);
            Assert.Equal(null, new Frame(4, 6).Score);
        }
    }

    public class Frame
    {
        public Frame(int firstTry, int secondTry)
        {
            if (firstTry + secondTry != 10)
            {
                Score = firstTry + secondTry;
            }
        }

        public int? Score { get; }
    }


    public class BowlingLine
    {
        public int? Calculate(List<int> fellPins)
        {
            var firstTry = 0;
            for (var i = 0; i < fellPins.Count; i++)
            {
                if (fellPins[firstTry] == 10)
                {
                    continue;
                }

                if (fellPins.Count == 2 && fellPins.Sum() == 10)
                {
                    continue;
                }

                if (fellPins.Count > 1)
                {
                    return fellPins.Sum();
                }
            }

            return null;
        }
    }
}