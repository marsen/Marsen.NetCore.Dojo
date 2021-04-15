using System;
using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Kata.DependencyInject
{
    public class DIToolTests
    {
        [Fact]
        public void CreateObjectViaNew()
        {
            var service = new MockService();
            service.Should().BeOfType<MockService>();
        }

        [Fact]
        public void CreateObjectViaRegisterAndResolve()
        {
            var target = new DIService();
            target.Register<MockService>();
            var service =  target.Resolve<MockService>();
            service.Should().BeOfType<MockService>();
        }
    }

    public class DIService
    {
        public void Register<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }

    public class MockService
    {
    }
}