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
        }
    }

    public class Franc
    {
        private int amount;

        public Franc(int amount)
        {
            this.amount = amount;
        }
        public Franc times(int multiplier)
        {
            return new(amount * multiplier);
        }

        public override bool Equals(object? obj)
        {
            return amount == ((Franc) obj).amount;
        }
    }

    public class Dollar : Money
    {
        private int amount;

        public Dollar(int amount)
        {
            this.amount = amount;
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

    public class Money
    {
    }
}