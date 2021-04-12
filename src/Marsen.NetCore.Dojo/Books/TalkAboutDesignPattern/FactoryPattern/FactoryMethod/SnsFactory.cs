using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.FactoryMethod
{
    public class SnsFactory : INotifyFactory
    {
        public INotification Create()
        {
            return new SNSNotify {Information = "SNS Information"};
        }
    }
}