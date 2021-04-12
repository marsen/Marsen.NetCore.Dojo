using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
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