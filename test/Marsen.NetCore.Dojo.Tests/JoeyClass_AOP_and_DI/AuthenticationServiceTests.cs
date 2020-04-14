using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
        private readonly string _testOtp = "test_otp";
        private readonly string correctOtp = "test_otp";
        private readonly string wrongOtp = "wrong_otp";
        private readonly string _wrongPassword = "wrong_password";
        private readonly string _testPassword = "test_password";
        private readonly string _correctPassword = "hashed password";

        public AuthenticationServiceTests()
        {
            _logger = Substitute.For<ILogger>();
            _notification = Substitute.For<INotification>();
            _otpServer = Substitute.For<IOtpServer>();
            _hash = Substitute.For<IHashAdapter>();
            _accountService = Substitute.For<IAccountService>();
            _userDao = Substitute.For<IUserDao>();
        }

        [Fact]
        public void Verify_True()
        {
            _userDao.PasswordFromDb(_testAccount).Returns(_correctPassword);
            _hash.HashedPassword(_testPassword).Returns("hashed password");
            _otpServer.CurrentOtp(_testAccount).Returns(correctOtp);
            Assert.True(Target().Verify(_testAccount, _testPassword, _testOtp));
        }

        [Fact]
        public void Verify_False()
        {
            _userDao.PasswordFromDb(_testAccount).Returns(_correctPassword);
            _hash.HashedPassword(_testPassword).Returns("hashed password");
            _otpServer.CurrentOtp(_testAccount).Returns(wrongOtp);
            Assert.False(Target().Verify(_testAccount, _testPassword, _testOtp));
        }

        [Fact]
        public void Verify_False_Error_Password()
        {
            _userDao.PasswordFromDb(_testAccount).Returns(_wrongPassword);
            _hash.HashedPassword(_testPassword).Returns("hashed password");
            _otpServer.CurrentOtp(_testAccount).Returns(wrongOtp);
            Assert.False(Target().Verify(_testAccount, _testPassword, _testOtp));
        }

        [Fact]
        public void Verify_IsLocked_Exception()
        {
            _accountService.IsLocked(_testAccount).Returns(true);
            _userDao.PasswordFromDb(_testAccount).Returns(_correctPassword);
            _hash.HashedPassword(_testPassword).Returns("hashed password");
            _otpServer.CurrentOtp(_testAccount).Returns(wrongOtp);
            var target = new AuthenticationService(_userDao,_accountService,_hash,_otpServer,_notification,_logger);
            Action act = () => target.Verify(_testAccount,_testPassword,_testOtp);
            Assert.Throws<FailedTooManyTimesException>(act);
        }


        private AuthenticationService Target()
        {
            var target =
                new AuthenticationService(_userDao, _accountService, _hash, _otpServer, _notification, _logger);
            return target;
        }
    }
}