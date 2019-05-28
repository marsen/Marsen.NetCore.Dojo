using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_Tennis
{
    public class TennisGameTests
    {
        readonly TennisGame _tennisGame = new TennisGame();

        private void FirstPlayerScoreTimes(int times)
        {
            for (var i = 0; i < times; i++)
            {
                _tennisGame.FirstPlayerScore();
            }
        }

        private void SecondPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennisGame.SecondPlayerScore();
            }
        }

        [Fact]
        public void Love_All()
        {
            Assert.Equal("Love All", _tennisGame.Score());
        }

        [Fact]
        public void Fifteen_Love()
        {
            FirstPlayerScoreTimes(1);
            Assert.Equal("Fifteen Love", _tennisGame.Score());
        }

        [Fact]
        public void Thirty_Love()
        {
            FirstPlayerScoreTimes(2);
            Assert.Equal("Thirty Love", _tennisGame.Score());
        }


        [Fact]
        public void Forty_Love()
        {
            FirstPlayerScoreTimes(3);
            Assert.Equal("Forty Love", _tennisGame.Score());
        }

        [Fact]
        public void Love_Fifteen()
        {
            SecondPlayerScoreTimes(1);
            Assert.Equal("Love Fifteen", _tennisGame.Score());
        }

        [Fact]
        public void Love_Thirty()
        {
            SecondPlayerScoreTimes(2);
            Assert.Equal("Love Thirty", _tennisGame.Score());
        }

        [Fact]
        public void Love_Forty()
        {
            SecondPlayerScoreTimes(3);
            Assert.Equal("Love Forty", _tennisGame.Score());
        }
    }
}