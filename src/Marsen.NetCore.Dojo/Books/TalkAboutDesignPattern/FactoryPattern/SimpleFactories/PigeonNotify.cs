using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern.SimpleFactories
{
    public class PigeonNotify : INotification
    {
        public void Send(string msg)
        {
            Console.WriteLine($"Pigeon {msg}");
        }
    }
}