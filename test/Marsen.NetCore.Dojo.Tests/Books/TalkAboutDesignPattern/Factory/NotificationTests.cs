using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.Factory
{
    public class NotificationTests
    {
        private INotificationFactory _factory;

        [Fact]
        public void TestCreateEmailNotify()
        {
            _factory = new EmailFactory();
            _factory.Create()
                .Should()
                .BeOfType<EmailNotify>("Because we send notify via Email");
        }

        [Fact]
        public void TestCreateSNSNotify()
        {
            _factory = new SnsFactory();
            _factory.Create()
                .Should()
                .BeOfType<SnsNotify>("Because we send notify via SNS");
        }

        [Fact(Skip = "Stop Use SimpleFactory Pattern")]
        public void TestCreateNotifyException()
        {
            /*
            Action act = () => new NotifyFactory().Create();
            act.Should().Throw<InvalidOperationException>();
            */
        }
    }
}