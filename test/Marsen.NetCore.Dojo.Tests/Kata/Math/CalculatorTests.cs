using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.Math
{
    public class CalculatorTests
    {
        private readonly Calculator _target = new Calculator();

        [Fact]
        public void Add_1_1_is_2()
        {
            _target.Add(1, 1).Should().Be(2);
        }

        [Fact]
        public void Add_2_1_is_3()
        {
            _target.Add(2, 1).Should().Be(3);
        }

        [Fact]
        public void Subtract_2_1_is_1()
        {
            _target.Subtract(2, 1).Should().Be(1);
        }

        [Fact]
        public void Subtract_1_2_is_minus_1()
        {
            _target.Subtract(1, 2).Should().Be(-1);
        }

        [Fact]
        public void Multiply_1_2_is_2()
        {
            _target.Multiply(1, 2).Should().Be(2);
        }

        [Fact]
        public void Multiply_2_2_is_4()
        {
            _target.Multiply(2, 2).Should().Be(4);
        }
    }

    public class Calculator
    {
        public int Add(int first, int second)
        {
            return first + second;
        }

        public int Subtract(int first, int second)
        {
            return first - second;
        }

        public int Multiply(int first, int second)
        {
            return first * second;
        }
    }
}