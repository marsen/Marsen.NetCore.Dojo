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
            Dollar product = five.times(2);
            Assert.Equal(10,product.amount);
            product = five.times(3);
            Assert.Equal(15,product.amount);
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));
        }
      
    }

    public class Dollar
    {
        public int amount;

        public Dollar(int amount)
        {
            this.amount = amount ;
        }

        public Dollar times(int multiplier)
        {
            return new(amount * multiplier);
        }
    }
}