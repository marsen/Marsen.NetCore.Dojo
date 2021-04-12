using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories
{
    public class SimpleFactory
    {
        public INotification Create(string type)
        {
            return type switch
            {
                "Email" => new EmailNotify {Detail = "Email Detail"},
                "SNS" => new SNSNotify {Information = "SNS Information"},
                "VoiceCall" => new VoiceCallNotify {Conditional = "Voice Conditional"},
                "Pigeon" => new PigeonNotify(),
                _ => throw new NotImplementedException()
            };
        }
    }
}