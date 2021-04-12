﻿namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern
{
    public class EmailFactory : INotifyFactory
    {
        public INotification Create()
        {
            return new EmailNotify {Detail = "Email Detail"};
        }
    }
}