using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGameTests
    {
        [Fact]
        public void Love_All()
        {
            TennisGame tennisGame = new TennisGame();
            var score = tennisGame.Score();
            Assert.Equal("Love All", score);
        }
    }
}