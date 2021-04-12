using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories
{
    public class SNSNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"SNS {msg}");
        }

        public string Information { get; init; }
    }
}