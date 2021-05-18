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
            Assert.Equal(new Dollar(10), five.times(2));
            Assert.Equal(new Dollar(15), five.times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            Franc five = new Franc(5);
            Assert.Equal(new Franc(10), five.times(2));
            Assert.Equal(new Franc(15), five.times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(new Dollar(5).Equals(new Dollar(5)));
            Assert.False(new Dollar(5).Equals(new Dollar(6)));
            Assert.True(new Franc(5).Equals(new Franc(5)));
            Assert.False(new Franc(5).Equals(new Franc(6)));
            Assert.False(new Franc(5).Equals(new Dollar(5)));
        }
    }

    public class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
        }

        public Money times(int multiplier)
        {
            return new Franc(amount * multiplier);
        }
    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
        }

        public Money times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }
    }

    public class Money
    {
        protected int amount;

        public override bool Equals(object? money)
        {
            return amount == ((Money) money).amount && this.GetType() == money.GetType();
        }
    }
}