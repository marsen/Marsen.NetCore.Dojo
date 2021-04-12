using System;
using System.Threading.Tasks;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Microsoft;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Microsoft
{
    public class AsyncCalculatorTests
    {
        private readonly AsyncCalculator _target = new();

        [Fact]
        public async Task Add()
        {
            Assert.Equal(3, await _target.Add(1, 2));
        }


        [Fact]
        public async Task Subtract()
        {
            Assert.Equal(1, await _target.Subtract(3, 2));
        }

        [Fact]
        public async Task Multiply()
        {
            Assert.Equal(21, await _target.Multiply(3, 7));
        }

        [Fact]
        public async Task Divide()
        {
            var (divisor, remainder) = await _target.Divide(7, 3);
            Assert.Equal(2, divisor);
            Assert.Equal(1, remainder);
        }

        [Fact]
        public void DivideWithZero()
        {
            Func<Task> act = async () => await _target.Divide(7, 0);
            act.Should().Throw<DivideByZeroException>();
        }
    }
}