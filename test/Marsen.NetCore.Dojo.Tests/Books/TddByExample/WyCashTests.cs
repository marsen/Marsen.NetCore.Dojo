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
            Assert.Equal(new Dollar(10),product);
            product = five.times(3);
            Assert.Equal(new Dollar(15),product);
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));
            Assert.False(new Dollar(5).Equals(new Dollar(6)));
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

        public override bool Equals(object? obj)
        {
            return amount == ((Dollar) obj).amount;
        }
    }
}