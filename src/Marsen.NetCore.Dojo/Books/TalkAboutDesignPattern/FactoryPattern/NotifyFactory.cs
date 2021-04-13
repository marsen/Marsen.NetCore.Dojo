using System;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    [Obsolete("Stop Using Simple Factory", true)]
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