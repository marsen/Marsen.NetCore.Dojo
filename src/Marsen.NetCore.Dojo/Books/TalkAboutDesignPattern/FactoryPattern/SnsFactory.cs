using Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    public class SnsFactory
    {
        public INotification Create()
        {
            return new SNSNotify {Information = "SNS Information"};
        }
    }
}