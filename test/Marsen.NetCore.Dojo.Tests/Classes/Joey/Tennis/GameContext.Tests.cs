using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.Tennis
{
    public class GameContextTests
    {
        [Fact]
        public void LoveAll()
        {
            var context = new GameContext();
            Assert.Equal("Love All", context.Score());
        }

    }

    public class GameContext
    {
        public string Score()
        {
            var state = new SameState();
            return state.Score();
        }
    }

    public class SameState
    {
        public string Score()
        {
            return "Love All";
        }
    }
}