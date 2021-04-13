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
    }

    public class EmailNotify
    {
    }
}