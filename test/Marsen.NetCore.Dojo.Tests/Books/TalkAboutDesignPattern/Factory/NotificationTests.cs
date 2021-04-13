﻿using FluentAssertions;
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
            _notify = new NotifyFactory().Create();
            _notify.Should().BeOfType<EmailNotify>("Because we send notify via Email");
        }

        [Fact]
        public void TestCreateSNSNotify()
        {
            _notify = new NotifyFactory().Create("SNS");
            //// _notify = new SnsNotify();
            _notify.Should().BeOfType<SnsNotify>("Because we send notify via SNS");
        }
    }

    public class NotifyFactory
    {
        public INotification Create()
        {
            return new EmailNotify();
        }

        public INotification Create(string sns)
        {
            return new SnsNotify();
        }
    }
}