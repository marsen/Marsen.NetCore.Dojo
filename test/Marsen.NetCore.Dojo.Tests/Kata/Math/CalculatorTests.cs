using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Kata.Math;
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

        [Fact]
        public void Divide_4_2_is_2()
        {
            _target.Divide(4, 2).Should().Be(2);
        }

        [Fact]
        public void Divide_5_2_is_2()
        {
            _target.Divide(5, 2).Should().Be(2);
        }

        [Fact]
        public void Divide_7_2_is_3()
        {
            _target.Divide(7, 2).Should().Be(3);
        }

        [Fact]
        public void Divide_7_0_is_Exception()
        {
            Func<int> act = () => _target.Divide(7, 0);
            act.Should().Throw<DivideByZeroException>();
        }
    }
}