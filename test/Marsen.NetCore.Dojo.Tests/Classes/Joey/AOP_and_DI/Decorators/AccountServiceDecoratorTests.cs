using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class AccountServiceDecoratorTests
    {
        private const string Account = "account";
        private const string Password = "password";
        private const string Otp = "OTP";

        private readonly IAuthentication authService = Substitute.For<IAuthentication>();
        private readonly IAccountService _accountService = Substitute.For<IAccountService>();

        [Fact]
        public void TestVerifyIsTrue()
        {
            authService.Verify(Account, Password, Otp)
                .Returns(true);
            _accountService.IsLocked(Account)
                .Returns(false);
            GetDecorator().Verify(Account, Password, Otp).Should().Be(true);
            
        }

        [Fact]
        public void TestVerifyIsFalse()
        {
            authService.Verify(Account, Password, Otp)
                .Returns(false);
            _accountService.IsLocked(Account)
                .Returns(false);
            GetDecorator().Verify(Account, Password, Otp).Should().Be(false);
        }

        private AccountServiceDecorator GetDecorator()
        {
            return new(authService, _accountService);
        }
    }
}