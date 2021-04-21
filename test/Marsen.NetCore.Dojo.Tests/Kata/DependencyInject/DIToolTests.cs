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

        [Fact]
        public void ThrowExceptionWhenNotRegister()
        {
            var target = new DIService();
            Action act = () => target.Resolve<MockService>();
            act.Should().Throw<Exception>()
                .Where(e => e.Message.StartsWith("Not Register") &&
                            e.Message.Contains("MockService"));
        }


        [Fact(Skip = "Not yet")]
        public void CreateObjectWithParameter()
        {
            var target = new DIService();
            target.Register<IMockService, MockService>();
            target.Register<IFakeService, FakeService>();
            var service = target.Resolve<FakeService>();
            service.Should().BeOfType<FakeService>();
        }
    }

    public interface IFakeService
    {
    }

    public class FakeService : IFakeService
    {
        private readonly IMockService _mockService;

        public FakeService(IMockService mockService)
        {
            _mockService = mockService;
        }
    }

    public interface IMockService
    {
    }

    internal class MockService : IMockService
    {
    }
}