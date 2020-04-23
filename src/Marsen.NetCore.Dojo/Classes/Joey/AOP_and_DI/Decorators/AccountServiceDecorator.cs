using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Exceptions;
using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators
{
    public class AccountServiceDecorator : IAuthentication
    {
        private readonly IAuthentication _authenticationService;
        private readonly IAccountService _accountService;

        public AccountServiceDecorator(IAuthentication authenticationService, IAccountService accountService)
        {
            _authenticationService = authenticationService;
            _accountService = accountService;
        }

        private void AddFailedCounter(string accountId)
        {
            _accountService.AddFailedCounter(accountId);
        }

        public bool Verify(string accountId, string password, string otp)
        {
            IsLocked(accountId);
            if (_authenticationService.Verify(accountId, password, otp))
            {
                ResetFailedCounter(accountId);
                return true;
            }

            this.AddFailedCounter(accountId);
            return false;
        }

        private void ResetFailedCounter(string accountId)
        {
            _accountService.ResetFailedCounter(accountId);
        }

        private void IsLocked(string accountId)
        {
            if (_accountService.IsLocked(accountId))
            {
                throw new FailedTooManyTimesException() {AccountId = accountId};
            }
        }
    }
}