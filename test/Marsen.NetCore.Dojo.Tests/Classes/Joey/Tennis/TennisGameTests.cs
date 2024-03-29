﻿using Marsen.NetCore.Dojo.Classes.Joey.Tennis;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameTests
    {
        private readonly TennisGame _tennisGame = new("Joey", "Tom");

        private void FirstPlayerScoreTimes(int times)
        {
            for (var i = 0; i < times; i++) _tennisGame.FirstPlayerScore();
        }

        private void SecondPlayerScoreTimes(int times)
        {
            for (var i = 0; i < times; i++) _tennisGame.SecondPlayerScore();
        }

        private void GivenDeuce()
        {
            FirstPlayerScoreTimes(3);
            SecondPlayerScoreTimes(3);
        }

        [Fact]
        public void Deuce()
        {
            GivenDeuce();
            Assert.Equal("Deuce", _tennisGame.Score());
        }

        [Fact]
        public void Deuce_when_4_4()
        {
            GivenDeuce();
            FirstPlayerScoreTimes(1);
            SecondPlayerScoreTimes(1);
            Assert.Equal("Deuce", _tennisGame.Score());
        }

        [Fact]
        public void Fifteen_All()
        {
            FirstPlayerScoreTimes(1);
            SecondPlayerScoreTimes(1);
            Assert.Equal("Fifteen All", _tennisGame.Score());
        }

        [Fact]
        public void Fifteen_Love()
        {
            FirstPlayerScoreTimes(1);
            Assert.Equal("Fifteen Love", _tennisGame.Score());
        }

        [Fact]
        public void FirstPlayer_Adv()
        {
            GivenDeuce();
            FirstPlayerScoreTimes(1);
            Assert.Equal("Joey Adv", _tennisGame.Score());
        }

        [Fact]
        public void FirstPlayer_Win()
        {
            GivenDeuce();
            FirstPlayerScoreTimes(2);
            Assert.Equal("Joey Win", _tennisGame.Score());
        }

        [Fact]
        public void Forty_Love()
        {
            FirstPlayerScoreTimes(3);
            Assert.Equal("Forty Love", _tennisGame.Score());
        }

        [Fact]
        public void Love_All()
        {
            Assert.Equal("Love All", _tennisGame.Score());
        }

        [Fact]
        public void Love_Fifteen()
        {
            SecondPlayerScoreTimes(1);
            Assert.Equal("Love Fifteen", _tennisGame.Score());
        }

        [Fact]
        public void Love_Forty()
        {
            SecondPlayerScoreTimes(3);
            Assert.Equal("Love Forty", _tennisGame.Score());
        }

        [Fact]
        public void Love_Thirty()
        {
            SecondPlayerScoreTimes(2);
            Assert.Equal("Love Thirty", _tennisGame.Score());
        }

        [Fact]
        public void SecondPlayer_Adv()
        {
            GivenDeuce();
            SecondPlayerScoreTimes(1);
            Assert.Equal("Tom Adv", _tennisGame.Score());
        }

        [Fact]
        public void SecondPlayer_Win()
        {
            GivenDeuce();
            SecondPlayerScoreTimes(2);
            Assert.Equal("Tom Win", _tennisGame.Score());
        }

        [Fact]
        public void Thirty_All()
        {
            FirstPlayerScoreTimes(2);
            SecondPlayerScoreTimes(2);
            Assert.Equal("Thirty All", _tennisGame.Score());
        }

        [Fact]
        public void Thirty_Love()
        {
            FirstPlayerScoreTimes(2);
            Assert.Equal("Thirty Love", _tennisGame.Score());
        }
    }
}