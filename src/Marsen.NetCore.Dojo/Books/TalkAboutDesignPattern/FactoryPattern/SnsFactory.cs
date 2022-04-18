namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

public class SnsFactory : INotificationFactory
{
    public INotification Create()
    {
        return new SnsNotify();
    }
}