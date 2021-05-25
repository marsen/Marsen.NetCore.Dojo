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
            var five = Money.dollar(5);
            var four = Money.dollar(4);
            var fivePlusFive = five.plus(five);
            var fivePlusFour = five.plus(four);
            Assert.Equal(Money.dollar(10), _bank.reduce(fivePlusFive, "USD"));
            Assert.Equal(Money.dollar(9), _bank.reduce(fivePlusFour, "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            Money _5Dollars = Money.dollar(5);
            Money _10Francs = Money.franc(10);
            _bank.addRate("CHF","USD",2);
            Assert.Equal(Money.dollar(10), _bank.reduce(_5Dollars.plus(_10Francs), "USD"));
            Assert.Equal(Money.dollar(10), _bank.reduce(_10Francs.plus(_5Dollars), "USD"));
        }


        [Fact]
        public void testPlusReturnsSum()
        {
            Money five = Money.dollar(5);
            IExpression result = five.plus(five);
            Sum sum = (Sum) result;
            Assert.Equal(five, sum.addend);
            Assert.Equal(five, sum.augend);
        }

        [Fact]
        public void testReduceMoneyExchangeCurrency()
        {
            Bank bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Assert.Equal(Money.dollar(1), bank.reduce(Money.franc(2), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.franc(6), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.dollar(3), "USD"));
        }
    }
}