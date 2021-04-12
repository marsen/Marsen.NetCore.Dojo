using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories
{
    public class EmailNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"Email {msg}");
        }

        public string Detail { get; init; }
    }
}