namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

public class EmailFactory : INotificationFactory
{
    public INotification Create()
    {
        return new EmailNotify();
    }
}