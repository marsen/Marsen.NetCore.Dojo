using Marsen.NetCore.Dojo.Books.TddByExample;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private readonly Bank _bank = new();
        private readonly Money _fiveBulks = Money.dollar(5);
        private readonly Money _fiveFrancs = Money.franc(5);

        [Fact]
        public void testMultiplication()
        {
            Assert.Equal(Money.dollar(10), _fiveBulks.times(2));
            Assert.Equal(Money.dollar(15), _fiveBulks.times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            Assert.Equal(Money.franc(10), _fiveFrancs.times(2));
            Assert.Equal(Money.franc(15), _fiveFrancs.times(3));
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
            Assert.Equal("USD", Money.dollar(1).Currency);
            Assert.Equal("CHF", Money.franc(1).Currency);
        }

        [Fact]
        public void testSimpleAddition()
        {
            var four = Money.dollar(4);
            var fivePlusFive = _fiveBulks.plus(_fiveBulks);
            var fivePlusFour = _fiveBulks.plus(four);
            Assert.Equal(Money.dollar(10), _bank.reduce(fivePlusFive, "USD"));
            Assert.Equal(Money.dollar(9), _bank.reduce(fivePlusFour, "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            var _5Dollars = Money.dollar(5);
            var _10Francs = Money.franc(10);
            _bank.addRate("CHF", "USD", 2);
            Assert.Equal(Money.dollar(10), _bank.reduce(_5Dollars.plus(_10Francs), "USD"));
            Assert.Equal(Money.dollar(10), _bank.reduce(_10Francs.plus(_5Dollars), "USD"));
        }


        [Fact]
        public void testPlusReturnsSum()
        {
            var result = _fiveBulks.plus(_fiveBulks);
            var sum = (Sum) result;
            Assert.Equal(_fiveBulks, sum.Addend);
            Assert.Equal(_fiveBulks, sum.Augend);
        }

        [Fact]
        public void testReduceMoneyExchangeCurrency()
        {
            var bank = new Bank();
            bank.addRate("CHF", "USD", 2);
            Assert.Equal(Money.dollar(1), bank.reduce(Money.franc(2), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.franc(6), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.dollar(3), "USD"));
        }

        [Fact]
        public void testSumPlusMoney()
        {
            var _5Dollars = Money.dollar(5);
            var _10Francs = Money.franc(10);
            _bank.addRate("CHF", "USD", 2);
            var sum = new Sum(_5Dollars, _10Francs).plus(_5Dollars);
            Assert.Equal(Money.dollar(15), sum.reduce("USD", _bank));
        }

        [Fact]
        public void testSumTimes()
        {
             var _5Dollars = Money.dollar(5);
             var _10Francs = Money.franc(10);
             _bank.addRate("CHF", "USD", 2);
             var sum = new Sum(_5Dollars, _10Francs).times(2);
             Assert.Equal(Money.dollar(20), sum.reduce("USD", _bank));
        }
    }
}