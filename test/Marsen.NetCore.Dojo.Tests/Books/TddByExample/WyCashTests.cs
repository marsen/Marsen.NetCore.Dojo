using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        [Fact]
        public void testMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.Equal(Money.dollar(10), five.times(2));
            Assert.Equal(Money.dollar(15), five.times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            Money five = Money.franc(5);
            Assert.Equal(Money.franc(10), five.times(2));
            Assert.Equal(Money.franc(15), five.times(3));
        }

        [Fact]
        public void testEquality()
        {
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.False(Money.dollar(5).Equals(Money.dollar(6)));
            Assert.True(Money.franc(5).Equals(Money.franc(5)));
            Assert.False(Money.franc(5).Equals(Money.franc(6)));
            Assert.False(Money.franc(5).Equals(Money.dollar(5)));
        }

        [Fact]
        public void testCurrency()
        {
            Assert.Equal("USD", Money.dollar(1).currency());
            Assert.Equal("CHF", Money.franc(1).currency());
        }
    }

    public class Franc : Money
    {
        public Franc(int amount)
        {
            this.amount = amount;
            _currency = "CHF";
        }

        public override Money times(int multiplier)
        {
            return new Franc(amount * multiplier);
        }

        public override string currency()
        {
            return _currency;
        }
    }

    public class Dollar : Money
    {
        public Dollar(int amount)
        {
            this.amount = amount;
            _currency = "USD";
        }

        public override Money times(int multiplier)
        {
            return new Dollar(amount * multiplier);
        }

        public override string currency()
        {
            return _currency;
        }
    }

    public abstract class Money
    {
        protected int amount;
        protected string _currency;

        public override bool Equals(object? money)
        {
            return amount == ((Money) money).amount && this.GetType() == money.GetType();
        }

        public static Dollar dollar(int amount)
        {
            return new Dollar(amount);
        }

        public static Franc franc(int amount)
        {
            return new Franc(amount);
        }

        public abstract Money times(int multiplier);
        public abstract string currency();
    }
}