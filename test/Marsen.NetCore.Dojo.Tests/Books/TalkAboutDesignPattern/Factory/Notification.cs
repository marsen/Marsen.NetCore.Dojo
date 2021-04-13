using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.Factory
{
    public class NotificationTests
    {
        private INotification _notify;

        [Fact]
        public void TestCreateEmailNotify()
        {
            _notify = new EmailNotify();
            _notify.Should().BeOfType<EmailNotify>("Because we send notify via Email");
        }

        [Fact]
        public void TestCreateSNSNotify()
        {
            _notify = new SNSNotify();
            _notify.Should().BeOfType<SNSNotify>("Because we send notify via SNS");
        }
    }

    public interface INotification
    {
    }

    public class SNSNotify : INotification
    {
    }

    public class EmailNotify : INotification
    {
    }
}