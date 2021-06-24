using Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Interface;

namespace Marsen.NetCore.Dojo.Classes.Joey.AOP_and_DI.Decorators
{
    public class NotificationDecorator : IAuthentication
    {
        private readonly IAuthentication _authenticationService;
        private readonly INotification _notification;

        public NotificationDecorator(IAuthentication authenticationService, INotification notification)
        {
            _authenticationService = authenticationService;
            _notification = notification;
        }

        public bool Verify(string accountId, string password, string otp)
        {
            if (_authenticationService.Verify(accountId, password, otp)) return true;
            Send(accountId);
            return false;
        }

        private void Send(string accountId)
        {
            _notification.Send($"account:{accountId} try to login failed");
        }
    }
}