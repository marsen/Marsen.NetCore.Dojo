using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Kata_FooBarQix;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_FooBarQix
{
    public class FooBarQixTests
    {
        readonly FooBarQix _fooBarQix = new FooBarQix();

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
    }
}