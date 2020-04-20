using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Decorators;
using Marsen.NetCore.Dojo.JoeyClass_AOP_and_DI.Interface;

namespace Marsen.E2E.Tests.JoeyClass_AOP_and_DI
{
    public static class Startup
    {
        private static ILogger _logger;
        private static INotification _notification;
        private static IAccountService _accountService;
        private static IAuthentication _target;
        private static IOtpServer _otpServer;
        private static IHashAdapter _hashAdapter;
        private static IUserDao _userDao;
        private static IContainer _container;

        public static void Start()
        {
            Console.WriteLine("AOP & DI Start");
            //IoCRegister();
            NewInstance();
            _target.Verify("account", "password", "otp");
        }

        private static void NewInstance()
        {
            _logger = new FakeLogger();
            _notification = new FakeNotification();
            _otpServer = new FakeOtpServer();
            _hashAdapter = new FakeHashAdapter();
            _accountService = new FakeAccountService();
            _userDao = new FakeUserDao();

            _target = new AuthenticationService(_userDao, _hashAdapter, _otpServer);
            _target = new NotificationDecorator(_target, _notification);
            _target = new LoggerDecorator(_target, _logger, _accountService);
            _target = new AccountServiceDecorator(_target, _accountService);
        }

        private static void IoCRegister()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FakeLogger>().As<ILogger>();
            builder.RegisterType<FakeNotification>().As<INotification>();
            builder.RegisterType<FakeAccountService>().As<IAccountService>();
            builder.RegisterType<FakeHashAdapter>().As<IHashAdapter>();
            builder.RegisterType<FakeOtpServer>().As<IOtpServer>();
            builder.RegisterType<FakeUserDao>().As<IUserDao>();
            builder.RegisterType<AuthenticationService>().As<IAuthentication>();
            builder.RegisterDecorator<AccountServiceDecorator, IAuthentication>();
            builder.RegisterDecorator<NotificationDecorator, IAuthentication>();
            builder.RegisterDecorator<LoggerDecorator, IAuthentication>();
            _container = builder.Build();
            _target = _container.Resolve<IAuthentication>();
        }
    }

    public class FakeOtpServer : IOtpServer
    {
        public string CurrentOtp(string accountId)
        {
            Console.WriteLine($"CurrentOtp");
            return "otp";
        }
    }

    public class FakeHashAdapter : IHashAdapter
    {
        public string Hash(string password)
        {
            Console.WriteLine($"Hash");
            return "hashed password";
        }
    }

    public class FakeAccountService : IAccountService
    {
        public bool IsLocked(string accountId)
        {
            Console.WriteLine($"IsLocked");
            return false;
        }

        public void ResetFailedCounter(string accountId)
        {
            Console.WriteLine($"ResetFailedCounter");
        }

        public void AddFailedCounter(string accountId)
        {
            Console.WriteLine($"AddFailedCounter");
        }

        public string FailedCount(string accountId)
        {
            Console.WriteLine($"FailedCount");
            return "0";
        }
    }

    public class FakeUserDao : IUserDao
    {
        public string PasswordFromDb(string accountId)
        {
            Console.WriteLine($"PasswordFromDb");
            return "hashed password";
        }
    }

    public class FakeNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Send");
        }
    }

    public class FakeLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log");
        }
    }
}