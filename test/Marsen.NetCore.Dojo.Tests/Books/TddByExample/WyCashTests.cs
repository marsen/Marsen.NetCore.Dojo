using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Books.TddByExample;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TddByExample
{
    public class WyCashTests
    {
        private readonly Bank _bank = new();
        private readonly Money _fiveBulks = Money.Dollar(5);
        private readonly Money _fiveFrancs = Money.Franc(5);
        private readonly Money _fourBulks = Money.Dollar(4);
        private readonly Money _temFrancs = Money.Franc(10);

        public WyCashTests()
        {
            _bank.addRate("CHF", "USD", 2);
        }

        [Fact]
        public void TestMultiplication()
        {
            Assert.Equal(Money.Dollar(10), _fiveBulks.Times(2));
            Assert.Equal(Money.Dollar(15), _fiveBulks.Times(3));
        }

        [Fact]
        public void TestFrancMultiplication()
        {
            Assert.Equal(Money.Franc(10), _fiveFrancs.Times(2));
            Assert.Equal(Money.Franc(15), _fiveFrancs.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.Equal(Money.Dollar(5), Money.Dollar(5));
            Assert.False(Money.Dollar(5).Equals(Money.Dollar(6)));
            Assert.Equal(Money.Franc(5), Money.Franc(5));
            Assert.False(Money.Franc(5).Equals(Money.Franc(6)));
            Assert.False(Money.Franc(5).Equals(Money.Dollar(5)));
        }

        [Fact]
        public void TestCurrency()
        {
            Assert.Equal("USD", Money.Dollar(1).Currency);
            Assert.Equal("CHF", Money.Franc(1).Currency);
        }

        [Fact]
        public void TestUnImplementCurrency()
        {
            var dollar = Money.Dollar(5);
            Action act = () => dollar.Reduce(_bank, "un_know");
            act.Should().Throw<NotImplementedException>();
        }


        [Fact]
        public void TestSimpleAddition()
        {
            Assert.Equal(Money.Dollar(10), _bank.reduce(_fiveBulks.Plus(_fiveBulks), "USD"));
            Assert.Equal(Money.Dollar(9), _bank.reduce(_fiveBulks.Plus(_fourBulks), "USD"));
        }

        [Fact]
        public void TestMixedAddition()
        {
            Assert.Equal(Money.Dollar(10), _bank.reduce(_fiveBulks.Plus(_temFrancs), "USD"));
            Assert.Equal(Money.Dollar(10), _bank.reduce(_temFrancs.Plus(_fiveBulks), "USD"));
        }


        [Fact]
        public void TestPlusReturnsSum()
        {
            var sum = (Sum) _fiveBulks.Plus(_fiveBulks);
            Assert.Equal(_fiveBulks, sum.Addend);
            Assert.Equal(_fiveBulks, sum.Augend);
        }

        [Fact]
        public void TestReduceMoneyExchangeCurrency()
        {
            Assert.Equal(Money.Dollar(1), _bank.reduce(Money.Franc(2), "USD"));
            Assert.Equal(Money.Dollar(3), _bank.reduce(Money.Franc(6), "USD"));
            Assert.Equal(Money.Dollar(3), _bank.reduce(Money.Dollar(3), "USD"));
        }

        [Fact]
        public void TestSumPlusMoney()
        {
            var sum = new Sum(_fiveBulks, _temFrancs).Plus(_fiveBulks);
            Assert.Equal(Money.Dollar(15), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void TestSumTimes()
        {
            var sum = new Sum(_fiveBulks, _temFrancs).Times(2);
            Assert.Equal(Money.Dollar(20), sum.Reduce(_bank, "USD"));
        }

        [Fact]
        public void TestMoneyTimes()
        {
            var dollar = (Money) _fiveBulks.Times(2);
            var francs = (Money) _temFrancs.Times(2);
            Assert.Equal(Money.Dollar(10), dollar.Reduce(_bank, "USD"));
            Assert.Equal(Money.Franc(20), francs.Reduce(_bank, "CHF"));
        }

        [Fact]
        public void TestMoneyToString()
        {
            var dollar = Money.Dollar(10);
            var francs = Money.Franc(10);
            Assert.Equal("10 USD", dollar.ToString());
            Assert.Equal("10 CHF", francs.ToString());
        }
    }
}