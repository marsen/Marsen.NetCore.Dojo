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

        [Fact(DisplayName = "How to Create a new Notify")]
        public void TestCreateMockNotify()
        {
            //// Step 1 Create a INotificationFactory Class
            _factory = new MockFactory();
            _factory.Create()
                .Should()
                .BeOfType<MockNotify>("Because we send notify via Mock");
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

    public class MockFactory : INotificationFactory
    {
        public INotification Create()
        {
            //// Step 2 Create a new INotification Class
            return new MockNotify();
        }
    }

    public class MockNotify : INotification
    {
    }
}