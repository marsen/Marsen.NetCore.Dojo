using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        [Fact]
        public void testMultiplication()
        {
            Dollar five = new Dollar(5);
            five.times(2);
            Assert.Equal(10,five.amount);
        }
      
    }

    public class Dollar
    {
        public int amount;

        public Dollar(int amount)
        {
            this.amount = amount * 2;
        }

        public void times(int i)
        {
        }
    }
}