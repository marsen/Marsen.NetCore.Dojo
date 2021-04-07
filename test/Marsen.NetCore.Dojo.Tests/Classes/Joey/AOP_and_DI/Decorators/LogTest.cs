using System;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Classes.Joey.AOP_and_DI.Decorators
{
    public class LoggerDecoratorTests
    {
        [Fact]
        public void TestVerifyTrueDidNotLog()
        {
            IAuthentication authentication = Substitute.For<IAuthentication>();
                authentication.Verify("account", "password", "OTP").Returns(true);
            ILogger logger = Substitute.For<ILogger>();
            IAccountService account = Substitute.For<IAccountService>();
            LoggerDecorator target = new LoggerDecorator(authentication,logger,account);
            target.Verify("account", "password", "OTP");
            logger.DidNotReceiveWithAnyArgs().Log(Arg.Any<string>());
        }
    }
}