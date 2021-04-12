using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientB
    {
        public static void Run()
        {
            var notify = new SNSFactory().Create();
            notify.Send("warning client B");
        }
    }

    public class SNSFactory
    {
        public INotification Create()
        {
            return new SNSNotify {Information = "SNS Information"};
        }
    }
}