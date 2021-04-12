using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    public class VoiceCallNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"VoiceCall {msg}");
        }

        public string Conditional { get; init; }
    }
}