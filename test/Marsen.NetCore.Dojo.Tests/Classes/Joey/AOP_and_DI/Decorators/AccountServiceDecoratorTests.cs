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
        private readonly IAccountService _accountService;

        private readonly IAuthentication _authService;
        private AccountServiceDecorator _decorator;

        public AccountServiceDecoratorTests()
        {
            _authService = Substitute.For<IAuthentication>();
            _accountService = Substitute.For<IAccountService>();
        }

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
            _decorator = new AccountServiceDecorator(_authService, _accountService);
            _decorator.Verify(Account, Password, Otp)
                .Should().Be(expected);
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
            return new AccountServiceDecorator(_authService, _accountService);
        }
    }
}