using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.BowlingGame
{
    public class BowlingGameTests
    {
        private readonly BowlingLine _line = new();

        [Fact]
        public void TestInitialNewLine()
        {
            var hitBalls = new List<int>();
            var result = _line.Calculate(hitBalls);
            Assert.Null(result);
        }

        [Fact]
        public void TestFirstFrame()
        {
            Assert.Null(_line.Calculate(new List<int> { 0 }));
            Assert.Null(_line.Calculate(new List<int> { 1 }));
            Assert.Equal(0, _line.Calculate(new List<int> { 0, 0 }));
            Assert.Equal(1, _line.Calculate(new List<int> { 1, 0 }));
            Assert.Equal(4, _line.Calculate(new List<int> { 1, 3 }));
        }

        [Fact]
        public void TestFirstSpare()
        {
            Assert.Null(_line.Calculate(new List<int> { 0, 10 }));
            Assert.Equal(11, _line.Calculate(new List<int> { 0, 10, 1 }));
            Assert.Equal(12, _line.Calculate(new List<int> { 3, 7, 2 }));
        }

        [Fact]
        public void TestFirstStrike()
        {
            Assert.Null(_line.Calculate(new List<int> { 10 }));
            Assert.Null(_line.Calculate(new List<int> { 10, 2 }));
        }

        [Fact]
        public void TestFrameScore()
        {
            //Frame Playing
            Assert.Null(new Frame().Score);
            Assert.Null(new Frame(1).Score);
            //Normal Frame
            Assert.Equal(7, new Frame(4, 3).Score);
            //Spare
            Assert.Null(new Frame(4, 6).Score);
            Assert.Null(new Frame(0, 10).Score);
            //Strike
            Assert.Null(new Frame(10, 0).Score);
        }

        [Fact(Skip = "Bonus")]
        public void TestFrameBonus()
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

        public int? Score { get; private set; }

        public void SetBonus(int bonus)
        {
            Score = 10 + bonus;
        }
    }

    public class BowlingLine
    {
        public int? Calculate(List<int> fellPins)
        {
            var frames = new List<Frame>();
            var hasBonus = false;
            for (int i = 0; i < fellPins.Count; i++)
            {
                var firstTry = fellPins[i];
                int? secondTry = i < fellPins.Count - 1 ? fellPins[i + 1] : null;

                if (hasBonus)
                {
                    frames.Last().SetBonus(firstTry);
                }

                if (firstTry != 10)
                {
                    frames.Add(new Frame(firstTry, secondTry));
                    if (firstTry + secondTry == 10)
                    {
                        hasBonus = true;
                        i++;
                    }
                }
            }

            return NullableSum(frames);
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