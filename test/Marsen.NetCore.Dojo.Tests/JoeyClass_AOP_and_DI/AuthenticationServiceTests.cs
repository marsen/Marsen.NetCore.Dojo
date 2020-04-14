using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;
using NSubstitute;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.JoeyClass_AOP_and_DI
{
    public class AuthenticationServiceTests
    {
        private ILogger _logger;
        private INotification _notification;
        private IOtpServer _otpServer;
        private IHashAdapter _hash;
        private IAccountService _accountService;
        private IUserDao _userDao;
        private readonly string _testAccount = "test_account";
        private readonly string _returnThis = "test_otp";

        public AuthenticationServiceTests()
        {

        }
        [Fact]
        public void Verify_True()
        {
            _logger = Substitute.For<ILogger>();
            _notification = Substitute.For<INotification>();
            _otpServer = Substitute.For<IOtpServer>();
            _hash = Substitute.For<IHashAdapter>();
            _accountService = Substitute.For<IAccountService>();
            _userDao =Substitute.For<IUserDao>();
            
            _otpServer.CurrentOtp(_testAccount).Returns(_returnThis);
            var target = new AuthenticationService(_userDao, _accountService, _hash, _otpServer, _notification, _logger);
            Assert.True(target.Verify(_testAccount, "test_password", _returnThis));
        }
    }
}