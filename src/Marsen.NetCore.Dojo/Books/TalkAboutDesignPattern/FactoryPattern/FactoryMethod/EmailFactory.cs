using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.FactoryMethod
{
    public class EmailFactory : INotifyFactory
    {
        public INotification Create()
        {
            return new EmailNotify {Detail = "Email Detail"};
        }
    }
}