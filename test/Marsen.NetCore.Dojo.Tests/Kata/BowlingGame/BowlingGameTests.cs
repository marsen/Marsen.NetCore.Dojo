using System.Collections.Generic;
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
            Assert.Equal(15, _line.Calculate(new List<int> { 3, 7, 2, 1 }));
        }

        [Fact]
        public void TestFrameNumber()
        {
            _line.Calculate(new List<int> { 3, 7, 2, 1 });
            Assert.Equal(2, _line.FrameList.Count);
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
}