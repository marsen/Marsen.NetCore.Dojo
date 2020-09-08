using System;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Actions;
using Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern.Persons;

namespace Marsen.NetCore.Dojo.E2E.Tests.Books.TalkAboutDesignPattern.Visitor
{
    public static class GenderExpert
    {
        public static void Run()
        {
            Console.WriteLine("男人成功時，背後多半有一個偉大的女人");
            Console.WriteLine("女人成功時，背後多半有一個不成功的男人");
            Console.WriteLine("男人失敗時，悶頭喝酒，誰也不用勸");
            Console.WriteLine("女人失敗時，眼淚汪汪，誰也勸不了");
            Console.WriteLine("男人戀愛時，凡事不懂也要裝懂");
            Console.WriteLine("女人戀愛時，遇事懂也裝作不懂");
            Console.WriteLine("-----");
            Person man = new Man();
            Person woman = new Woman();
            man.Accept(new Success());
            woman.Accept(new Success());
            man.Accept(new Failing());
            woman.Accept(new Failing());
            man.Accept(new FallInLove());
            woman.Accept(new FallInLove());
        }
    }
}