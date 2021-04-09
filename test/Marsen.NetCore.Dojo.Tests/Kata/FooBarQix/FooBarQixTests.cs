using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.FooBarQix
{
    public class FooBarQixTests
    {
        readonly Dojo.Kata.FooBarQix.FooBarQix _fooBarQix = new();

        [Fact]
        public void one_is_1()
        {
            string actual = _fooBarQix.Get(1);
            Assert.Equal("1", actual);
        }

        [Fact]
        public void two_is_2()
        {
            string actual = _fooBarQix.Get(2);
            Assert.Equal("2", actual);
        }

        [Fact]
        public void three_is_FooFoo()
        {
            string actual = _fooBarQix.Get(3);
            Assert.Equal("FooFoo", actual);
        }

        [Fact]
        public void four_is_4()
        {
            string actual = _fooBarQix.Get(4);
            Assert.Equal("4", actual);
        }

        [Fact]
        public void five_is_BarBar()
        {
            string actual = _fooBarQix.Get(5);
            Assert.Equal("BarBar", actual);
        }

        [Fact]
        public void six_is_Foo()
        {
            string actual = _fooBarQix.Get(6);
            Assert.Equal("Foo", actual);
        }

        [Fact]
        public void seven_is_QixQix()
        {
            string actual = _fooBarQix.Get(7);
            Assert.Equal("QixQix", actual);
        }

        [Fact]
        public void eight_is_8()
        {
            string actual = _fooBarQix.Get(8);
            Assert.Equal("8", actual);
        }

        [Fact]
        public void nine_is_9()
        {
            string actual = _fooBarQix.Get(9);
            Assert.Equal("Foo", actual);
        }

        [Fact]
        public void ten_is_Bar()
        {
            string actual = _fooBarQix.Get(10);
            Assert.Equal("Bar", actual);
        }

        [Fact]
        public void thirteen_is_Foo()
        {
            string actual = _fooBarQix.Get(13);
            Assert.Equal("Foo", actual);
        }

        [Fact]
        public void fifteen_is_FooBarBar()
        {
            string actual = _fooBarQix.Get(15);
            Assert.Equal("FooBarBar", actual);
        }

        [Fact]
        public void twentyOne_is_FooQix()
        {
            string actual = _fooBarQix.Get(21);
            Assert.Equal("FooQix", actual);
        }

        [Fact]
        public void thirtyThree_is_FooFooFoo()
        {
            string actual = _fooBarQix.Get(33);
            Assert.Equal("FooFooFoo", actual);
        }

        [Fact]
        public void fiftyOne_is_FooBar()
        {
            string actual = _fooBarQix.Get(51);
            Assert.Equal("FooBar", actual);
        }

        [Fact]
        public void fiftyThree_is_BarFoo()
        {
            string actual = _fooBarQix.Get(53);
            Assert.Equal("BarFoo", actual);
        }
    }
}