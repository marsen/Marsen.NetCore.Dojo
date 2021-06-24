using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class NotificationDecoratorTests
    {
        private readonly IAuthentication _authentication;
        private readonly INotification _notification;
        private readonly string _account = "account";
        private NotificationDecorator _decorator;
        private readonly string _otp = "otp";
        private readonly string _password = "password";

        public NotificationDecoratorTests()
        {
            _authentication = Substitute.For<IAuthentication>();
            _notification = Substitute.For<INotification>();
        }

        [Fact]
        public void TestVerify()
        {
            GivenVerifyIs(true);
            GivenDecorator();
            _decorator.Verify(_account, _password, _otp).Should().BeTrue();
        }

        [Fact]
        public void TestVerifyFalseSendNotify()
        {
            GivenVerifyIs(false);
            GivenDecorator();
            _decorator.Verify(_account, _password, _otp).Should().BeFalse();
            _notification.Received().Send(Arg.Is<string>(s => s.StartsWith($"account:{_account}")));
        }


        private void GivenDecorator()
        {
            _decorator = new NotificationDecorator(_authentication, _notification);
        }

        private void GivenVerifyIs(bool result)
        {
            _authentication.Verify(_account, _password, _otp).Returns(result);
        }
    }
}