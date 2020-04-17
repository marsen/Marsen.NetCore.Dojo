using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Decorators
{
    public class NotificationDecorator : IAuthentication
    {
        private readonly AuthenticationService _authenticationService;
        private readonly INotification _notification;

        public NotificationDecorator(AuthenticationService authenticationService, INotification notification)
        {
            _authenticationService = authenticationService;
            _notification = notification;
        }

        private void Send(string accountId)
        {
            _notification.Send($"account:{accountId} try to login failed");
        }

        public bool Verify(string accountId, string password, string otp)
        {
            if (_authenticationService.Verify(accountId, password, otp)) return true;
            this.Send(accountId);
            return false;
        }
    }
}