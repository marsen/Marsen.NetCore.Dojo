using System.Net;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IUserDao _userDao;
        private readonly IAccountService _accountService;
        private readonly IHashAdapter _hashAdapter;
        private readonly IOtpServer _otpServer;
        private readonly ILogger _logger;

        public AuthenticationService(IUserDao userDao, IAccountService accountService, IHashAdapter hashAdapter,
            IOtpServer otpServer, ILogger logger)
        {
            _userDao = userDao;
            _accountService = accountService;
            _hashAdapter = hashAdapter;
            _otpServer = otpServer;
            _logger = logger;
        }

        public AuthenticationService()
        {
            _userDao = new UserDao();
            _accountService = new AccountService();
            _hashAdapter = new SHA256Adapter();
            _otpServer = new OtpServer();
            _logger = new NLogLogger();
        }

        public bool Verify(string accountId, string password, string otp)
        {
            var isLocked = _accountService.IsLocked(accountId);
            if (isLocked)
            {
                throw new FailedTooManyTimesException() {AccountId = accountId};
            }

            var passwordFromDb = _userDao.PasswordFromDb(accountId);

            var hashedPassword = _hashAdapter.Hash(password);

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
                _logger.Log($"accountId:{accountId} failed times:{_accountService.FailedCount(accountId)}");
                return false;
            }
        }
    }
}