using Marsen.NetCore.Dojo.Books.TddByExample;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private readonly Bank _bank = new();
        private readonly Money _fourBulks = Money.dollar(4);
        private readonly Money _fiveBulks = Money.dollar(5);
        private readonly Money _fiveFrancs = Money.franc(5);
        private readonly Money _10Francs = Money.franc(10);

        public WyCashTests()
        {
            _bank.addRate("CHF", "USD", 2);
        }

        [Fact]
        public void testMultiplication()
        {
            Assert.Equal(Money.dollar(10), _fiveBulks.Times(2));
            Assert.Equal(Money.dollar(15), _fiveBulks.Times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            Assert.Equal(Money.franc(10), _fiveFrancs.Times(2));
            Assert.Equal(Money.franc(15), _fiveFrancs.Times(3));
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
            Assert.Equal(Money.dollar(10), _bank.reduce(_fiveBulks.Plus(_fiveBulks), "USD"));
            Assert.Equal(Money.dollar(9), _bank.reduce(_fiveBulks.Plus(_fourBulks), "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            Assert.Equal(Money.dollar(10), _bank.reduce(_fiveBulks.Plus(_10Francs), "USD"));
            Assert.Equal(Money.dollar(10), _bank.reduce(_10Francs.Plus(_fiveBulks), "USD"));
        }


        [Fact]
        public void testPlusReturnsSum()
        {
            Sum sum = (Sum) _fiveBulks.Plus(_fiveBulks);
            Assert.Equal(_fiveBulks, sum.Addend);
            Assert.Equal(_fiveBulks, sum.Augend);
        }

        [Fact]
        public void testReduceMoneyExchangeCurrency()
        {
            Assert.Equal(Money.dollar(1), _bank.reduce(Money.franc(2), "USD"));
            Assert.Equal(Money.dollar(3), _bank.reduce(Money.franc(6), "USD"));
            Assert.Equal(Money.dollar(3), _bank.reduce(Money.dollar(3), "USD"));
        }

        [Fact]
        public void testSumPlusMoney()
        {
            var sum = new Sum(_fiveBulks, _10Francs).Plus(_fiveBulks);
            Assert.Equal(Money.dollar(15), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void testSumTimes()
        {
            var sum = new Sum(_fiveBulks, _10Francs).Times(2);
            Assert.Equal(Money.dollar(20), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void testMoneyTimes()
        {
            Money dollar = (Money) _fiveBulks.Times(2);
            Money francs = (Money) _10Francs.Times(2);
            Assert.Equal(Money.dollar(10), dollar.Reduce(_bank, "USD"));
            Assert.Equal(Money.franc(20), francs.Reduce(_bank, "CHF"));
        }
    }
}