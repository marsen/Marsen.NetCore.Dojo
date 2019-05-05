﻿using System;
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
    }
}