﻿using System;
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
            FirstPlayerScoreTimes(2);
            Assert.Equal("Thirty Love", _tennisGame.Score());
        }


        [Fact]
        public void Forty_Love()
        {
            FirstPlayerScoreTimes(3);
            Assert.Equal("Forty Love", _tennisGame.Score());
        }
    }
}