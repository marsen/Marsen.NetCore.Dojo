using System;
using FluentAssertions;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.Factory
{
    public class NotificationTests
    {
        private INotification _notify;

        [Fact]
        public void TestCreateEmailNotify()
        {
            _notify = new NotifyFactory().Create("Email");
            _notify.Should().BeOfType<EmailNotify>("Because we send notify via Email");
        }

        [Fact]
        public void TestCreateSNSNotify()
        {
            _notify = new NotifyFactory().Create("SNS");
            _notify.Should().BeOfType<SnsNotify>("Because we send notify via SNS");
        }

        [Fact]
        public void TestCreateNotifyException()
        {
            Action act = () => new NotifyFactory().Create();
            act.Should().Throw<InvalidOperationException>();
        }
    }
}