using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.FactoryMethod;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientA
    {
        public static void Run()
        {
            var notify = new EmailFactory().Create();
            notify.Send("warning client A");
        }
    }
}