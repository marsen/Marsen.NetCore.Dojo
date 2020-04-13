using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService
    {
        private readonly IUserDao _userDao;
        private readonly IAccountService _accountService;
        private readonly IHash _hash;
        private readonly IOtpServer _otpServer;
        private readonly INotification _slack ;
        private readonly ILogger _nLogLogger ;

        public AuthenticationService(IUserDao userDao, IAccountService accountService, IHash hash, IOtpServer otpServer, INotification slack, ILogger nLogLogger)
        {
            _userDao = userDao;
            _accountService = accountService;
            _hash = hash;
            _otpServer = otpServer;
            _slack = slack;
            _nLogLogger = nLogLogger;
        }
        
        public bool Verify(string accountId, string password, string otp)
        {
            var isLocked = _accountService.IsLocked(accountId);
            if (isLocked)
            {
                throw new FailedTooManyTimesException() { AccountId = accountId };
            }

            var passwordFromDb = _userDao.PasswordFromDb(accountId);

            var hashedPassword = _hash.HashedPassword(password);

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
}