using System;
using System.Collections.Generic;
using Marsen.NetCore.Dojo.Extend;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Extend
{
    public class CollectionTests
    {
        private const string Poker = "123456789TJQK";

        [Fact]
        public void ShuffleTests()
        {
            //// A very small probability will fail
            Assert.NotEqual(Poker.Shuffle(),Poker.Shuffle());
            Assert.NotEqual(Poker.Shuffle(),Poker.Shuffle());
            Assert.NotEqual(Poker.Shuffle(),Poker.Shuffle());
            Assert.NotEqual(Poker.Shuffle(),Poker.Shuffle());
            Assert.NotEqual(Poker.Shuffle(),Poker.Shuffle());
        }
    }
}