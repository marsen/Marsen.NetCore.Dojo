using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class LoggerDecoratorTests
    {
        private readonly IAuthentication _authentication;
        private readonly ILogger _logger;
        private readonly IAccountService _accountService;
        private const string Account = "account";
        private const string Password = "password";
        private const string Otp = "OTP";
        private LoggerDecorator _decorator;

        public LoggerDecoratorTests()
        {
            _authentication = Substitute.For<IAuthentication>();
            _logger = Substitute.For<ILogger>();
            _accountService = Substitute.For<IAccountService>();
        }

        [Fact]
        public void TestVerifyTrueDidNotLog()
        {
            GivenVerifyResultIs(true);
            GivenDecorator();
            _decorator.Verify(Account, Password, Otp).Should().BeTrue();
            _logger.DidNotReceiveWithAnyArgs().Log(Arg.Any<string>());
        }

        [Fact]
        public void TestVerifyFalseShouldLog()
        {
            GivenVerifyResultIs(false);
            GivenDecorator();
            _decorator.Verify(Account, Password, Otp).Should().BeFalse();
            _logger.Received().Log(Arg.Is<string>(s => s.StartsWith($@"accountId:{Account}")));
        }

        private void GivenDecorator()
        {
            _decorator = new LoggerDecorator(_authentication, _logger, _accountService);
        }

        private void GivenVerifyResultIs(bool result)
        {
            _authentication.Verify(Account, Password, Otp).Returns(result);
        }
    }
}