using System;
using System.Collections.Generic;
using System.Text;
using Marsen.NetCore.Dojo.Kata_FooBarQix;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata_FooBarQix
{
    public class FooBarQixTests
    {
        [Fact]
        public void one_is_1()
        {
            FooBarQix fooBarQix = new FooBarQix();
            string expected = fooBarQix.Get(1);
            Assert.Equal(expected, "1");
        }
    }
}