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

        private readonly IAuthentication _authService = Substitute.For<IAuthentication>();
        private readonly IAccountService _accountService = Substitute.For<IAccountService>();

        [Fact]
        public void TestVerifyIsTrue()
        {
            GivenVerifyResultIs(true);
            GivenAccountUnLocked();
            VerifyShouldBe(true);
        }


        [Fact]
        public void TestVerifyIsFalse()
        {
            GivenVerifyResultIs(false);
            GivenAccountUnLocked();
            VerifyShouldBe(false);
        }

        private void VerifyShouldBe(bool expected)
        {
            ((AccountServiceDecorator) new(_authService, _accountService)).Verify(Account, Password, Otp).Should()
                .Be(expected);
        }

        private void GivenAccountUnLocked()
        {
            _accountService.IsLocked(Account)
                .Returns(false);
        }

        private void GivenVerifyResultIs(bool result)
        {
            _authService.Verify(Account, Password, Otp)
                .Returns(result);
        }

        private AccountServiceDecorator GetDecorator()
        {
            return new(_authService, _accountService);
        }
    }
}