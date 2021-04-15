using System;
using System.Collections.Generic;
using System.Linq;
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
            B.Should().BeOfType<FakeService>();
        }
    }


    public class DIService
    {
        private object _instance;
        readonly Dictionary<Type, object> instanceLookup = new Dictionary<Type, object>();

        public void Register<T>()
        {
            instanceLookup.Add(typeof(T), Activator.CreateInstance(typeof(T)));
            //_instance = Activator.CreateInstance(typeof(T));
        }

        public object Resolve<T>()
        {
            return (T) instanceLookup.First(x => x.Key == typeof(T)).Value;
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