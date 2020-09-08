﻿using Marsen.NetCore.TestingToolkit;

namespace Marsen.NetCore.Dojo.Books.TalkAboutDesignPattern.VisitorPattern
{
    public class Success : Action
    {
        private string _name = "成功";
        public readonly SystemConsole Console = new SystemConsole();

        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{_name}時，背後多半有一個偉大的女人");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{_name}時，背後多半有一個不成功的男人");
        }
    }
}