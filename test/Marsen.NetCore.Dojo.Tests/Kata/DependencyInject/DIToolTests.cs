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
            var objB = target.Resolve<MockService>();
            objA.Should().NotBe(objB);
        }

        [Fact]
        public void CreateSingletonObject()
        {
            var target = new DIService();
            target.RegisterSingleton<MockService>();
            var objA = target.Resolve<MockService>();
            var objB = target.Resolve<MockService>();
            objA.Should().Be(objB);
        }


        [Fact]
        public void CreateObjectByInterfaceEveryTime()
        {
            var target = new DIService();
            target.Register<IMockService, MockService>();
            var objA = target.Resolve<IMockService>();
            var objB = target.Resolve<IMockService>();
            objA.Should().NotBe(objB);
        }
    }

    public interface IMockService
    {
    }

    public class FakeService
    {
    }

    public class MockService : IMockService
    {
    }
}