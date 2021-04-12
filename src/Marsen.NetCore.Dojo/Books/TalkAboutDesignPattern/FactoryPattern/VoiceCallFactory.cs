namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    public class VoiceCallFactory : INotifyFactory
    {
        public INotification Create()
        {
            return new VoiceCallNotify {Conditional = "Voice Conditional"};
        }
    }
}