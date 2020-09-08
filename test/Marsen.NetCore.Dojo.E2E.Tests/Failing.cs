using System;

namespace Marsen.NetCore.Dojo.E2E.Tests
{
    internal class Failing : Action
    {
        private string _name = "失敗";

        public override void GetManConclusion(Man man)
        {
            Console.WriteLine($"{man.Name}{_name}時，悶頭喝酒，誰也不用勸");
        }

        public override void GetWomanConclusion(Woman woman)
        {
            Console.WriteLine($"{woman.Name}{_name}時，眼淚汪汪，誰也勸不了");
        }
    }
}