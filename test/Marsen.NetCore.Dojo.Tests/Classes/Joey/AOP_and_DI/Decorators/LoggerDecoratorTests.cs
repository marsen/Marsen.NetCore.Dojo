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
        readonly IAccountService _account = Substitute.For<IAccountService>();

        [Fact]
        public void TestVerifyTrueDidNotLog()
        {
            GivenVerifyResultIs(true);
            var target = new LoggerDecorator(_authentication, _logger, _account);
            target.Verify("account", "password", "OTP");
            _logger.DidNotReceiveWithAnyArgs().Log(Arg.Any<string>());
        }

        private void GivenVerifyResultIs(bool result)
        {
            _authentication.Verify("account", "password", "OTP").Returns(result);
        }
    }
}