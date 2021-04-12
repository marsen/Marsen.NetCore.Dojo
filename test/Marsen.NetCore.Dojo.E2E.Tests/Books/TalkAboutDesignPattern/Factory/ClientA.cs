using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientA
    {
        public static void Run()
        {
            var notify = new EmailFactory().Create("Email");
            notify.Send("warning client A");
        }
    }
}