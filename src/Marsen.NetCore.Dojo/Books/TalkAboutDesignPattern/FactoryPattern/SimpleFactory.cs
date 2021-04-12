using System;
using Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    public class SimpleFactory
    {
        public INotification Create(string type)
        {
            return type switch
            {
                "Email" => new Email {Detail = "Email Detail"},
                "SNS" => new SNSNotify {Information = "SNS Information"},
                "VoiceCall" => new VoiceCallNotify {Conditional = "Voice Conditional"},
                "Pigeon" => new PigeonNotify(),
                _ => throw new NotImplementedException()
            };
        }
    }
}