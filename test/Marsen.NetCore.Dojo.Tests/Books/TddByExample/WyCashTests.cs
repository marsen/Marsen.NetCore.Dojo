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
            five.times(3);
            Assert.Equal(15,five.amount);
        }
      
    }

    public class Dollar
    {
        public int amount;

        public Dollar(int amount)
        {
            this.amount = amount ;
        }

        public void times(int multiplier)
        {
            amount *= multiplier;
        }
    }
}