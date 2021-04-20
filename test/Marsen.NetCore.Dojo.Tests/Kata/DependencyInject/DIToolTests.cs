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
        public void CreateObjectViaRegisterAndResolveWithInterface()
        {
            var target = new DIService();
            target.Register<IMockService, MockService>();
            var service = target.Resolve<IMockService>();
            service.Should().BeOfType<MockService>();
        }


        [Fact]
        public void CreateObjectEveryTime()
        {
            var target = new DIService();
            target.Register<MockService>();
            var objA = target.Resolve<MockService>();
            target.Register<MockService>();
            var objB = target.Resolve<MockService>();
            objA.Should().NotBe(objB);
        }
    }

    public interface IMockService
    {
    }


    public class DIService
    {
        readonly Dictionary<Type, object> instanceLookup = new();
        readonly Dictionary<Type, Func<object>> instanceFuncLookup = new();

        public void Register<T>()
        {
            //// instanceLookup.Add(typeof(T), Activator.CreateInstance(typeof(T)));
            if (instanceFuncLookup.ContainsKey(typeof(T)) == false)
            {
                instanceFuncLookup.Add(typeof(T), () => Activator.CreateInstance(typeof(T)));
            }
        }

        public void Register<S, T>()
        {
            //// instanceLookup.Add(typeof(S), Activator.CreateInstance(typeof(T)));
            instanceFuncLookup.Add(typeof(S), () => Activator.CreateInstance(typeof(T)));
        }

        public T Resolve<T>()
        {
            var func = instanceFuncLookup.SingleOrDefault(x => x.Key == typeof(T)).Value;
            return (T) func.Invoke();
            ////  return (T) instanceLookup.SingleOrDefault(x => x.Key == typeof(T)).Value;
        }
    }

    public class FakeService
    {
    }

    public class MockService : IMockService
    {
    }
}