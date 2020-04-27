﻿using Marsen.NetCore.Dojo.Kata.Tennis;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class TennisGameTests
    {
        private readonly TennisGame _tennisGame = new TennisGame("Joey", "Tom");

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

        [Fact]
        public void Fifteen_All()
        {
            FirstPlayerScoreTimes(1);
            SecondPlayerScoreTimes(1);
            Assert.Equal("Fifteen All", _tennisGame.Score());
        }

        [Fact]
        public void Thirty_All()
        {
            FirstPlayerScoreTimes(2);
            SecondPlayerScoreTimes(2);
            Assert.Equal("Thirty All", _tennisGame.Score());
        }

        [Fact]
        public void Deuce()
        {
            FirstPlayerScoreTimes(3);
            SecondPlayerScoreTimes(3);
            Assert.Equal("Deuce", _tennisGame.Score());
        }

        [Fact]
        public void Deuce_when_4_4()
        {
            FirstPlayerScoreTimes(4);
            SecondPlayerScoreTimes(4);
            Assert.Equal("Deuce", _tennisGame.Score());
        }

        [Fact]
        public void FirstPlayer_Adv()
        {
            FirstPlayerScoreTimes(4);
            SecondPlayerScoreTimes(3);
            Assert.Equal("Joey Adv", _tennisGame.Score());
        }

        [Fact]
        public void FirstPlayer_Win()
        {
            FirstPlayerScoreTimes(5);
            SecondPlayerScoreTimes(3);
            Assert.Equal("Joey Win", _tennisGame.Score());
        }

        [Fact]
        public void SecondPlayer_Adv()
        {
            FirstPlayerScoreTimes(3);
            SecondPlayerScoreTimes(4);
            Assert.Equal("Tom Adv", _tennisGame.Score());
        }

        [Fact]
        public void SecondPlayer_Win()
        {
            FirstPlayerScoreTimes(3);
            SecondPlayerScoreTimes(5);
            Assert.Equal("Tom Win", _tennisGame.Score());
        }
    }
}