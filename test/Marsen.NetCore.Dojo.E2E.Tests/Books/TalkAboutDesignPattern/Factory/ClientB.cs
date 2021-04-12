﻿using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.FactoryPattern;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Factory
{
    public static class ClientB
    {
        public static void Run()
        {
            var notify = new SnsFactory().Create();
            notify.Send("warning client B");
        }
    }
}