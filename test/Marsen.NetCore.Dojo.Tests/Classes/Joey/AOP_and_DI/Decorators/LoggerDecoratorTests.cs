using FluentAssertions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class LoggerDecoratorTests
    {
        readonly IAuthentication _authentication = Substitute.For<IAuthentication>();
        readonly ILogger _logger = Substitute.For<ILogger>();
        readonly IAccountService _accountService = Substitute.For<IAccountService>();
        private string _account = "account";
        private string _password = "password";
        private string _otp = "OTP";
        private LoggerDecorator _decorator;

        [Fact]
        public void TestVerifyTrueDidNotLog()
        {
            GivenVerifyResultIs(true);
            GivenDecorator();
            _decorator.Verify(_account, _password, _otp);
            _logger.DidNotReceiveWithAnyArgs().Log(Arg.Any<string>());
        }

        [Fact]
        public void TestVerifyFalseShouldLog()
        {
            GivenVerifyResultIs(false);
            GivenDecorator();
            _decorator.Verify(_account, _password, _otp).Should().Be(false);
            _logger.Received().Log(Arg.Is<string>(s => s.StartsWith($@"accountId:{_account}")));
        }

        private void GivenDecorator()
        {
            _decorator = new LoggerDecorator(_authentication, _logger, _accountService);
        }

        private void GivenVerifyResultIs(bool result)
        {
            _authentication.Verify(_account, _password, _otp).Returns(result);
        }
    }
}