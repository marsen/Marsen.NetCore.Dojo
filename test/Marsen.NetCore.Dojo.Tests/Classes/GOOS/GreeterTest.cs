using System;
using Marsen.NetCore.Dojo.Classes.GOOS;
using Marsen.NetCore.Dojo.Integration.Tests.Classes.GOOS;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.GOOS
{
    public class GreeterTest
    {
        [Fact]
        public void GreetByName()
        {
            Assert.Equal("Hello Jones", new Greeter().Invoke("Jones", "9"));
        }

        [Fact]
        public void GreetWithoutName()
        {
            Assert.Equal("Hello World", new Greeter().Invoke(string.Empty, "9"));
        }


        [Fact]
        public void SleepAt14()
        {
            Assert.Equal("Zzz", new Greeter().Invoke("Jones", "14"));
        }
    }
}