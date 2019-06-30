﻿using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Kata_ShowHands;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ShowHands
{
    public class ShowHandTests
    {
        [Fact]
        public void FourOfAKind_ThreeOfAKind()
        {
            ShowHand showHand = new ShowHand("Tom", "Lee");
            var actual = showHand.Duel("S3,C3,D3,H3,H7", "S3,C3,D3,H7,H8");
            Assert.Equal("Tom Win, Because Four Of a Kind", actual);
        }
    }
}