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
            //Frame Playing
            Assert.Equal(null, new Frame().Score);
            Assert.Equal(null, new Frame(1).Score);
            //Normal Frame
            Assert.Equal(7, new Frame(4, 3).Score);
            //Spare
            Assert.Equal(null, new Frame(4, 6).Score);
            Assert.Equal(null, new Frame(0, 10).Score);
            //Strike
            Assert.Equal(null, new Frame(10, 0).Score);
        }

        [Fact(Skip = "Bonus")]
        public void testFrameBonus()
        {
            Assert.Equal(12, _line.Calculate(new List<int> { 0, 10, 2 }));
            Assert.Equal(13, _line.Calculate(new List<int> { 0, 10, 2, 1 }));
            Assert.Equal(16, _line.Calculate(new List<int> { 10, 2, 1 }));
        }
    }

    public class Frame
    {
        public Frame(int? firstTry = null, int? secondTry = null)
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
            var frames = new List<Frame>();
            if (fellPins.Count == 1)
            {
                frames.Add(new Frame(fellPins[0]));
            }

            //todo remove this condition after pass single frame test
            if (fellPins.Count == 2)
            {
                if (fellPins[0] != 10)
                {
                    frames.Add(new Frame(fellPins[0], fellPins[1]));
                }

                return NullableSum(frames);
            }

            if (fellPins.Count == 3 && (fellPins[0] + fellPins[1]) == 10)
            {
                return fellPins.Sum();
            }

            return null;
        }

        private int? NullableSum(List<Frame> frames)
        {
            int? result = null;
            foreach (var f in frames)
            {
                if (f.Score != null)
                {
                    result ??= 0;

                    result += f.Score;
                }
            }

            return result;
        }
    }
}