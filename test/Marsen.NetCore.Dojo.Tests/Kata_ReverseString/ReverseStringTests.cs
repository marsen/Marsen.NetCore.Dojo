using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class ReverseStringTests
    {
        readonly Reversal _reversal = new Reversal();

        [Fact]
        public void A_is_A()
        {
            var actual = _reversal.Do("A");
            Assert.Equal("A", actual);
        }

        [Fact]
        public void BB_is_BB()
        {
            var actual = _reversal.Do("BB");
            Assert.Equal("BB", actual);
        }
    }
}