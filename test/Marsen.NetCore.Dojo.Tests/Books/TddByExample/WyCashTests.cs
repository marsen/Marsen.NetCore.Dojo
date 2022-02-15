using Marsen.NetCore.Dojo.Books.TddByExample;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private readonly Bank _bank = new();
        private readonly Money _fiveBulks = Money.dollar(5);
        private readonly Money _fiveFrancs = Money.franc(5);
        private readonly Money _fourBulks = Money.dollar(4);
        private readonly Money _temFrancs = Money.franc(10);

        public WyCashTests()
        {
            _bank.addRate("CHF", "USD", 2);
        }

        [Fact]
        public void TestMultiplication()
        {
            Assert.Equal(Money.dollar(10), _fiveBulks.Times(2));
            Assert.Equal(Money.dollar(15), _fiveBulks.Times(3));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            Assert.Equal(Money.franc(10), _fiveFrancs.Times(2));
            Assert.Equal(Money.franc(15), _fiveFrancs.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.Equal(Money.dollar(5),Money.dollar(5));
            Assert.False(Money.dollar(5).Equals(Money.dollar(6)));
            Assert.Equal(Money.franc(5),Money.franc(5));
            Assert.False(Money.franc(5).Equals(Money.franc(6)));
            Assert.False(Money.franc(5).Equals(Money.dollar(5)));
        }

        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.dollar(1).Currency);
            Assert.Equal("CHF", Money.franc(1).Currency);
        }

        [Fact]
        public void TestSimpleAddition()
        {
            Assert.Equal(Money.dollar(10), _bank.reduce(_fiveBulks.Plus(_fiveBulks), "USD"));
            Assert.Equal(Money.dollar(9), _bank.reduce(_fiveBulks.Plus(_fourBulks), "USD"));
        }

        [Fact]
        public void TestMixedAddition()
        {
            Assert.Equal(Money.dollar(10), _bank.reduce(_fiveBulks.Plus(_temFrancs), "USD"));
            Assert.Equal(Money.dollar(10), _bank.reduce(_temFrancs.Plus(_fiveBulks), "USD"));
        }


        [Fact]
        public void TestPlusReturnsSum()
        {
            var sum = (Sum)_fiveBulks.Plus(_fiveBulks);
            Assert.Equal(_fiveBulks, sum.Addend);
            Assert.Equal(_fiveBulks, sum.Augend);
        }

        [Fact]
        public void TestReduceMoneyExchangeCurrency()
        {
            Assert.Equal(Money.dollar(1), _bank.reduce(Money.franc(2), "USD"));
            Assert.Equal(Money.dollar(3), _bank.reduce(Money.franc(6), "USD"));
            Assert.Equal(Money.dollar(3), _bank.reduce(Money.dollar(3), "USD"));
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            var sum = new Sum(_fiveBulks, _temFrancs).Plus(_fiveBulks);
            Assert.Equal(Money.dollar(15), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void TestSumTimes()
        {
            var sum = new Sum(_fiveBulks, _temFrancs).Times(2);
            Assert.Equal(Money.dollar(20), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void TestMoneyTimes()
        {
            var dollar = (Money)_fiveBulks.Times(2);
            var francs = (Money)_temFrancs.Times(2);
            Assert.Equal(Money.dollar(10), dollar.Reduce(_bank, "USD"));
            Assert.Equal(Money.franc(20), francs.Reduce(_bank, "CHF"));
        }

        [Fact]
        public void TestMoneyToString()
        {
            var dollar = Money.dollar(10);
            var francs = Money.franc(10);
            Assert.Equal("10 USD", dollar.ToString());
            Assert.Equal("10 CHF", francs.ToString());
        }
    }
}