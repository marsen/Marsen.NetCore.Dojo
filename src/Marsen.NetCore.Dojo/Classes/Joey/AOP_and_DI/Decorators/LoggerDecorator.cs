﻿using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators
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

        private bool VerifyFailedLog(string accountId)
        {
            _logger.Log($"accountId:{accountId} failed times:{_accountService.FailedCount(accountId)}");
            return false;
        }

        public bool Verify(string accountId, string password, string otp)
        {
            return _authenticationService.Verify(accountId, password, otp) || this.VerifyFailedLog(accountId);
        }
    }
}