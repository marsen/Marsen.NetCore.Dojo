using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.Tests.Books.TalkAboutDesignPattern.Factory
{
    public class NotifyFactory
    {
        public INotification Create(string message = null)
        {
            return message switch
            {
                "Email" => new EmailNotify(),
                "SNS" => new SnsNotify(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}