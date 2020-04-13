using System;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService
    {
        private readonly UserDao _userDao = new UserDao();
        private readonly AccountService _accountService = new AccountService();
        private readonly HashAdapter _hashAdapter = new HashAdapter();
        private readonly OtpServer _otpServer = new OtpServer();
        private readonly Slack _slack = new Slack();
        private readonly NLogLogger _nLogLogger = new NLogLogger();

        public bool Verify(string accountId, string password, string otp)
        {
            var isLocked = _accountService.IsLocked(accountId);
            if (isLocked)
            {
                throw new FailedTooManyTimesException() { AccountId = accountId };
            }

            var passwordFromDb = _userDao.PasswordFromDb(accountId);

            var hashedPassword = _hashAdapter.HashedPassword(password);

            var currentOtp = _otpServer.CurrentOtp(accountId);

            //// compare
            if (passwordFromDb == hashedPassword && currentOtp == otp)
            {
                _accountService.ResetFailedCounter(accountId);
                return true;
            }
            else
            {
                _accountService.AddFailedCounter(accountId);
                _nLogLogger.Log($"accountId:{accountId} failed times:{_accountService.FailedCount(accountId)}");
                _slack.Notification($"account:{accountId} try to login failed");
                return false;
            }
        }
    }

    public class FailedTooManyTimesException : Exception
    {
        public string AccountId { get; set; }
    }
}