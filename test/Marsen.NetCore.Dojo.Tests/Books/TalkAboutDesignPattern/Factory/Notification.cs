using FluentAssertions;
using Xunit;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.Factory
{
    public class NotificationTests
    {
        [Fact]
        public void TestCreateEmailNotify()
        {
            var notify = new EmailNotify();
            notify.Should().BeOfType<EmailNotify>("Because we send notify via Email");
        }

        [Fact]
        public void TestCreateSNSNotify()
        {
            INotification notify = new SNSNotify();
            notify.Should().BeOfType<SNSNotify>("Because we send notify via SNS");
        }
    }

    public interface INotification
    {
    }

    public class SNSNotify : INotification
    {
    }

    public class EmailNotify
    {
    }
}