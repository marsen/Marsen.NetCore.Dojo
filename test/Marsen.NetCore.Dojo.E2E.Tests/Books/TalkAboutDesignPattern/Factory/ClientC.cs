using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientC
    {
        public static void Run()
        {
            var notify = new VoiceCallFactory().Create();
            //// var notify = new SimpleFactory().Create("VoiceCall");
            notify.Send("warning client C");
        }
    }

    public class VoiceCallFactory
    {
        public INotification Create()
        {
            return new VoiceCallNotify {Conditional = "Voice Conditional"};
        }
    }
}