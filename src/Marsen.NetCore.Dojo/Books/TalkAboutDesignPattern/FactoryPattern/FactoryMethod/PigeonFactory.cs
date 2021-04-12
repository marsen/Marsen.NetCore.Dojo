using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.FactoryMethod
{
    public class PigeonFactory:INotifyFactory
    {
        public INotification Create()
        {
            return new PigeonNotify();
        }
    }
}