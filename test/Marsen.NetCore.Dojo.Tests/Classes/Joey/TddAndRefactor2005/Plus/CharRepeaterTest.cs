using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.TddAndRefactor2005.Plus
{
    public class CharRepeaterTest
    {

        [Fact]
        public void The_A_GetA()
        {
            var charRepeater = new CharRepeater();
            var repeat = charRepeater.Repeat("A");
            Assert.Equal("A",repeat);
        }
    }

    public class CharRepeater
    {
        public string Repeat(string s)
        {
            throw new System.NotImplementedException();
        }
    }
}