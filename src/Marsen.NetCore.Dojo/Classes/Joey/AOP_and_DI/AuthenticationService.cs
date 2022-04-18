using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI;

public class AuthenticationService : IAuthentication
{
    private readonly IHashAdapter _hashAdapter;
    private readonly IOtpServer _otpServer;
    private readonly IUserDao _userDao;

    public AuthenticationService(IUserDao userDao, IHashAdapter hashAdapter, IOtpServer otpServer)
    {
        _userDao = userDao;
        _hashAdapter = hashAdapter;
        _otpServer = otpServer;
    }

    public bool Verify(string accountId, string password, string otp)
    {
        return IsSamePassword(accountId, password) && IsOtpCorrect(accountId, otp);
    }

    private bool IsOtpCorrect(string accountId, string otp)
    {
        return _otpServer.CurrentOtp(accountId) == otp;
    }

    private bool IsSamePassword(string accountId, string password)
    {
        return _userDao.PasswordFromDb(accountId) == _hashAdapter.Hash(password);
    }
}