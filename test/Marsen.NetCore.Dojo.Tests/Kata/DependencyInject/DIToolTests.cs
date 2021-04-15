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
            var objA = target.Resolve<MockService>();
            var objB = target.Resolve<FakeService>();
            objA.Should().BeOfType<MockService>();
            objB.Should().BeOfType<FakeService>();
        }
    }


    public class DIService
    {
        readonly Dictionary<Type, object> instanceLookup = new();

        public void Register<T>()
        {
            instanceLookup.Add(typeof(T), Activator.CreateInstance(typeof(T)));
        }

        public object Resolve<T>()
        {
            return (T) instanceLookup.First(x => x.Key == typeof(T)).Value;
        }
    }

    public class FakeService
    {
    }

    public class MockService
    {
    }
}