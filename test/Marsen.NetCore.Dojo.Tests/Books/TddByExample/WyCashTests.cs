using System;
using System.Collections.Generic;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private Bank _bank = new Bank();

        [Fact]
        public void testMultiplication()
        {
            var five = Money.dollar(5);
            Assert.Equal(Money.dollar(10), five.times(2));
            Assert.Equal(Money.dollar(15), five.times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            var five = Money.franc(5);
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

        [Fact]
        public void testSimpleAddition()
        {
            Money five = Money.dollar(5);
            Money four = Money.dollar(4);
            Sum fivePlusFive = five.plus(five);
            Sum fivePlusFour = five.plus(four);
            Assert.Equal(Money.dollar(10), _bank.reduce(fivePlusFive, "USD"));
            Assert.Equal(Money.dollar(9), _bank.reduce(fivePlusFour, "USD"));
        }
    }

    public class Bank
    {
        public Money reduce(IExpression expression, string currency)
        {
            if (expression.GetType() == typeof(Sum))
            {
                Sum sum = (Sum) expression;
                return sum.reduce();
            }

            throw new NotImplementedException();
        }
    }

    public class Sum : IExpression
    {
        private int augend;
        private int addend;

        public Sum(Money augend, Money addend)
        {
            this.augend = augend.Amount;
            this.addend = addend.Amount;
        }

        public Money reduce()
        {
            return Money.dollar(this.augend + this.addend);
        }
    }

    public interface IExpression
    {
    }

    public class Money : IExpression
    {
        public override string ToString()
        {
            return $@"{Amount} {_currency}";
        }

        public readonly int Amount;
        private readonly string _currency;

        private Money(int amount, string currency)
        {
            Amount = amount;
            _currency = currency;
        }

        public override bool Equals(object? obj)
        {
            var money = (Money) obj;
            return Amount == money.Amount && _currency == money._currency;
        }

        public static Money dollar(int amount)
        {
            return new(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new(amount, "CHF");
        }

        public Money times(int multiplier)
        {
            return new(Amount * multiplier, _currency);
        }

        public string currency()
        {
            return _currency;
        }

        public Sum plus(Money money)
        {
            return new(this, money);
        }
    }
}