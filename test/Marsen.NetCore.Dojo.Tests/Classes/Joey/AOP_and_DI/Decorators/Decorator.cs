using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class NotificationDecoratorTests
    {
        private IAuthentication _authentication = Substitute.For<IAuthentication>();
        private INotification _notification = Substitute.For<INotification>();
        private NotificationDecorator _decorator;
        private string _account = "account";
        private string _password = "password";
        private string _otp = "otp";

        [Fact]
        public void TestVerify()
        {
            GivenVerifyIs(true);
            GivenDecorator();
            _decorator.Verify(_account, _password, _otp).Should().Be(true);
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