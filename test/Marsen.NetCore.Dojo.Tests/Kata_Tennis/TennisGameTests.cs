﻿using System;
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
    }
}