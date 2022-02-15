using System;
using Marsen.NetCore.Dojo.Extend;
using Xunit;

namespace Marsen.NetCore.Dojo.Integration.Tests.Extend
{
    public class CollectionTests
    {

        [Fact]
        public void ShuffleTests()
        {
            const string poker = "123456789TJQK";
            //// A very small probability will fail
            Assert.NotEqual(poker.Shuffle(),poker.Shuffle());
            Assert.NotEqual(poker.Shuffle(),poker.Shuffle());
            Assert.NotEqual(poker.Shuffle(),poker.Shuffle());
            Assert.NotEqual(poker.Shuffle(),poker.Shuffle());
            Assert.NotEqual(poker.Shuffle(),poker.Shuffle());
        }

        [Fact]
        public void ShuffleNotWorkTests()
        {
            Assert.Equal(String.Empty.Shuffle(),String.Empty.Shuffle());
            Assert.Equal("1".Shuffle(),"1".Shuffle());
        }
    }
}