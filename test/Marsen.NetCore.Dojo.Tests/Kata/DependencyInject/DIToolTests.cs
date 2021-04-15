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
            var service = target.Resolve<MockService>();
            service.Should().BeOfType<MockService>();
        }

        [Fact]
        public void CreateMultipleObjectViaRegisterAndResolve()
        {
            var target = new DIService();
            target.Register<MockService>();
            target.Register<FakeService>();
            var A = target.Resolve<MockService>();
            var B = target.Resolve<FakeService>();
            A.Should().BeOfType<MockService>();
            B.Should().BeOfType<MockService>();
        }
    }


    public class DIService
    {
        private object _instance;

        public void Register<T>()
        {
            _instance = Activator.CreateInstance(typeof(T));
        }

        public object Resolve<T>()
        {
            return _instance;
        }
    }

    public class FakeService
    {
    }
    public class MockService
    {
    }
}