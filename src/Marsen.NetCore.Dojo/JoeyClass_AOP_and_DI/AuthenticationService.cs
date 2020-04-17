using System.Net;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class LoggerDecorator : IAuthentication
    {
        private readonly IAuthentication _authenticationService;
        private readonly ILogger _logger;
        private readonly IAccountService _accountService;

        public LoggerDecorator(IAuthentication authenticationService, ILogger logger,
            IAccountService accountService)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _accountService = accountService;
        }

        private void Log(string accountId)
        {
            _logger.Log($"accountId:{accountId} failed times:{_accountService.FailedCount(accountId)}");
        }

        public bool Verify(string accountId, string password, string otp)
        {
            if (_authenticationService.Verify(accountId, password, otp))
            {
                return true;
            }

            this.Log(accountId);
            return false;
        }
    }

    public class AuthenticationService : IAuthentication
    {
        private readonly IUserDao _userDao;
        private readonly IAccountService _accountService;
        private readonly IHashAdapter _hashAdapter;
        private readonly IOtpServer _otpServer;
        private readonly ILogger _logger;
        private readonly LoggerDecorator _loggerDecorator;

        public AuthenticationService(IUserDao userDao, IAccountService accountService, IHashAdapter hashAdapter,
            IOtpServer otpServer, ILogger logger)
        {
            //_loggerDecorator = new LoggerDecorator(this);
            _userDao = userDao;
            _accountService = accountService;
            _hashAdapter = hashAdapter;
            _otpServer = otpServer;
            _logger = logger;
        }

        public AuthenticationService()
        {
            //_loggerDecorator = new LoggerDecorator(this);
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
                //_loggerDecorator.Log(accountId);
                return false;
            }
        }
    }
}