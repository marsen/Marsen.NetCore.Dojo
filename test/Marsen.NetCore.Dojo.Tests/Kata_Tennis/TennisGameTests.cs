using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGameTests
    {
        readonly TennisGame _tennisGame = new TennisGame();

        [Fact]
        public void Love_All()
        {
            Assert.Equal("Love All", _tennisGame.Score());
        }

        [Fact]
        public void Fifteen_Love()
        {
            _tennisGame.FirstPlayerScore();
            Assert.Equal("Fifteen Love", _tennisGame.Score());
        }

        [Fact]
        public void Thirty_Love()
        {
            _tennisGame.FirstPlayerScore();
            _tennisGame.FirstPlayerScore();
            Assert.Equal("Thirty Love", _tennisGame.Score());
        }

        [Fact]
        public void Forty_Love()
        {
            _tennisGame.FirstPlayerScore();
            _tennisGame.FirstPlayerScore();
            _tennisGame.FirstPlayerScore();
            Assert.Equal("Forty Love", _tennisGame.Score());
        }
    }
}