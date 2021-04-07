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

        [Fact]
        public void TestVerifyIsTrue()
        {
            var auth = Substitute.For<IAuthentication>();
            var account = Substitute.For<IAccountService>();
            auth.Verify(Account, Password, Otp)
                .Returns(true);
            account.IsLocked(Account)
                .Returns(false);
            var target = new AccountServiceDecorator(auth, account);
            target.Verify(Account, Password, Otp).Should().Be(true);
        }
    }
}