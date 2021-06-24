using Marsen.NetCore.Dojo.Books.TddByExample;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private readonly Bank bank = new();
        private readonly Money fiveBulks = Money.dollar(5);
        private readonly Money fiveFrancs = Money.franc(5);
        private readonly Money fourBulks = Money.dollar(4);
        private readonly Money temFrancs = Money.franc(10);

        public WyCashTests()
        {
            bank.addRate("CHF", "USD", 2);
        }

        [Fact]
        public void testMultiplication()
        {
            Assert.Equal(Money.dollar(10), fiveBulks.Times(2));
            Assert.Equal(Money.dollar(15), fiveBulks.Times(3));
        }

        [Fact]
        public void testFrancMultiplication()
        {
            Assert.Equal(Money.franc(10), fiveFrancs.Times(2));
            Assert.Equal(Money.franc(15), fiveFrancs.Times(3));
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
            Assert.Equal(Money.dollar(10), bank.reduce(fiveBulks.Plus(fiveBulks), "USD"));
            Assert.Equal(Money.dollar(9), bank.reduce(fiveBulks.Plus(fourBulks), "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            Assert.Equal(Money.dollar(10), bank.reduce(fiveBulks.Plus(temFrancs), "USD"));
            Assert.Equal(Money.dollar(10), bank.reduce(temFrancs.Plus(fiveBulks), "USD"));
        }


        [Fact]
        public void testPlusReturnsSum()
        {
            var sum = (Sum)fiveBulks.Plus(fiveBulks);
            Assert.Equal(fiveBulks, sum.Addend);
            Assert.Equal(fiveBulks, sum.Augend);
        }

        [Fact]
        public void testReduceMoneyExchangeCurrency()
        {
            Assert.Equal(Money.dollar(1), bank.reduce(Money.franc(2), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.franc(6), "USD"));
            Assert.Equal(Money.dollar(3), bank.reduce(Money.dollar(3), "USD"));
        }

        [Fact]
        public void testSumPlusMoney()
        {
            var sum = new Sum(fiveBulks, temFrancs).Plus(fiveBulks);
            Assert.Equal(Money.dollar(15), sum.Reduce(bank, "USD"));
        }

        [Fact]
        public void testSumTimes()
        {
            var sum = new Sum(fiveBulks, temFrancs).Times(2);
            Assert.Equal(Money.dollar(20), sum.Reduce(bank, "USD"));
        }

        [Fact]
        public void testMoneyTimes()
        {
            var dollar = (Money)fiveBulks.Times(2);
            var francs = (Money)temFrancs.Times(2);
            Assert.Equal(Money.dollar(10), dollar.Reduce(bank, "USD"));
            Assert.Equal(Money.franc(20), francs.Reduce(bank, "CHF"));
        }

        [Fact]
        public void testMoneyToString()
        {
            var dollar = Money.dollar(10);
            var francs = Money.franc(10);
            Assert.Equal("10 USD", dollar.ToString());
            Assert.Equal("10 CHF", francs.ToString());
        }
    }
}