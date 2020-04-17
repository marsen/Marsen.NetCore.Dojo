using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI
{
    public class AuthenticationService : IAuthentication
    {
        private readonly IUserDao _userDao;
        private readonly IHashAdapter _hashAdapter;
        private readonly IOtpServer _otpServer;


        public AuthenticationService(IUserDao userDao, IAccountService accountService, IHashAdapter hashAdapter,
            IOtpServer otpServer, ILogger logger)
        {
            _userDao = userDao;
            _hashAdapter = hashAdapter;
            _otpServer = otpServer;
        }

        public AuthenticationService()
        {
            _userDao = new UserDao();
            _hashAdapter = new SHA256Adapter();
            _otpServer = new OtpServer();
        }

        public bool Verify(string accountId, string password, string otp)
        {
            var passwordFromDb = _userDao.PasswordFromDb(accountId);

            var hashedPassword = _hashAdapter.Hash(password);

            var currentOtp = _otpServer.CurrentOtp(accountId);

            //// compare
            if (passwordFromDb == hashedPassword && currentOtp == otp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}