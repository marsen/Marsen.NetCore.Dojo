using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.FactoryMethod;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientC
    {
        public static void Run()
        {
            //// var notify = new VoiceCallFactory().Create();
            var notify = new PigeonFactory().Create();
            notify.Send("warning client C");
        }
    }
}