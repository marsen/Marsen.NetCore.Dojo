using FluentAssertions;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;
using NSubstitute;
using System;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.JoeyClass_AOP_and_DI
{
    public class AuthenticationServiceTests
    {
        private readonly ILogger _logger;
        private readonly INotification _notification;
        private readonly IOtpServer _otpServer;
        private readonly IHashAdapter _hashAdapter;
        private readonly IAccountService _accountService;
        private readonly IUserDao _userDao;
        private readonly string _testAccount = "test_account";
        private readonly string _testPassword = "test_password";
        private readonly IAuthentication _target;

        public AuthenticationServiceTests()
        {
            _logger = Substitute.For<ILogger>();
            _notification = Substitute.For<INotification>();
            _otpServer = Substitute.For<IOtpServer>();
            _hashAdapter = Substitute.For<IHashAdapter>();
            _accountService = Substitute.For<IAccountService>();
            _userDao = Substitute.For<IUserDao>();
            var authenticationService = new AuthenticationService(_userDao, _accountService, _hashAdapter, _otpServer,
                _notification,
                _logger);
            _target = new NotificationDecorator(authenticationService, _notification);
        }

        [Fact]
        public void Verify_True()
        {
            GivenAccountIsLocked(false);
            GivenPasswordFromDb("hashed password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("correct_otp");
            Assert.True(_target.Verify(_testAccount, _testPassword, "correct_otp"));
        }

        [Fact]
        public void Verify_False_Error_Password()
        {
            GivenAccountIsLocked(false);
            GivenPasswordFromDb("wrong password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("correct_otp");
            Assert.False(_target.Verify(_testAccount, _testPassword, "correct_otp"));
        }

        [Fact]
        public void Verify_IsLocked_Exception()
        {
            GivenAccountIsLocked(true);
            GivenPasswordFromDb("hashed password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("correct_otp");
            ((Action) (() => _target.Verify(_testAccount, _testPassword, "correct_otp"))).Should()
                .Throw<FailedTooManyTimesException>();
        }

        [Fact]
        public void Verify_False()
        {
            GivenAccountIsLocked(false);
            GivenPasswordFromDb("hashed password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("wrong_otp");
            Assert.False(_target.Verify(_testAccount, _testPassword, "correct_otp"));
        }

        [Fact]
        public void Verify_False_Log()
        {
            GivenAccountIsLocked(false);
            GivenPasswordFromDb("hashed password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("wrong_otp");
            Assert.False(_target.Verify(_testAccount, _testPassword, "correct_otp"));
            _logger.ReceivedWithAnyArgs().Log(default);
        }

        [Fact]
        public void Verify_False_Notify()
        {
            GivenAccountIsLocked(false);
            GivenPasswordFromDb("hashed password");
            GivenHashedPassword(_testPassword, "hashed password");
            GivenOtp("wrong_otp");
            Assert.False(_target.Verify(_testAccount, _testPassword, "correct_otp"));
            _notification.ReceivedWithAnyArgs().Send(default);
        }

        private void GivenOtp(string otp)
        {
            _otpServer.CurrentOtp(_testAccount).Returns(otp);
        }

        private void GivenAccountIsLocked(bool isLocked)
        {
            _accountService.IsLocked(_testAccount).Returns(isLocked);
        }

        private void GivenPasswordFromDb(string password)
        {
            _userDao.PasswordFromDb(_testAccount).Returns(password);
        }

        private void GivenHashedPassword(string password, string hashedPassword)
        {
            _hashAdapter.Hash(password).Returns(hashedPassword);
        }
    }
}