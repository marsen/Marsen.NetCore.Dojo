using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class ReverseStringTests
    {
        [Fact]
        public void A_is_A()
        {
            var reversal = new Reversal();
            var actual = reversal.Do("A");
            Assert.Equal("A", actual);
        }

        [Fact]
        public void BB_is_BB()
        {
            var reversal = new Reversal();
            var actual = reversal.Do("BB");
            Assert.Equal("BB", actual);
        }
    }
}