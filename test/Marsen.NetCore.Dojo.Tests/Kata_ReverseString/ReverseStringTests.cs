﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_ReverseString
{
    public class ReverseStringTests
    {
        readonly IStringReversal _reversal = new Reversal();

        [Fact]
        public void A_is_A()
        {
            var actual = _reversal.Do("A");
            Assert.Equal("A", actual);
        }

        [Fact]
        public void BB_is_BB()
        {
            var actual = _reversal.Do("BB");
            Assert.Equal("BB", actual);
        }

        [Fact]
        public void ABC_is_CBA()
        {
            var actual = _reversal.Do("ABC");
            Assert.Equal("CBA", actual);
        }

        [Fact]
        public void ABCDEF_is_FEDCBA()
        {
            var actual = _reversal.Do("ABCDEF");
            Assert.Equal("FEDCBA", actual);
        }

        [Fact]
        public void null_is_null()
        {
            var actual = _reversal.Do(null);
            Assert.Equal(null, actual);
        }

        [Fact]
        public void stringEmpty_is_stringEmpty()
        {
            var actual = _reversal.Do(string.Empty);
            Assert.Equal(string.Empty, actual);
        }
    }
}